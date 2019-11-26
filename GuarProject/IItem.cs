namespace GuarProject
{
    // Interface of items
    public interface IItem
    {
        int Weight { get; }
        int Value { get; }
        string Name { get; }
        bool Found { get; set; }
    }
}