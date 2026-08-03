using SixLabors.ImageSharp.PixelFormats;

namespace MinecraftRanksGenerator;

public record RankPalette(Rgba32 Background, Rgba32 Border, Rgba32 Text, Rgba32 TextShadow)
{
    private const float BorderBrightness = 0.5f;
    private const float ShadowBrightness = 0.6f;

    public static RankPalette FromBackgroundColor(Rgba32 background)
    {
        var border = Darken(background, BorderBrightness);
        var text = new Rgba32(255, 255, 255);
        var textShadow = Darken(background, ShadowBrightness);

        return new RankPalette(background, border, text, textShadow);
    }

    private static Rgba32 Darken(Rgba32 color, float brightness)
    {
        return new Rgba32(
            (byte)(color.R * brightness),
            (byte)(color.G * brightness),
            (byte)(color.B * brightness),
            color.A);
    }
}