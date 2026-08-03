using System.Text.Json;
using MinecraftRanksGenerator;
using MinecraftRanksGenerator.Support;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

if (Directory.Exists("./output"))
    Directory.Delete("./output", true);

Directory.CreateDirectory("./output");
Directory.CreateDirectory("./output/ranks");

if (!File.Exists("tasks.json")) throw new Exception("tasks.json не найден");

var json = File.ReadAllText("tasks.json");
var tasks = JsonSerializer.Deserialize<List<RankGenerationTask>>(json);

if (tasks is null) return;

tasks.ForEach(x =>
{
    var backgroundColor = Color.ParseHex(x.BackgroundHex).ToPixel<Rgba32>();
    var palette = RankPalette.FromBackgroundColor(backgroundColor);

    var text = x.Text;

    var rank = new Rank(text, palette);

    var generator = new ImageGenerator(rank);
    generator.SaveAsPng($"./output/ranks/{text}.png");
});

var merger = new OutputMerger();
merger.SaveAsPng("./output/ranks", "./output/merged.png");