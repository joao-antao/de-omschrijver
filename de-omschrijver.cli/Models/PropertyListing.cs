using System.Text.Json.Serialization;

namespace de_omschrijver.cli.Models;

/// <summary>
/// Represents a rewritten property listing returned by Claude.
/// </summary>
public record PropertyListing(
    [property: JsonPropertyName("headline")]    string Headline,
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("highlights")]  List<string> Highlights,
    [property: JsonPropertyName("condition")]   string Condition
);

/// <summary>
/// Wraps the parsed listing together with optional chain-of-thought reasoning.
/// </summary>
public record RewriteResult(PropertyListing Listing, string? Reasoning);
