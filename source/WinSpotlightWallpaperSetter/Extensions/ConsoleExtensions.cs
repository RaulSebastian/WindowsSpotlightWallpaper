using System;
using System.Runtime.InteropServices;
using WinSpotlightWallpaperSetter.Model;

namespace WinSpotlightWallpaperSetter.Extensions
{
    public static class ConsoleExtensions
    {
        private const int SwHide = 0;
        private const int SwShow = 5;

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

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

        /// <summary>
        /// Hides the current console window
        /// </summary>
        public static void Hide() => ShowWindow(GetConsoleWindow(), SwHide);

        /// <summary>
        /// Shows the current console window
        /// </summary>
        public static void Show() => ShowWindow(GetConsoleWindow(), SwShow);
    }
}