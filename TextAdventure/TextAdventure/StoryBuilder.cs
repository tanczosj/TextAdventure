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

		story.Rooms[Room.Warehouse] = new Models.Room
		{
			RoomId = Room.Warehouse,
            Description = "You wake up on a cold, metal floor, disoriented and alone, with no memory of how you got here—only the eerie hum of an abandoned spaceship that seems to whisper your name, though you can't remember why.",
            Choices = [
                new Choice("Inspect the door", Room.InspectDoor),
                new Choice("Try to figure out where you are and what happened.", "Figure_Out"),
                new Choice("Search for any helpful items", "search")
            ]
		};

		story.Rooms[Room.InspectDoor] = new Models.Room()
		{
			RoomId = Room.InspectDoor,
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
            Description = "As you twist the key the steel door opens to reveal a giant abandoned room. You notice two unlocked wooden doors on each side of the room ",
            Choices = [
                new Choice("Search the room", "SearchOpenRoom"),
                new Choice("Try to figure out where you are and what happened", "FigureOut2")
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
        story.Rooms["FigureOut2"] = new Models.Room()
        {
            RoomId = "FigureOut2",
            Description = "As you are trying to remember what had happened you feel a buzzing on your arm. You look down to see an arm band labeled \"Far-Bot\" ."
        };
        story.Rooms["Death1"] = new Models.Room()
        {
            RoomId = "Death1",
            Description = "You can clearly see the opening back into the large room is within reach.You decide to jump up and grab onto to flooring of the large open room.As you are pulling yourself up your fingers slip and you fall and hit your head against the stone tiled flooring of the cold icolated trap room.The End."
        };
        return story;
	}
}
