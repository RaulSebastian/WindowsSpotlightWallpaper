using System;

namespace WindowsSpotlightWallpaper.Model
{
    public struct ColoredOutput
    {
        public ConsoleColor Foreground;
        public ConsoleColor Background;
        public string Text;

        public ColoredOutput(string text, ConsoleColor? foreground = null, ConsoleColor? background = null)
        {
            Foreground = foreground ?? Console.ForegroundColor;
            Background = background ?? Console.BackgroundColor;
            Text = text;
        }
    }

}