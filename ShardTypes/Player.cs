namespace ShardTypes;

public class Player
{
    public string? Name { get; set; }
    public int NumberOfDrinksToDo { get; set; }
    public int NumberOfDrinksDone { get; set; }

    public List<Card> Hand { get; set; } = new();
}