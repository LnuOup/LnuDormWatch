using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LDW.WebAPI.Helpers
{
    public class ImageHelper
    {
        public static bool IsImage(IFormFile file)
        {
            if (file.ContentType.Contains("image"))
            {
                return true;
            }

            string[] formats = new string[] { ".jpg", ".png", ".gif", ".jpeg" };

            return formats.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
        }

        public static Stream CompressPhoto(Stream imageStream, int imageMaxSize, string fileType)
        {
            var encoder = GetEncoder(fileType);

            if (encoder != null)
            {
                var output = new MemoryStream();
                using (var image = Image.Load<Rgba32>(imageStream))
                {
                    int newWidth = 0;
                    int newHeight = 0;

                    if (image.Width >= image.Height)
                    {
                        newWidth = imageMaxSize;

                        double divisor = (double)image.Width / imageMaxSize;
                        if (divisor == 0)
                        {
                            divisor = 1;
                        }

                        newHeight = Convert.ToInt32(Math.Round((decimal)(image.Height / divisor)));
                    }
                    else
                    {
                        newHeight = imageMaxSize;

                        double divisor = (double)image.Height / imageMaxSize;
                        if (divisor == 0)
                        {
                            divisor = 1;
                        }

                        newWidth = Convert.ToInt32(Math.Round((decimal)(image.Width / divisor)));
                    }

                    image.Mutate(x => x.Resize(newWidth, newHeight));
                    image.Save(output, encoder);
                    output.Position = 0;
                    return output;
                }
            }

            return null;
        }

        private static IImageEncoder GetEncoder(string extension)
        {
            IImageEncoder encoder = null;

            extension = extension.Replace(".", "").ToLower();

            var isSupported = Regex.IsMatch(extension, "gif|png|jpe?g", RegexOptions.IgnoreCase);

            if (isSupported)
            {
                switch (extension)
                {
                    case "png":
                        encoder = new PngEncoder();
                        break;
                    case "jpg":
                        encoder = new JpegEncoder();
                        break;
                    case "jpeg":
                        encoder = new JpegEncoder();
                        break;
                    case "gif":
                        encoder = new GifEncoder();
                        break;
                    default:
                        break;
                }
            }

            return encoder;
        }
    }
}
