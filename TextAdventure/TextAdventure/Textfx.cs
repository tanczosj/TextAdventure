using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure;
internal static class Textfx
{
	public static void Type(string message, int delay = 50)
	{
		for (int i = 0; i < message.Length; i++)
		{
			if (message[i] == '|' && i + 1 < message.Length && IsHexDigit(message[i + 1]))
			{
				// Change color based on the hex digit
				char colorCode = message[++i]; // Advance to the hex digit
				Console.ForegroundColor = GetConsoleColorFromHex(colorCode);
			}
			else
			{
				// Print the character and delay
				Console.Write(message[i]);
				Thread.Sleep(delay);
			}

			if (i != 0 && i % 80 == 0) 
				Console.WriteLine();

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keypress = Console.ReadKey(true);

                if (keypress.Key == ConsoleKey.Spacebar)
                    delay = 0;
            }

        }
	}

	private static bool IsHexDigit(char c) =>
		(c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f');

	private static ConsoleColor GetConsoleColorFromHex(char hex)
	{
		return hex switch
		{
			'0' => ConsoleColor.Black,
			'1' => ConsoleColor.DarkBlue,
			'2' => ConsoleColor.DarkGreen,
			'3' => ConsoleColor.DarkCyan,
			'4' => ConsoleColor.DarkRed,
			'5' => ConsoleColor.DarkMagenta,
			'6' => ConsoleColor.DarkYellow,
			'7' => ConsoleColor.Gray,
			'8' => ConsoleColor.DarkGray,
			'9' => ConsoleColor.Blue,
			'A' or 'a' => ConsoleColor.Green,
			'B' or 'b' => ConsoleColor.Cyan,
			'C' or 'c' => ConsoleColor.Red,
			'D' or 'd' => ConsoleColor.Magenta,
			'E' or 'e' => ConsoleColor.Yellow,
			'F' or 'f' => ConsoleColor.White,
			_ => Console.ForegroundColor // Default to current color if invalid
		};
	}

    public static void TypeLine(string message, int delay = 50) => Type(message + "\n", delay);
}
