using System;
using System.Linq;
using WinSpotlightWallpaperSetter.Model;

namespace WinSpotlightWallpaperSetter.Extensions
{
    public static class StringExtensions
    {
        public static bool Contains(this string[] args, Commands command) 
            => args.Contains(command.ToString(), StringComparer.CurrentCultureIgnoreCase);
    }
}