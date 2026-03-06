# De Omschrijver

A CLI tool that rewrites raw property keywords into polished, professional listing descriptions using Mistral (API).

## Features

- 🤖 **AI-Powered Rewriting**: Uses Mistral AI (Le Chat) to transform basic property descriptions into professional listings
- 💭 **Chain-of-Thought**: Optional reasoning output to see how the AI analyzes the property, see (link)[https://www.ibm.com/think/topics/chain-of-thoughts].
- 📝 **Structured Output**: Generates headline, description, highlights, and condition assessment
- 🔄 **Interactive Interface**: User-friendly prompts guide you through the process
- 📁 **File Support**: Load descriptions from text files or type them directly

## Usage

Simply run the application:

```bash
dotnet run
```

## Building

```bash
dotnet build
```

## Requirements

- .NET 10.0 SDK
- Mistral API key (configured via user secrets or environment variables)

## Project Structure

```
de-omschrijver.cli/
├── Program.cs                  # Main entry point with interactive loop
├── Cli/
│   ├── InteractivePrompt.cs   # Interactive user input prompts
│   ├── InputResolver.cs       # Resolves input from various sources
│   ├── ConsoleDisplay.cs      # Formatted output display
│   └── ArgumentParser.cs      # Argument parsing (not used)
├── Services/
│   └── RewriterService.cs     # Mistral AI integration
├── Models/
│   └── PropertyListing.cs     # Data models
├── Prompts/
│   └── PromptBuilder.cs       # AI prompt construction
└── Configuration/
    └── MistralOptions.cs      # Configuration options
```

## Disclaimer

This is a learning project to explore building a CLI tool and learn LLM fundamentals.
