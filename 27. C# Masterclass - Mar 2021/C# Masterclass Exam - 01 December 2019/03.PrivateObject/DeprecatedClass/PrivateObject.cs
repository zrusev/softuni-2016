namespace DeprecatedClass
{
    using System;
    using System.Reflection;

    public class PrivateObject
    {
        private readonly Type objType;

        public PrivateObject(object obj)
        {
            this.objType = obj.GetType();
        }

        public object Invoke(string methodName, params object[] parameters)
        {
            var instance = Activator.CreateInstance(this.objType);

            MethodInfo method = this.objType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
            
            return method.Invoke(instance, parameters);
        }
    }
}
