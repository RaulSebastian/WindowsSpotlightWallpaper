using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace WindowsSpotlightWallpaper.Extensions
{
    public static class BitmapExtentsions
    {
        public static BitmapData LockAllBitsReadOnly(this Bitmap image)
        {
            return image.LockBits(new Rectangle(0, 0, image.Width - 1, image.Height - 1), ImageLockMode.ReadOnly, image.PixelFormat);
        }

        public static bool Compare(this Bitmap originalImg, Bitmap comparedImg)
        {
            if (originalImg == null || comparedImg == null)
                return false;
            
            var bytes = originalImg.Width * originalImg.Height * (Image.GetPixelFormatSize(originalImg.PixelFormat) / 8);

            var result = true;
            var originalBytes = new byte[bytes];
            var comparedBytes = new byte[bytes];

            var originalData = originalImg.LockAllBitsReadOnly();
            var comparedData = comparedImg.LockAllBitsReadOnly();

            Marshal.Copy(originalData.Scan0, originalBytes, 0, bytes);
            Marshal.Copy(comparedData.Scan0, comparedBytes, 0, bytes);

            for (var n = 0; n <= bytes - 1; n++)
            {
                if (originalBytes[n] == comparedBytes[n])
                    continue;

                result = false;
                break;
            }

            originalImg.UnlockBits(originalData);
            comparedImg.UnlockBits(comparedData);

            return result;
        }

        public static Image ConvertToImage(string pathToFile)
        {
            Image image;

            try
            {
                image = Image.FromFile(pathToFile);
            }
            catch (Exception)
            {
                //error converting file to image returns null
                return null;
            }

            return image;
        }
    }
}