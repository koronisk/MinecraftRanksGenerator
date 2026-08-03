using MinecraftRanksGenerator.Character;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MinecraftRanksGenerator.Support;

public record ImageGenerator(Rank rank)
{
    private const int BorderThickness = 1;
    private const int PaddingX = 1;
    private const int TallOverflow = 2;
    private const int BaseCharacterHeight = 5;

    public void SaveAsPng(string path)
    {
        var parser = new CharacterParser();
        var characters = rank.Text
            .Select(c => parser.Parse(GetCharacterAssetPath(c)))
            .ToArray();

        var innerWidth = characters.Sum(c => c.Pixels.GetLength(0));

        var reservedOverflow = Math.Max(TallOverflow - BorderThickness, 0);

        var width = innerWidth + PaddingX * 2 + BorderThickness * 2;
        var height = reservedOverflow + BaseCharacterHeight + BorderThickness * 2;

        var background = rank.Palette.Background;
        var border = rank.Palette.Border;
        var text = rank.Palette.Text;
        var textShadow = rank.Palette.TextShadow;

        using var image = new Image<Rgba32>(width, height);

        for (int x = 0; x < width; x++)
            for (int y = reservedOverflow; y < height; y++)
                image[x, y] = border;

        for (int x = BorderThickness; x < width - BorderThickness; x++)
            for (int y = reservedOverflow + BorderThickness; y < height - BorderThickness; y++)
                image[x, y] = background;

        var cursorX = BorderThickness + PaddingX;

        foreach (var character in characters)
        {
            var charWidth = character.Pixels.GetLength(0);
            var charHeight = character.Pixels.GetLength(1);

            var defaultTopY = reservedOverflow + BorderThickness;
            var topY = character.Type == CharacterType.Tall
                ? defaultTopY - TallOverflow
                : defaultTopY;

            for (int px = 0; px < charWidth; px++)
            {
                for (int py = 0; py < charHeight; py++)
                {
                    var pixelType = character.Pixels[px, py];
                    if (pixelType == PixelType.Empty)
                        continue;

                    image[cursorX + px, topY + py] = pixelType == PixelType.Solid ? text : textShadow;
                }
            }

            cursorX += charWidth;
        }

        image.SaveAsPng(path);
    }

    private static string GetCharacterAssetPath(char character)
    {
        var lower = char.ToLowerInvariant(character);

        return lower switch
        {
            ' ' => "assets/symbols/space.png",
            '+' => "assets/symbols/plus.png",
            '!' => "assets/symbols/exclamation_mark.png",
            (>= 'а' and <= 'я') or 'ё' => $"assets/letters/{lower}.png",
            _ => "assets/symbols/unknown.png"
        };
    }
}
