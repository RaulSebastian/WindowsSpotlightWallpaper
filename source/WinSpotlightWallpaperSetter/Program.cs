using System;
using System.IO;
using WinSpotlightWallpaperSetter.Extensions;
using WinSpotlightWallpaperSetter.Logic;
using WinSpotlightWallpaperSetter.Model;
using static WinSpotlightWallpaperSetter.Extensions.ConsoleExtensions;

namespace WinSpotlightWallpaperSetter
{
    class Program
    {
        private static readonly string SourcePath = $@"{Environment.GetEnvironmentVariable("LocalAppData")}\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets";
        private static readonly string DestinationPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),"Spotlight");
        private static readonly string TempWallpaperPath = Path.Combine(Path.GetTempPath(), "wallpaper.jpg");

        private const int ImageWidth  = 1920;
        private const int ImageHeight = 1080;
        private const int MinFileSize = 200 * 1024;
        
        private static void Main(string[] args)
        {
            if (args.Contains(Commands.Hide))
            {
                Hide();
            }

            if (args.Contains(Commands.Help) || args.Length == 0)
            {
                WriteColored(
                    ColoredOutput("Run the executable wih any combination of the following commands:",
                        ConsoleColor.White),
                    ColoredOutput(Environment.NewLine),
                    ColoredOutput("   copy", ConsoleColor.Yellow),
                    ColoredOutput(" - copy cached spotlight images to myPictures\\Spotlight folder"),
                    ColoredOutput(Environment.NewLine),
                    ColoredOutput("   set ", ConsoleColor.Yellow),
                    ColoredOutput(" - sets the wallpaper to the current lock screen"),
                    ColoredOutput(Environment.NewLine),
                    ColoredOutput("   hide", ConsoleColor.Yellow),
                    ColoredOutput(" - runs the console hidden"),
                    ColoredOutput(Environment.NewLine),
                    ColoredOutput("   help", ConsoleColor.Yellow),
                    ColoredOutput(" - shows the available commands and description"),
                    ColoredOutput(Environment.NewLine)
                );
            }

            if (args.Contains(Commands.Copy))
            {
                Filesystem.ConvertAndCopyImages(SourcePath, DestinationPath, MinFileSize,
                    new Resolution(ImageWidth, ImageHeight));
                Console.WriteLine($"Images copied.");
            }

            if (args.Contains(Commands.Set))
            {
                File.Copy(Lockscreen.GetLocalPath(), TempWallpaperPath, true);
                Wallpaper.Set(TempWallpaperPath);
                Console.WriteLine($"Wallpaper set.");
            }

            if ((args.Contains(Commands.Help) && !args.Contains(Commands.Hide)) || args.Length == 0)
            {
                WriteColored(ColoredOutput("Press any key to exit.", ConsoleColor.DarkGray));
                Console.ReadKey();
            }
        }
    }
}