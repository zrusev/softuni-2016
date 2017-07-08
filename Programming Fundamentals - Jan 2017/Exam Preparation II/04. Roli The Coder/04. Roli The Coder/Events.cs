namespace _04.Roli_The_Coder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Events
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public SortedSet<string> Participants { get; set; }
    }
}
