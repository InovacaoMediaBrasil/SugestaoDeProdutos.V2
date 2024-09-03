using System;

namespace SugestaoDeProdutos.Commands;

/// <summary>
/// Class SuggestionToCreateDto.
/// </summary>
public class SuggestionToCreateDto
{
    /// <summary>
    /// Gets or sets the name of the store.
    /// </summary>
    /// <value>The name of the store.</value>
    public string StoreName { get; set; }

    /// <summary>
    /// Gets or sets the referer.
    /// </summary>
    /// <value>The referer.</value>
    public string Referer { get; set; }

    /// <summary>
    /// Gets or sets the client email.
    /// </summary>
    /// <value>The client email.</value>
    public string ClientEmail { get; set; }

    /// <summary>
    /// Gets or sets the telephone.
    /// </summary>
    /// <value>The telephone.</value>
    public string Telephone { get; set; }

    /// <summary>
    /// Gets or sets the suggestion.
    /// </summary>
    /// <value>The suggestion.</value>
    public string Suggestion { get; set; }

    /// <summary>
    /// Gets or sets the date.
    /// </summary>
    /// <value>The date.</value>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the ip address.
    /// </summary>
    /// <value>The ip address.</value>
    public string IpAddress { get; set; }

    /// <summary>
    /// Gets or sets the user agent.
    /// </summary>
    /// <value>The user agent.</value>
    public string UserAgent { get; set; }
}
