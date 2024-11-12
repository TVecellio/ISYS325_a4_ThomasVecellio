public class Card
{
    public int Id { get; }
    public string Name { get; } 
    public Image? CardImage { get; }

    
    public Card(int id, string name,  Image? image)
    {
        Id = id;
        Name = name;
        CardImage = image;
    }

    
    public static readonly Card NoCard = new Card(-1, "No Card",  null);

    
    public override string ToString()
    {
        return Name;
    }
}
