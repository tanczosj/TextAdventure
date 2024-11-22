using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure.Models;

public class Room
{
    public string RoomId { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Choice> Choices { get; set; } = new();
}
