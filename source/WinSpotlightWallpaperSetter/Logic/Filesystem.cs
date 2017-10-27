using System;
using System.Drawing;
using System.IO;
using System.Linq;
using WinSpotlightWallpaperSetter.Extensions;
using WinSpotlightWallpaperSetter.Model;

namespace WinSpotlightWallpaperSetter.Logic
{
    public static class Filesystem
    {
        public static void ConvertAndCopyImages(string sourcePath, string destinationPath, int minFileSize, Resolution matchingResolution)
        {
            if(!Directory.Exists(sourcePath))
                return;

            var firstLoad = !Directory.Exists(destinationPath);

            if (firstLoad)
                Directory.CreateDirectory(destinationPath);

            firstLoad = !Directory.EnumerateFiles(destinationPath).Any();

            foreach (var filepath in Directory.EnumerateFiles(sourcePath))
            {
                if (new FileInfo(filepath).Length < minFileSize)
                    continue;

                var image = BitmapExtentsions.ConvertToImage(filepath);

                if(image == null)
                    continue;

                if (image.Size.Width != matchingResolution.Width || image.Size.Height != matchingResolution.Height)
                    continue;

                var fileAlreadyInDestination = !firstLoad && Directory.EnumerateFiles(destinationPath)
                                                   .Any(existingImages => ((Bitmap) image).Compare(
                                                       (Bitmap) Image.FromFile(existingImages)));

                if (fileAlreadyInDestination)
                    continue;

                var filename = $"{DateTime.Now:yyyyMMddHHmmssfff}.jpg";
                File.Copy(filepath, Path.Combine(destinationPath, filename));
                Console.WriteLine($"{filename} copied.");
            }
        }
    }
}