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
		int count = 0;

		var words = message.Split(' ', StringSplitOptions.RemoveEmptyEntries);
		for (int j = 0; j < words.Length; j++) 
		{
			string word = words[j];
			count++;

			if (count + word.Length > 80)
			{
				Console.WriteLine();
				count = 0;
			}

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == '|' && i + 1 < word.Length && IsHexDigit(word[i + 1]))
                {
                    // Change color based on the hex digit
                    char colorCode = word[++i]; // Advance to the hex digit
                    Console.ForegroundColor = GetConsoleColorFromHex(colorCode);
                }
                else
                {
                    count++;
                    // Print the character and delay
                    Console.Write(word[i]);
                    Thread.Sleep(delay);
                }

                if (count == 0 && count % 80 == 0)
                {
                    Console.WriteLine();
                    count = 0;
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keypress = Console.ReadKey(true);

                    if (keypress.Key == ConsoleKey.Spacebar)
                        delay = 0;
                }

            }

			if (j != words.Length - 1)
				Console.Write(" ");
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
