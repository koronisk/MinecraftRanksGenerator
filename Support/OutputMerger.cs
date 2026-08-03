using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MinecraftRanksGenerator.Support;

public class OutputMerger
{
    public void SaveAsPng(string directory, string path)
    {
        var files = Directory.GetFiles(directory).ToArray();

        var images = files.Select(Image.Load<Rgba32>).ToArray();

        var width = images.Max(i => i.Width);
        var height = images.Sum(i => i.Height) + 2 * (images.Length - 1);

        using var merged = new Image<Rgba32>(width, height);

        var cursorY = 0;
        foreach (var image in images)
        {
            for (int x = 0; x < image.Width; x++)
                for (int y = 0; y < image.Height; y++)
                    merged[x, cursorY + y] = image[x, y];

            cursorY += image.Height + 2;
            image.Dispose();
        }

        merged.SaveAsPng(path);
    }
}
