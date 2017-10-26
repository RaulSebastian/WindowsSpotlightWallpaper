using System;
using WinSpotlightWallpaperSetter.Model;

namespace WinSpotlightWallpaperSetter.Extensions
{
    public static class ConsoleExtensions
    {
        public static ColoredOutput ColoredOutput(string text, ConsoleColor? foreground = null, ConsoleColor? background = null) 
            => new ColoredOutput(text, foreground, background);

        public static void WriteColored(params ColoredOutput[] strings)
        {
            var initialForeground = Console.ForegroundColor;
            var initialBackground = Console.BackgroundColor;

            foreach (var str in strings)
            {
                Console.ForegroundColor = str.Foreground;
                Console.BackgroundColor = str.Background;
                Console.Write(str.Text);
            }

            Console.ForegroundColor = initialForeground;
            Console.BackgroundColor = initialBackground;
        }
    }
}