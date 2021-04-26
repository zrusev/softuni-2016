namespace Singleton
{
    using System;

    public sealed class Entity
    {
        private static Entity entity;
        private static object syncEntity = new Object();

        private Entity() {}

        public static Entity Instance
        {
            get 
            {
                lock(syncEntity)
                {
                    if(entity == null)
                    {
                        entity = new Entity();
                    }
                }

                return entity;
            }
        } 
    }
}