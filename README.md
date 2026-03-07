# De Omschrijver

A CLI tool that rewrites raw property keywords into polished, professional listing descriptions using Mistral (API).

## Features

- 🤖 **AI-Powered Rewriting**: Uses Mistral AI (Le Chat) to transform basic property descriptions into professional listings
- 💭 **Chain-of-Thought**: Optional reasoning output to see how the AI analyzes the property.
- 📝 **Structured Output**: Generates headline, description, highlights, and condition assessment
- 🔄 **Interactive Interface**: User-friendly prompts guide you through the process
- 📁 **File Support**: Load descriptions from text files or type them directly


## Concepts explored 

* **Tokens**: Tokens serve as the smallest individual units that a language model processes, typically representing common sequences of characters such as words or subwords. In order for a language model to comprehend text, it must be converted into numerical representations. This is accomplished by encoding the text into a series of tokens, where each token is assigned a unique numerical index. The process of converting text into tokens is known as tokenization.
* **Few-shot prompting**: Giving the model examples to shape tone, format, and length.
* **Chain-of-thought**: Scaffolding intermediate output to improve quality on complex tasks, and importantly, why it works (more tokens = more context for the final output, no human reasoning). See [link](https://www.ibm.com/think/topics/chain-of-thoughts)
* **Structured outputs**: Using a JSON schema to make responses predictable and parseable.
* **System prompt**: The instruction layer that runs before any user interaction. It sets the model's role, rules, constraints, and behaviour for the entire conversation. The model treats it as higher-trust than user input, which is exactly why prompt injection tries to override it.

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
