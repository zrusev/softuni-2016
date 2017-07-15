public abstract class Monument
{
    protected string Name { get; set; }

    protected Monument(string name)
    {
        this.Name = name;
    }

    public abstract int GetAffinity();

    public override string ToString()
    {
        string monumentType = this.GetType().Name;
        int typeEnd = monumentType.IndexOf("Monument");
        monumentType = monumentType.Insert(typeEnd, " ");

        return $"{monumentType}: {this.Name}";
    }
}