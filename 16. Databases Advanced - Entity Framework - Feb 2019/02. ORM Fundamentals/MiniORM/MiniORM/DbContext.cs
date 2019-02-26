namespace MiniORM
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Reflection;

    public abstract class DbContext
    {
        private readonly DatabaseConnection connection;
        private readonly Dictionary<Type, PropertyInfo> dbSetProperties;

        protected DbContext(string connectionString)
        {
            this.connection = new DatabaseConnection(connectionString);

            this.dbSetProperties = this.DiscoverDbSets();

            using (new ConnectionManager(this.connection))
            {
                this.InitializeDbSets();
            }

            this.MapAllRelations();
        }

        internal static readonly Type[] AllowedSqlTypes =
        {
                    typeof(int),
                    typeof(string),
                    typeof(ulong),
                    typeof(long),
                    typeof(uint),
                    typeof(decimal),
                    typeof(bool),
                    typeof(DateTime)
        };

        private Dictionary<Type, PropertyInfo> DiscoverDbSets()
            => this.GetType().GetProperties()
                .Where(pi => pi.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .ToDictionary(k => k.PropertyType.GetGenericArguments().First(), v => v);
        
        private void InitializeDbSets()
        {
            foreach (var dbSetProperty in dbSetProperties)
            {
                var dbSetType = dbSetProperty.Key;
                var dbSetPropertyType = dbSetProperty.Value;

                var populateDbSetGeneric = typeof(DbContext)
                    .GetMethod("PopulateDbSet", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(dbSetType);

                populateDbSetGeneric.Invoke(this, new object[] { dbSetPropertyType });
            }
        }

        private void PopulateDbSet<TEntity>(PropertyInfo dbSet)
            where TEntity : class, new()
        {
            var tableEntities = LoadTableEntities<TEntity>();

            var dbSetInstance = new DbSet<TEntity>(tableEntities);

            ReflectionHelper.ReplaceBackingField(this, dbSet.Name, dbSetInstance);
        }

        private IEnumerable<TEntity> LoadTableEntities<TEntity>() 
            where TEntity : class, new()
        {
            var table = typeof(TEntity);

            var columns = GetColumnNames(table);

            var tableName = GetTableName(table);

            return this.connection.FetchResultSet<TEntity>(tableName, columns).ToArray();
        }

        private string[] GetColumnNames(Type table)
        {
            var tableName = this.GetTableName(table);

            var dbColumns = this.connection.FetchColumnNames(tableName);

            var columns = table.GetProperties()
                .Where(pi => dbColumns.Contains(pi.Name) && 
                            !pi.HasAttribute<NotMappedAttribute>() && 
                            AllowedSqlTypes.Contains(pi.PropertyType))
                .Select(pi => pi.Name)
                .ToArray();

            return columns;
        }

        private string GetTableName(Type tableType)
        {
            var tableName = ((TableAttribute)Attribute.GetCustomAttribute(tableType, typeof(TableAttribute))).Name;

            if (tableName == null)
            {
                tableName = this.dbSetProperties[tableType].Name;
            }

            return tableName;
        }

        private void MapAllRelations()
        {
            foreach (var dbSetProperty in dbSetProperties)
            {
                var dbSetType = dbSetProperty.Key;

                var mapRelationsGeneric = typeof(DbContext)
                    .GetMethod("MapRelations", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(dbSetType);

                var dbSet = dbSetProperty.Value.GetValue(this);

                mapRelationsGeneric.Invoke(this, new[] { dbSet });
            }
        }

        private void MapRelations<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            var entityType = typeof(TEntity);

            MapNavigationProperties(dbSet);

            var collections = entityType.GetProperties()
                .Where(pi => pi.PropertyType.IsGenericType &&
                             pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                .ToArray();

            foreach (var collection in collections)
            {
                var collectionType = collection.PropertyType.GenericTypeArguments.First();

                var mapCollectionMethod = typeof(DbContext)
                    .GetMethod("MapCollection", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(entityType, collectionType);

                mapCollectionMethod.Invoke(this, new object[] { dbSet, collection });
            }
        }

        private void MapNavigationProperties<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            var entityType = typeof(TEntity);

            var foreignKeys = entityType.GetProperties()
                .Where(pi => pi.HasAttribute<ForeignKeyAttribute>())
                .ToArray();

            foreach (var foreignKey in foreignKeys)
            {
                var navPropertyName = foreignKey.GetCustomAttribute<ForeignKeyAttribute>().Name;

                var navProperty = entityType.GetProperty(navPropertyName);

                var navDbSet = dbSetProperties[navProperty.PropertyType].GetValue(this);

                var navPrimaryKey = navProperty.PropertyType.GetProperties()
                    .First(pi => pi.HasAttribute<KeyAttribute>());

                foreach (var entity in dbSet)
                {
                    var foreignKeyValue = foreignKey.GetValue(entity);

                    var navPropertyValue = ((IEnumerable<object>)navDbSet)
                        .First(currentNavProp => navPrimaryKey.GetValue(currentNavProp).Equals(foreignKeyValue));

                    navProperty.SetValue(entity, navPropertyValue);
                }
            }
        }

        public void SaveChanges()
        {
            var dbSets = dbSetProperties
                .Select(pi => pi.Value.GetValue(this))
                .ToArray();

            foreach (IEnumerable<object> dbSet in dbSets)
            {
                var invalidEntities = dbSet
                    .Where(x => !IsObjectValid(x))
                    .ToArray();

                if (invalidEntities.Any())
                {
                    throw new InvalidOperationException($"{invalidEntities.Length} Invalid Entities found in {dbSet.GetType().Name}!");
                }
            }

            using (new ConnectionManager(this.connection))
            {
                using (var transaction = this.connection.StartTransaction())
                {
                    foreach (IEnumerable dbSet in dbSets)
                    {
                        var dbSetType = dbSet.GetType().GetGenericArguments().First();

                        var persistMethod = typeof(DbContext)
                            .GetMethod("Persist", BindingFlags.Instance | BindingFlags.NonPublic)
                            .MakeGenericMethod(dbSetType);

                        try
                        {
                            persistMethod.Invoke(this, new object[] { dbSet });
                        }
                        catch (TargetInvocationException tie)
                        {
                            throw tie.InnerException;
                        }
                        catch (InvalidOperationException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                        catch (SqlException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }

                    transaction.Commit();
                }
            }
        }

        private void MapCollection<TDbSet, TCollection>(DbSet<TDbSet> dbSet, PropertyInfo collectionProperty)
            where TDbSet : class, new() 
            where TCollection : class, new()
        {

            var entityType = typeof(TDbSet);
            var collectionType = typeof(TCollection);

            var primaryKeys = collectionType.GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            var primaryKey = primaryKeys.First();

            var foreignKey = entityType.GetProperties()
                .First(pi => pi.HasAttribute<KeyAttribute>());

            var isManyToMany = primaryKeys.Length >= 2;

            if (isManyToMany)
            {
                primaryKey = collectionType.GetProperties()
                    .First(pi => collectionType
                                .GetProperty(pi.GetCustomAttribute<ForeignKeyAttribute>().Name)
                                .PropertyType == entityType);

                var navigationDbSet = (DbSet<TCollection>)this.dbSetProperties[collectionType].GetValue(this);

                foreach (var entity in dbSet)
                {
                    var primaryKeyValue = foreignKey.GetValue(entity);

                    var navigationEntities = navigationDbSet
                        .Where(pi => primaryKey.GetValue(pi).Equals(primaryKeyValue))
                        .ToArray();

                    ReflectionHelper.ReplaceBackingField(entity, collectionProperty.Name, navigationEntities);
                }
            }
        }

        private void Persist<TEntity>(DbSet<TEntity> dbSet) 
            where TEntity : class, new()
        {
            var tableName = GetTableName(typeof(TEntity));

            var columns = connection.FetchColumnNames(tableName).ToArray();

            if (dbSet.ChangeTracker.Added.Any())
            {
                connection.InsertEntities(dbSet.ChangeTracker.Added, tableName, columns);
            }

            if (dbSet.ChangeTracker.Removed.Any())
            {
                connection.DeleteEntities(dbSet.ChangeTracker.Removed, tableName, columns);
            }

            var modifiedEntities = dbSet.ChangeTracker.GetModifiedEntities(dbSet).ToArray();

            if (modifiedEntities.Any())
            {
                connection.UpdateEntities(modifiedEntities, tableName, columns);

            }
        }

        private bool IsObjectValid(object o)
        {
            var validationContext = new ValidationContext(o);

            var valErrors = new List<ValidationResult>();

            return Validator.TryValidateObject(o, validationContext, valErrors, true);
        }
    }
}