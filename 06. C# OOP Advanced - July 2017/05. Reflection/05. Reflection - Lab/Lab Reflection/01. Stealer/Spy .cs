using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string ClassName { get; set; }
    public string [] Fields { get; set; }
    public string StealFieldInfo(string className, params string [] fields)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        StringBuilder sb = new StringBuilder();

        Object classsInstance = Activator.CreateInstance(classType, new object[] { });

        sb.AppendLine($"Class under investigation: {className}");

        foreach (FieldInfo field in classFields.Where(f => fields.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classsInstance)}");
        }

        return sb.ToString().Trim();
    }
}