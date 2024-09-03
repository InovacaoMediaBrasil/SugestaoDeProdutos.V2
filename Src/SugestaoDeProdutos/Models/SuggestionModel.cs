using System.ComponentModel.DataAnnotations;

namespace SugestaoDeProdutos.Models;

/// <summary>
/// Class SuggestionModel.
/// </summary>
public class SuggestionModel
{
    /// <summary>
    /// Gets or sets the name of the store.
    /// </summary>
    /// <value>The name of the store.</value>
    [Required]
    public string StoreName { get; set; }

    /// <summary>
    /// Gets or sets the telephone.
    /// </summary>
    /// <value>The telephone.</value>
    [Required]
    public string Telephone { get; set; }

    /// <summary>
    /// Gets or sets the email address.
    /// </summary>
    /// <value>The email address.</value>
    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; }

    /// <summary>
    /// Gets or sets the suggestion.
    /// </summary>
    /// <value>The suggestion.</value>
    [Required]
    [MaxLength(1024)]
    public string Suggestion { get; set; }
}
