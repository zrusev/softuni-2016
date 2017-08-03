namespace _11.Inferno_Infinity.Attributes
{
    using System;
    using System.Collections.Generic;

    [AttributeUsage(AttributeTargets.Class)]
    public class CustomClassAttribute : Attribute
    {
        public CustomClassAttribute(string author, int revision, string description, params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = new List<string>(reviewers);
        }

        public string Author { get; private set; }
        public int Revision { get; private set; }
        public string Description { get; private set; }
        public IList<string> Reviewers { get; private set; }
    }
}