using de_omschrijver.cli.Models;

namespace de_omschrijver.cli.Cli;

/// <summary>
/// Handles all formatted console output for De Omschrijver.
/// Keeping display logic here means the service and prompt layers
/// have no knowledge of how results are presented.
/// </summary>
public static class ConsoleDisplay
{
    private const int Width = 60;
    private static readonly string Separator = new('═', Width);

    public static void PrintResult(RewriteResult result, string rawInput)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n{Separator}");
        Console.WriteLine("  De Omschrijver - Results");
        Console.WriteLine(Separator);
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n📥 RAW INPUT:");
        Console.ResetColor();
        Console.WriteLine($"  {rawInput}");

        if (result.Reasoning is not null)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n💭 MODEL REASONING:");
            Console.ResetColor();
            foreach (var line in result.Reasoning.Split('\n'))
                Console.WriteLine($"  {line}");
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n📝 REWRITTEN LISTING:");
        Console.ResetColor();
        
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"\n  🏠 {result.Listing.Headline}");
        Console.ResetColor();
        
        Console.WriteLine($"\n  {result.Listing.Description}");
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n  ✅ Highlights:");
        Console.ResetColor();
        foreach (var highlight in result.Listing.Highlights)
            Console.WriteLine($"     • {highlight}");
        
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"\n  🔧 Condition: {result.Listing.Condition}");
        Console.ResetColor();
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n{Separator}\n");
        Console.ResetColor();
    }

    public static void PrintProgress(string message)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"\n⏳ {message}...");
        Console.ResetColor();
    }

    public static void PrintDone()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" ✓ done.");
        Console.ResetColor();
    }
}
