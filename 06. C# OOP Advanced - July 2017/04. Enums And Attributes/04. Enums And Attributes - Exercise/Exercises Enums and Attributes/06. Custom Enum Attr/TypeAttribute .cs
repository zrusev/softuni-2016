using System;

namespace _06.Custom_Enum_Attr
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum)]
    public class TypeAttribute : Attribute
    {
        private string type;

        public string Type => this.type;
        public string Category { get; set; }
        public string Description { get; set; }

        public TypeAttribute(string category, string description)
        {
            
            this.Category = category;
            this.Description = description;
        }




    }
}