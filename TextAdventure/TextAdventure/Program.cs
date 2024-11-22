// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Microsoft.Extensions.Configuration;
using OpenAI.Chat;
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

	Textfx.TypeLine(current.Description + "\n", 25);

	if (current.Choices.Count == 0)
		break;

    Textfx.TypeLine("|2What would you like to do |Enext|2?");
	foreach (var choice in current.Choices)
	{
		Textfx.TypeLine("- " + choice.Description);
	}

	Choice? option = null;

	while (option == null)
	{
		Console.Write("\nWhat is your choice? : ");
		string response = Console.ReadLine();

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