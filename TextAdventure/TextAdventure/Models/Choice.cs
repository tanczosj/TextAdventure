namespace TextAdventure.Models;

public class Choice
{
    public Choice(string description, string nextRoomId)
    {
        this.Description = description;
        this.NextRoomId = nextRoomId;
    }

    public string Description { get; set; }
    public string NextRoomId { get; set; }
}
