using Microsoft.Win32;

namespace WindowsSpotlightWallpaper.Logic
{
    public static class Lockscreen
    {
        private const string CurentLockScreenRegistryPath =
            @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Lock Screen\Creative";

        public static string GetLocalPath()
               => (string)Registry.GetValue(CurentLockScreenRegistryPath, "LandscapeAssetPath", null);
    }
}