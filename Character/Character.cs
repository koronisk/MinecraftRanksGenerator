namespace MinecraftRanksGenerator.Character;

public class Character(CharacterType type, PixelType[,] pixels)
{
    public CharacterType Type { get; set; } = type;
    public PixelType[,] Pixels { get; set; } = pixels;
}