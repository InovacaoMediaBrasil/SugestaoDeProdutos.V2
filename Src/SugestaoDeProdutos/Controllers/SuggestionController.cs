// ***********************************************************************
// Assembly         : SugestaoDeProdutos
// Author           : Guilherme Branco Stracini
// Created          : 07-26-2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 07-26-2020
// ***********************************************************************
// <copyright file="SuggestionController.cs" company="Guilherme Branco Stracini ME">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SugestaoDeProdutos.Commands;
using SugestaoDeProdutos.Models;
using SugestaoDeProdutos.Queries;

namespace SugestaoDeProdutos.Controllers;

/// <summary>
/// Class SuggestionController.
/// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
/// </summary>
/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
[Produces("application/json")]
[Route("")]
[ApiController]
public class SuggestionController : ControllerBase
{
    /// <summary>
    /// Retrieves a suggestion by its unique identifier.
    /// </summary>
    /// <param name="suggestionId">The unique identifier of the suggestion to retrieve.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>An <see cref="IActionResult"/> containing the found suggestion or a 404 Not Found response if the suggestion does not exist.</returns>
    /// <remarks>
    /// This method handles HTTP GET requests to retrieve a suggestion based on the provided <paramref name="suggestionId"/>.
    /// If the suggestion is found, it returns an instance of <see cref="FoundSuggestionDto"/> with the suggestion details,
    /// including the suggestion ID, the current date, and a placeholder store name.
    /// If no suggestion is found for the given ID, it returns a 404 Not Found response.
    /// The method is designed to be asynchronous and can be cancelled using the provided <paramref name="cancellationToken"/>.
    /// </remarks>
    [HttpGet("{suggestionId:guid}", Name = nameof(GetSuggestionAsync))]
    [ProducesResponseType(typeof(FoundSuggestionDto), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetSuggestionAsync(
        [FromRoute] Guid suggestionId,
        CancellationToken cancellationToken
    )
    {
        var response = new FoundSuggestionDto
        {
            SuggestionId = suggestionId,
            Date = DateTime.Now,
            StoreName = "example store name",
        };

        return Ok(response);
    }

    /// <summary>
    /// Posts the suggestion asynchronous.
    /// </summary>
    /// <param name="model">The suggestion model.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A newly created Suggestion.</returns>
    /// <response code="201">Returns the newly created suggestion identifier.</response>
    /// <response code="400">If the model or any required property of the model is null/empty</response>
    [HttpPost]
    [ProducesResponseType(typeof(CreatedSuggestionDto), 201)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult PostSuggestionAsync(
        [FromBody] SuggestionModel model,
        CancellationToken cancellationToken
    )
    {
        var response = new CreatedSuggestionDto { SuggestionId = Guid.NewGuid() };

        return CreatedAtRoute(nameof(GetSuggestionAsync), response, response);
    }
}
