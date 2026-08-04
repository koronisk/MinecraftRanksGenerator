using MinecraftRanksGenerator.Exts;

namespace MinecraftRanksGenerator;

public static class Assets
{
    private static Dictionary<char, string> CharactersAssets { get; } = new Dictionary<char, string>()
    .AddAll(LoadFrom("assets/letters/ru"))
    .AddAll(LoadFrom("assets/letters/en"))
    .AddAll(LoadFrom("assets/numbers"))
    .AddAll(LoadFrom("assets/custom"))
    .AddAll(LoadSymbols());

    private static Dictionary<char, string> LoadFrom(string path)
    {
        var characters = new Dictionary<char, string>();

        Directory.GetFiles(path).ToList().ForEach(x =>
        {
            var name = x.Split("/").Last().Split(".").First();
            characters.Add(Convert.ToChar(name), x);
        });

        return characters;
    }

    private static Dictionary<char, string> LoadSymbols()
    {
        var characters = new Dictionary<char, string>()
        {
            {'!', "assets/symbols/exclamation_mark.png"},
            {'+', "assets/symbols/plus.png"},
            {' ', "assets/symbols/space.png"}
        };

        return characters;
    }

    public static string GetAssetPath(char name)
    {
        if (CharactersAssets.ContainsKey(name)) return CharactersAssets[name];
        else return "./assets/unknown.png";
    }
}