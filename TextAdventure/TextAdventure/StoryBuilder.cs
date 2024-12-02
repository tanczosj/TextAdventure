using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventure.Models;

namespace TextAdventure;
public class StoryBuilder
{
	public Story Build()
	{
		Story story = new Story();

		story.Rooms[Rooms.Warehouse] = new Models.Room
		{
			RoomId = Rooms.Warehouse,
            Description = "You wake up on a cold, metal floor, disoriented and alone, with no memory of how you got here—only the eerie hum of an abandoned spaceship that seems to whisper your name, though you can't remember why.",
            Choices = [
                new Choice("Inspect the door", Rooms.InspectDoor),
                new Choice("Try to figure out where you are and what happened.", "Figure_Out"),
                new Choice("Search for any helpful items", "search")
            ]
		};

		story.Rooms[Rooms.InspectDoor] = new Models.Room()
		{
			RoomId = Rooms.InspectDoor,
			Description = "You walk up to the metal door and inspect it. You notice it has a lock near the center",
            Choices = [
                new Choice("Try to figure out where you are and what happened.", "Figure_Out"),
                new Choice("Search for any helpful items", "search")
            ]
        };

		story.Rooms["Figure_Out"] = new Models.Room()
		{
			RoomId = "Figure_Out",
			Description = "You try to reccolect past events but nothing else comes to your mind."
        };
		story.Rooms["search"] = new Models.Room()
		{
			RoomId = "search",
			Description = "You search around the empty room and find a metal key",
            Choices = [
                new Choice("Use the key on the door", "Unlock"),
                new Choice("Chuck the key", "ChuckTheKey")
            ]
        };
        story.Rooms["Unlock"] = new Models.Room()
        {
            RoomId = "Unlock",
            Description = "As you twist the key the steel door opens to reveal a giant abandoned room. You notice two unlocked steel doors on each side of the room ",
            Choices = [
                new Choice("Search the room", "SearchOpenRoom"),
                new Choice("Enter the first door", "Door1"),
                new Choice("Enter the second door", "Door2")
            ]
        };
        story.Rooms["ChuckTheKey"] = new Models.Room()
        {
            RoomId = "ChuckTheKey",
            Description = "You throw the key away.As you look around you realize you lost the key!You end up rotting in that room for the rest of eternity."
        };
        story.Rooms["SearchOpenRoom"] = new Models.Room()
        {
            RoomId = "SearchOpenRoom",
            Description = "As you search the huge open room you feel a sudden pressure under your foot... You've stepped on a trap door! You end up falling into a dark secluded room",
            Choices = [
                new Choice("Open the door and go to the next room", "SearchOpenRoom"),
                new Choice("Try to climb out of the trap room", "Death1")
            ]
        };
        story.Rooms["Door1"] = new Models.Room()
        {
            RoomId = "Door1",
            Description = "You walk into room one and look around. The room is a messy blank white room with one TV screen hanging against the wall. Suddenly the steel door slams shut behind you and locks. You are trapped in this room. The TV screen flickers on showing what appears to be a man wearing a shattered fighter jet mask.After just a moment of silent the dull figure begins to speak \"Hello there... We haven't had visitors in a while now. I want to make sure you remember this visit. In front of you are two doors one will lead to your end... the other will lead to prosperity\"",
            Choices = [
                new Choice("Open door one", "CorrectDoor"),
                new Choice("Open door two", "Death2"),
                new Choice("Stop", "Stop2")
                ]
        };
        story.Rooms["Death1"] = new Models.Room()
        {
            RoomId = "Death1",
            Description = "You can clearly see the opening back into the large room is within reach.You decide to jump up and grab onto to flooring of the large open room.As you are pulling yourself up your fingers slip and you fall and hit your head against the stone tiled flooring of the cold icolated trap room.The End."
        };
        story.Rooms["Death2"] = new Models.Room()
        {
            RoomId = "Death2",
            Description = "You open the door and get launched out into space. The End."
        };
        story.Rooms["Door2"] = new Models.Room()
        {
            RoomId = "Door2",
            Description = "You walk into room one and look around. The room is a messy blank white room with one TV screen hanging against the wall. Suddenly the steel door slams shut behind you and locks. You are trapped in this room. The TV screen flickers on showing what appears to be a man wearing a shattered fighter jet mask. After a just a moment of silent the dull figure begins to speak \"Hello there... We haven't had visitors in a while now. I want to make sure you remember this visit\""
        };
        story.Rooms["CorrectDoor"] = new Models.Room()
        {
            RoomId = "CorrectDoor",
            Description = "You open the door and see piles upon piles of gold.On top of all of that you see a rocket you could use to get home.You use the rocket and safley make it back to Earth"
        };
        story.Rooms["Stop"] = new Models.Room()
        {
            RoomId = "Stop",
            Description = "You pause to figure out what is going on."
        };
        return story;
	}
}
