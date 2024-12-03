using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using OpenAI.Chat;
using TextAdventure.Models;

namespace TextAdventure.Services;

public class IntentAnalyzerService
{
    private ChatClient _client;

    public IntentAnalyzerService()
    {
        var builder = new ConfigurationBuilder()
            .AddUserSecrets(Assembly.GetExecutingAssembly());
        var configurationRoot = builder.Build();

        var key = configurationRoot.GetSection("OpenAIKey").Get<string>() ?? string.Empty;
        _client = new(model: "gpt-4o-mini", apiKey: key);

    }

    public Intent GetIntent(Models.Room room, string userResponse)
    {
        ChatCompletion chatCompletion = _client.CompleteChat(GetSystemMessage(room), $"User says: {userResponse}");

        var response = chatCompletion.Content.First().Text;
        var json = ExtractJsonObject(response);

        var intent = JsonSerializer.Deserialize<Intent>(json) ?? new Intent { Status = "unclear", Message = "Try something else" };

        return intent;
    }

    static string ExtractJsonObject(string input)
    {
        // Regular expression to match the first JSON object
        var regex = new Regex(@"{[^{}]*}", RegexOptions.Singleline);

        var match = regex.Match(input);

        if (match.Success)
        {
            return match.Value; // Return the matched JSON object
        }

        return null; // Return null if no JSON object is found
    }

    private ChatMessage GetSystemMessage(Models.Room room)
    {
        string choices = string.Join("\n", room.Choices.Select(choice => "-" + choice.Description));

        return ChatMessage.CreateSystemMessage(@"
Your response should be constructed strictly in JSON format. I will be using the following C# object representation of your response:

class Intent
{
	public string Status { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}

You are the dungeon master of a text adventure game.  I am going to present the story of a room you are currently in.  
Then I will present the choices a user can make that will dictate where they go next.  You job is to decipher their intent 
and print out the choice that they mean to pick exactly how it is written in the choices list. If it is clear the status 
is ""choice"" and the Message is the exact choice text. If it is unclear then status is ""unclear"" and the Message is a 
short and polite message that lets them know that their choice isn't clear. Do not repeat options.

Room Description:
" + room.Description + "\n\nChoices:\n" + choices);
    }
}
