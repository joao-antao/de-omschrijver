/*
 * De Omschrijver
 * ==============
 *
 * Rewrites raw property keywords into polished and professional listing descriptions.
 *
 * Usage:
 *   dotnet run
 */

using de_omschrijver.cli.Cli;
using DeOmschrijver.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<MistralOptions>()
    .Build();

var services = new ServiceCollection()
    .Configure<MistralOptions>(configuration.GetSection(nameof(MistralOptions)))
    .AddOptions()
    .BuildServiceProvider();

var mistralOptions = services.GetRequiredService<IOptions<MistralOptions>>();

// Show welcome screen
InteractivePrompt.ShowWelcome();

// Initialize the service once
var service = new RewriterService(mistralOptions.Value.ApiKey);

// Main loop - allows user to process multiple properties
while (true)
{
    try
    {
        // Get user input interactively
        var options = InteractivePrompt.GetUserOptions();
        
        // Resolve the input (from direct input or file)
        var rawDescription = await InputResolver.ResolveAsync(options);
        if (string.IsNullOrWhiteSpace(rawDescription))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: no input provided.");
            Console.ResetColor();
            continue;
        }

        // Process the request
        ConsoleDisplay.PrintProgress("Rewriting with Mistral (Le Chat)");
        var result = await service.RewriteAsync(rawDescription, includeReasoning: !options.NoReasoning);
        ConsoleDisplay.PrintDone();

        // Display the results
        ConsoleDisplay.PrintResult(result, rawDescription);
        
        // Ask if user wants to continue
        if (!InteractivePrompt.AskToContinue())
            break;
            
        Console.WriteLine();
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\nError: {ex.Message}");
        Console.ResetColor();
        
        if (!InteractivePrompt.AskToContinue())
            break;
    }
}

Console.WriteLine("\nThank you for using De Omschrijver! Goodbye! 👋");
Console.WriteLine();
