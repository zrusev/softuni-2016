namespace CTF.Framework.Asserts
{
    using Exceptions;
    using System;

    // ReSharper disable once InconsistentNaming
    public abstract class CTFAssert
    {
        public static void AreEqual(object a, object b)
        {
            Throws<TestException>(GetConditionResultByTypeAbstraction(a, b, true));
        }

        public static void AreNotEqual(object a, object b)
        {
            Throws<TestException>(GetConditionResultByTypeAbstraction(a, b, false));
        }

        public static void Throws<T>(Func<bool> condition)
            where T : Exception, new()
        {
            if (!condition.Invoke())
            {
                throw new T();
            }
        }

        private static Func<bool> GetConditionResultByTypeAbstraction(object a, object b, bool sign)
        {
            bool result;

            if (a.GetType().IsValueType && b.GetType().IsValueType)
            {
                result = a.Equals(b);
            }
            else
            {
                result = Object.ReferenceEquals(a, b);
            }

            if (!sign)
            {
                result = !result;
            }

            return () => result;
        }


        private static Func<bool> GetConditionResultByType(object a, object b, bool sign)
        {
            bool result;

            if (a.GetType() == b.GetType()
                && a.GetType() == typeof(string))
            {
                result = object.ReferenceEquals(a, b);
            }
            else if (a.GetType() == b.GetType()
                && a.GetType() == typeof(int))
            {
                result = (int)a == (int)b;
            }
            else if (a.GetType() == b.GetType()
               && a.GetType() == typeof(object))
            {
                result = a.Equals(b);
            }
            else
            {
                result = a.Equals(b);
            }

            if (!sign)
            {
                result = !result;
            }

            return () => result;
        }
    }
}