namespace DeOmschrijver.Configuration;

/// <summary>
/// Configuration options for the Mistral API.
/// </summary>
public class MistralOptions
{
    public const string SectionName = "Mistral";

    /// <summary>
    /// The API key for accessing the Mistral API.
    /// </summary>
    public string ApiKey { get; set; } = string.Empty;
}
