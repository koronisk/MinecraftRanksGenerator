namespace MinecraftRanksGenerator.Exts;

public static class DictionaryExts
{
    public static Dictionary<TKey, TValue> AddAll<TKey, TValue>(this Dictionary<TKey, TValue> target, Dictionary<TKey, TValue> source) where TKey : notnull
    {
        foreach (var kvp in source)
            target[kvp.Key] = kvp.Value;

        return target;
    }
}