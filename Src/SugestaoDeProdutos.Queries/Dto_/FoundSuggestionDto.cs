using System;

namespace SugestaoDeProdutos.Queries;

/// <summary>
/// Class FoundSuggestionDto.
/// </summary>
public class FoundSuggestionDto
{
    /// <summary>
    /// Gets or sets the suggestion identifier.
    /// </summary>
    /// <value>The suggestion identifier.</value>
    public Guid SuggestionId { get; set; }

    /// <summary>
    /// Gets or sets the date.
    /// </summary>
    /// <value>The date.</value>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the name of the store.
    /// </summary>
    /// <value>The name of the store.</value>
    public string StoreName { get; set; }
}
