using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure.Models;

public class Story
{
	public Dictionary<string, Room> Rooms { get; set; } = new();
}
