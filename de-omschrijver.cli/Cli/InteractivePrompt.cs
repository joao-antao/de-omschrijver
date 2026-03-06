namespace de_omschrijver.cli.Cli;

/// <summary>
/// Provides an interactive prompt-based interface for collecting user input.
/// </summary>
public static class InteractivePrompt
{
    public static void ShowWelcome()
    {
        Console.Clear();
        Console.WriteLine();
        
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("  ██████╗ ███████╗     ██████╗ ███╗   ███╗███████╗ ██████╗██╗  ██╗██████╗ ██╗     ██╗██╗   ██╗███████╗██████╗ ");
        Console.WriteLine("  ██╔══██╗██╔════╝    ██╔═══██╗████╗ ████║██╔════╝██╔════╝██║  ██║██╔══██╗██║     ██║██║   ██║██╔════╝██╔══██╗");
        Console.WriteLine("  ██║  ██║█████╗      ██║   ██║██╔████╔██║███████╗██║     ███████║██████╔╝██║     ██║██║   ██║█████╗  ██████╔╝");
        Console.WriteLine("  ██║  ██║██╔══╝      ██║   ██║██║╚██╔╝██║╚════██║██║     ██╔══██║██╔══██╗██║██   ██║╚██╗ ██╔╝██╔══╝  ██╔══██╗");
        Console.WriteLine("  ██████╔╝███████╗    ╚██████╔╝██║ ╚═╝ ██║███████║╚██████╗██║  ██║██║  ██║██║╚█████╔╝ ╚████╔╝ ███████╗██║  ██║");
        Console.WriteLine("  ╚═════╝ ╚══════╝     ╚═════╝ ╚═╝     ╚═╝╚══════╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝ ╚════╝   ╚═══╝  ╚══════╝╚═╝  ╚═╝");
        Console.ResetColor();
        
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("  ✦ AI-Powered Property Listing Rewriter");
        Console.ResetColor();
        
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("  Transform raw descriptions into professional estate agent copy");
        Console.ResetColor();
        
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("  ─────────────────────────────────────────────────────────────────────────────────────────────────────────────────");
        Console.ResetColor();
        Console.WriteLine();
    }

    public static CliOptions GetUserOptions()
    {
        Console.WriteLine("How would you like to provide the property description?");
        Console.WriteLine("  1. Type it directly");
        Console.WriteLine("  2. Load from a file");
        Console.Write("\nYour choice (1 or 2): ");
        
        var choice = Console.ReadLine()?.Trim();
        
        string? input = null;
        string? filePath = null;

        if (choice == "2")
        {
            Console.Write("\nEnter the file path: ");
            filePath = Console.ReadLine()?.Trim();
            
            if (string.IsNullOrWhiteSpace(filePath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: No file path provided.");
                Console.ResetColor();
                Environment.Exit(1);
            }
            
            if (!File.Exists(filePath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: File '{filePath}' not found.");
                Console.ResetColor();
                Environment.Exit(1);
            }
        }
        else
        {
            Console.WriteLine("\nEnter the raw property description:");
            Console.WriteLine("(Press Enter twice when done)\n");
            
            var lines = new List<string>();
            string? line;
            bool firstEmpty = false;
            
            while (true)
            {
                line = Console.ReadLine();
                
                if (string.IsNullOrEmpty(line))
                {
                    if (firstEmpty) break;
                    firstEmpty = true;
                }
                else
                {
                    firstEmpty = false;
                    lines.Add(line);
                }
            }
            
            input = string.Join(" ", lines).Trim();
            
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: No input provided.");
                Console.ResetColor();
                Environment.Exit(1);
            }
        }

        Console.Write("\nInclude chain-of-thought reasoning in the output? (y/n) [y]: ");
        var reasoningChoice = Console.ReadLine()?.Trim().ToLower();
        bool noReasoning = reasoningChoice is "n" or "no";

        return new CliOptions(input, filePath, noReasoning);
    }

    public static bool AskToContinue()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Would you like to rewrite another property? (y/n): ");
        Console.ResetColor();
        
        var response = Console.ReadLine()?.Trim().ToLower();
        return response is "y" or "yes";
    }
}

