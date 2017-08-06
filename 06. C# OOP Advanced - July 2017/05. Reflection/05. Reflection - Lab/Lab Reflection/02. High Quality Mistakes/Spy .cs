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

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        foreach (FieldInfo classField in classFields)
        {
            sb.AppendLine($"{classField.Name} must be private!");
        }

        foreach (MethodInfo method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        foreach (MethodInfo method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }
}