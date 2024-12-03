namespace TextAdventure.Models;

/// <summary>
/// Represents one of the choices a user can make when in a Room
/// </summary>
public class Choice
{
    public Choice(string description, string nextRoomId)
    {
        this.Description = description;
        this.NextRoomId = nextRoomId;
    }

    /// <summary>
    /// Description of the choice 
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Next room Id if user chooses this choice
    /// </summary>
    public string NextRoomId { get; set; }
}
