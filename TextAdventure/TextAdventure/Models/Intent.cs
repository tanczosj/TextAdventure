using TextAdventure.Enum;

namespace TextAdventure.Models;

/// <summary>
/// Summarizes what the user types into a single choice
/// </summary>
public class Intent
{
    /// <summary>
    /// Either "
    /// </summary>
    public IntentResult Status { get; set; } = IntentResult.UnclearChoice;
    public string Message { get; set; } = string.Empty;
}
