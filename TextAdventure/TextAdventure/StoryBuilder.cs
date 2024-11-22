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

		story.Rooms["warehouse"] = new Room
		{
			RoomId = "warehouse",
            Description = "You are in a warehouse. It is dark.",
            Choices = [
                new Choice("Stack some boxes", "stacked_boxes"),
                new Choice("Leave the warehouse", "leave_warehouse"),
                new Choice("Eat a living dog", "eat_dog"),
                new Choice("Warp Reality", "warp")
            ]
		};

		story.Rooms["stacked_boxes"] = new Room()
		{
			RoomId = "stacked_boxes",
			Description = "You stack boxes so high they fall on you end you die.  The end."
        };
		story.Rooms["leave_warehouse"] = new Room()
		{
			RoomId = "leave_warehouse",
			Description = "You leave the warehouse still alive. It's your lucky day. The end."
        };
		story.Rooms["eat_dog"] = new Room()
		{
			RoomId = "eat_dog",
			Description = "You try eating the dog and it eats you back. Next time don't try to eat a Pitbull."
        };
		story.Rooms["warp"] = new Room()
		{
			RoomId = "warp",
			Description = "You are now sitting in your future career guarding an empty warehouse. Great. Thanks.  The end."
        };



        return story;
	}
}
