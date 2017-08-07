using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _01.Harvesting_Fields
{
    public class HarvestingRunner
    {
        public Dictionary<string, string> Harvest()
        {            
            var dict = new Dictionary<string, string>();
            StringBuilder sb = new StringBuilder();

            Type classType = typeof(HarvestingFields);
            FieldInfo[] classAllFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (FieldInfo fieldInfo in classAllFields)
            {
                sb.AppendLine($"{fieldInfo.Attributes.ToString().ToLower()} {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                sb.Replace("family", "protected");
            }

            dict.Add("all", sb.ToString().Trim());
            sb.Clear();

            foreach (FieldInfo fieldInfo in classAllFields.Where(f => f.IsPrivate))
            {
                sb.AppendLine($"private {fieldInfo.FieldType.Name} {fieldInfo.Name}");
            }

            dict.Add("private", sb.ToString().Trim());
            sb.Clear();

            foreach (FieldInfo fieldInfo in classAllFields.Where(f => f.IsPublic))
            {
                sb.AppendLine($"public {fieldInfo.FieldType.Name} {fieldInfo.Name}");
            }

            dict.Add("public", sb.ToString().Trim());
            sb.Clear();

            foreach (FieldInfo fieldInfo in classAllFields.Where(f => f.IsFamily))
            {
                sb.AppendLine($"protected {fieldInfo.FieldType.Name} {fieldInfo.Name}");
            }

            dict.Add("protected", sb.ToString().Trim());
            sb.Clear();

            return dict;
        }
    }
}