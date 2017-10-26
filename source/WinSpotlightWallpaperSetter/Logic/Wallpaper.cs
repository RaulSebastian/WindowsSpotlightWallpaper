using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace WinSpotlightWallpaperSetter.Logic
{
    public static class Wallpaper
    {
        private const int SPI_SETDESKWALLPAPER = 20;
        private const int SPIF_UPDATEINIFILE = 0x01;
        private const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public enum Style
        {
            Tiled = 0,
            Centered = 1,
            Stretched = 2
        }

        public static void Set(string wallpaperPath)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, wallpaperPath, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }
    }
}