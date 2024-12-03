// See https://aka.ms/new-console-template for more information

using TextAdventure;
using TextAdventure.Models;
using TextAdventure.Services;

IntentAnalyzerService intentAnalyzer = new();
StoryBuilder sb = new StoryBuilder();
Story story = sb.Build();

Console.ForegroundColor = ConsoleColor.DarkGreen;

Room current = story.Rooms["warehouse"];

while (true)
{
    Console.Clear();

    // Display description of room to user
    Textfx.TypeLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-\n", 0);
    Textfx.TypeLine(current.Description, 25);
    Textfx.TypeLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-\n", 0);

    if (current.Choices.Count == 0)
        break;

    Textfx.TypeLine("|2What would you like to do next?");
    foreach (var choice in current.Choices)
    {
        Textfx.TypeLine("- " + choice.Description);
    }

    Choice? option = null;

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

        var intent = intentAnalyzer.GetIntent(current, response);

        if (intent.Status == "choice")
        {
            option = current.Choices.FirstOrDefault(x => x.Description == intent.Message);

            if (option == null)
            {
                Textfx.Type("That's not an option");
            }
        }
        else if (intent.Status == "unclear")
        {
            Textfx.Type(intent.Message);
        }
    }

    current = story.Rooms[option.NextRoomId];
}