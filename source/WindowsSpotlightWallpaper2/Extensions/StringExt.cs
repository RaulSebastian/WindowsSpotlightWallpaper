using System;
using System.Linq;
using WindowsSpotlightWallpaper.Model;

namespace WindowsSpotlightWallpaper.Extensions
{
    public static class StringExtensions
    {
        public static bool Contains(this string[] args, Commands command) 
            => args.Contains(command.ToString(), StringComparer.CurrentCultureIgnoreCase);
    }
}