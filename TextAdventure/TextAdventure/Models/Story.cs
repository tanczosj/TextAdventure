namespace TextAdventure.Models;

public class Story
{
    public Dictionary<string, Room> Rooms { get; set; } = new();
}
