namespace _01.Loader
{
    using _01.Loader.Interfaces;
    using _01.Loader.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Loader : IBuffer
    {
        private List<IEntity> _entities;

        public Loader()
            => this._entities = new List<IEntity>();

        public int EntitiesCount => this._entities.Count;

        public void Add(IEntity entity)
            => this._entities.Add(entity);
        
        public void Clear()
            => this._entities.Clear();

        public bool Contains(IEntity entity)
            => this.GetById(entity.Id) != null;

        public IEntity Extract(int id)
        {
            IEntity found = this.GetById(id);

            if (found != null)
            {
                this._entities.Remove(found);
            }

            return found;
        }

        private IEntity GetById(int id)
        {
            for (int i = 0; i < this.EntitiesCount; i++)
            {
                var currentEntity = this._entities[i];

                if (currentEntity.Id == id)
                {
                    return currentEntity;
                }
            }

            return null;
        }

        public IEntity Find(IEntity entity)
            => this.GetById(entity.Id);

        public List<IEntity> GetAll()
            => new List<IEntity>(this._entities);

        public void RemoveSold()
            => this._entities.RemoveAll(e => e.Status == BaseEntityStatus.Sold);

        public void Replace(IEntity oldEntity, IEntity newEntity)
        {
            int indexOfEntity = this._entities.IndexOf(oldEntity);
            this.ValidateEntity(indexOfEntity);

            this._entities[indexOfEntity] = newEntity;
        }

        public List<IEntity> RetainAllFromTo(BaseEntityStatus lowerBound, BaseEntityStatus upperBound)
        {
            List<IEntity> result = new List<IEntity>(this.EntitiesCount);
            int lowerBoundIndex = (int)lowerBound;
            int upperBoundIndex = (int)upperBound;

            for (int i = 0; i < this.EntitiesCount; i++)
            {
                var entity = this._entities[i];
                var entityStatusIndex = (int)entity.Status;
                
                if (entityStatusIndex >= lowerBoundIndex
                    && entityStatusIndex <= upperBoundIndex)
                {
                    result.Add(entity);
                }
            }

            return result;
        }

        public void Swap(IEntity first, IEntity second)
        {
            int indexOfFirst = this._entities.IndexOf(first);
            this.ValidateEntity(indexOfFirst);

            int indexOfSecond = this._entities.IndexOf(second);
            this.ValidateEntity(indexOfSecond);

            var temp = this._entities[indexOfFirst];
            this._entities[indexOfFirst] = this._entities[indexOfSecond];
            this._entities[indexOfSecond] = temp;
        }

        public IEntity[] ToArray()
            => this._entities.ToArray();

        public void UpdateAll(BaseEntityStatus oldStatus, BaseEntityStatus newStatus)
        {
            for (int i = 0; i < this.EntitiesCount; i++)
            {
                var current = this._entities[i];

                if (current.Status == oldStatus)
                {
                    current.Status = newStatus;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        public IEnumerator<IEntity> GetEnumerator()
            => this._entities.GetEnumerator();

        private void ValidateEntity(int index)
        {
            if (index == -1)
            {
                throw new InvalidOperationException("Entity not found");
            }
        }
    }
}