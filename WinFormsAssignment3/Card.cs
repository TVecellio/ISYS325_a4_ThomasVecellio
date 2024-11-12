public class Card
{
    public int Id { get; }
    public string Name { get; } // New read-only Name property
    public Image? CardImage { get; }

    // Updated constructor to initialize Id, Name, and CardImage
    public Card(int id, string name,  Image? image)
    {
        Id = id;
        Name = name;
        CardImage = image;
    }

    // Static readonly NoCard constant
    public static readonly Card NoCard = new Card(-1, "No Card",  null);

    // Override ToString to return Name instead of Id
    public override string ToString()
    {
        return Name;
    }
}
