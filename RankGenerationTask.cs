using System.Text.Json.Serialization;

namespace MinecraftRanksGenerator;

public record RankGenerationTask
{
    [JsonPropertyName("text")] public required string Text { get; init; } 
    [JsonPropertyName("bg")] public required string BackgroundHex { get; init; } 
}