using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MinecraftRanksGenerator.Character;

public class CharacterParser
{
    public Character Parse(string path)
    {
        using (Image<Rgba32> image = Image.Load<Rgba32>(path))
            return Parse(image);
    }

    private Character Parse(Image<Rgba32> image)
    {
        PixelType[,] pixels = new PixelType[image.Width + 1, image.Height];
        var characterType = image.Height > 5 ? CharacterType.Tall : CharacterType.Default;

        for (int x = 0; x <= image.Width; x++)
            for (int y = 0; y < image.Height; y++)
                pixels[x, y] = x < image.Width && image[x, y].R == 0 ? PixelType.Solid : PixelType.Empty;

        for (int x = 0; x < image.Width; x++)
            for (int y = 0; y < image.Height; y++)
                if (pixels[x, y] == PixelType.Solid && pixels[x + 1, y] == PixelType.Empty)
                    pixels[x + 1, y] = PixelType.Shadow;

        return new Character(characterType, pixels);
    }
}