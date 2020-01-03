using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;

namespace Blog.WebUI.Helpers.Images
{
    public class Tools
    {
        public static void RASImage(Stream stream, string filename, int hight, int with)
        {
            using (Image<Rgba32> image = Image.Load(stream))
            {
                image.Mutate(x => x
                .Resize(hight, with, false)

                 );
                image.Save(filename);
            }


        }

        public static string RNImage(string Name)
        {
            return Guid.NewGuid() + Path.GetExtension(Name);
        }
    }
}
