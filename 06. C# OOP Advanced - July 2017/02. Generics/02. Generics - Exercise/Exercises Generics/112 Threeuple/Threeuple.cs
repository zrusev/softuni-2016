public class Threeuple<T, U, G>
{
    public Threeuple(T itemOne, U itemTwo, G itemThree)
    {
        this.ItemOne = itemOne;
        this.ItemTwo = itemTwo;
        this.ItemThree = itemThree;
    }

    public T ItemOne { get; private set; }

    public U ItemTwo { get; private set; }

    public G ItemThree { get; private set; }

    public override string ToString()
    {
        return $"{this.ItemOne} -> {this.ItemTwo} -> {this.ItemThree}";
    }
}