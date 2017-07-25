using System.Collections.Generic;

namespace Collection_Hierarchy
{
    public abstract class Collection<T>
    {
        private readonly IList<T> list;

        public Collection()
        {
            this.list = new List<T>();
        }

        public IList<T> List
        {
            get => this.list;
        }
    }
}