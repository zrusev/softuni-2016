namespace MasterInjection
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class MyServiceProvider : IMyServiceProvider
    {
        private static ConcurrentDictionary<Type, Type> mappings 
            = new ConcurrentDictionary<Type, Type>();

        private static object Get(Type type)
        {
            var target = ResolveType(type);
            
            var constructor = target.GetConstructors(BindingFlags.Public 
                | BindingFlags.NonPublic 
                | BindingFlags.Static 
                | BindingFlags.FlattenHierarchy
                | BindingFlags.Instance)
                .OrderBy(ctor => ctor.GetParameters()
                .Count())
                .FirstOrDefault();

            var parameters = constructor.GetParameters();

            List<object> resolvedParameters = new List<object>();

            foreach (var item in parameters)
            {
                resolvedParameters.Add(Get(item.ParameterType));
            }

            return constructor.Invoke(resolvedParameters.ToArray());
        }

        private static Type ResolveType(Type type)
        {
            if (mappings.Keys.Contains(type))
            {
                return mappings[type];
            }

            if (!mappings.Values.Contains(type))
            {
                return default(Type);
            }

            return type;
        }

        public MyServiceProvider()
        {
        }

        public void Add<TSource, TDestination>()
            where TDestination : TSource
        {
            _ = mappings.TryAdd<Type, Type>(typeof(TSource), typeof(TDestination));
        }

        public object CreateInstance(Type type)
            => Get(type);
        
        public T CreateInstance<T>()
            => (T)Get(typeof(T));
    }
}