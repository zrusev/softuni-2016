public static class ArrayCreator
{
    public static T[] Create<T>(int lenght, T item)
    {
        return new T[lenght];
    }
}