using TextAdventure;
using TextAdventure.Models;
using TextAdventure.Services;
using TextAdventure.Enum;

// Set up story and services
IntentAnalyzerService intentAnalyzer = new();
StoryBuilder sb = new StoryBuilder();
Story story = sb.Build();

Console.ForegroundColor = ConsoleColor.DarkGreen;

// Sets the first room to "SpaceShipOpening"
Room current = story.Rooms[Rooms.SpaceshipOpening];

while (true)
{
    Console.Clear();

    // Display description of room to user
    Textfx.TypeLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-\n", 0);
    Textfx.TypeLine(current.Description, 25);
    Textfx.TypeLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-\n", 0);

    // End story if there are no choices
    if (current.Choices.Count == 0)
        break;

    // Displays choices to user
    Textfx.TypeLine("|2What would you like to do next?");
    foreach (var choice in current.Choices)
    { 
        Textfx.TypeLine("- " + choice.Description);
    }

    Choice? option = null;

    // Gets the choice from the user
    while (option == null)
    {
        Console.Write("\nWhat is your choice? : ");
        string response = Console.ReadLine();

        // If user wants to stop then switch to the stop room
        if (response.ToLower() == "stop")
        {
            option = new Choice(string.Empty, "Stop");
            break;
        }

        // Detects if choice is available by using ChatGPT to match the user response to one of the possible choices
        var intent = intentAnalyzer.GetIntent(current, response);

        // If the user response matches one of the available choices
        if (intent.Status == IntentResult.MatchedChoice)
        {
            // Get the matching option for this choice
            option = current.Choices.FirstOrDefault(x => x.Description == intent.Message);

            // If unable to get option, present something to the user
            if (option == null)
            {
                Textfx.Type("That's not an option");
            }
        }
        else if (intent.Status == IntentResult.UnclearChoice)
        {
            Textfx.Type(intent.Message);
        }
    }

    // Move to the next room
    current = story.Rooms[option.NextRoomId];
}