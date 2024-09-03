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
/// <summary>
/// Retrieves a suggestion based on the provided suggestion ID.
/// </summary>
/// <param name="suggestionId">The unique identifier of the suggestion to be retrieved.</param>
/// <param name="cancellationToken">A cancellation token to monitor for cancellation requests.</param>
/// <returns>An <see cref="IActionResult"/> containing the suggestion details if found, or a 404 Not Found response if the suggestion does not exist.</returns>
/// <remarks>
/// This method handles HTTP GET requests to retrieve a suggestion identified by the <paramref name="suggestionId"/>.
/// If the suggestion is found, it returns a response with a <see cref="FoundSuggestionDto"/> object containing the suggestion's ID,
/// the current date, and a placeholder store name. If the suggestion cannot be found, it returns a 404 Not Found status.
/// The method is designed to be asynchronous and can be cancelled using the provided <paramref name="cancellationToken"/>.
/// </remarks>
[ApiController]
public class SuggestionController : ControllerBase
{
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

        /// <summary>
        /// Handles the creation of a new suggestion asynchronously.
        /// </summary>
        /// <param name="model">The model containing the details of the suggestion to be created.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the asynchronous operation to complete.</param>
        /// <returns>An <see cref="IActionResult"/> that represents the result of the operation, including the created suggestion's ID.</returns>
        /// <remarks>
        /// This method processes a POST request to create a new suggestion. It generates a unique identifier for the suggestion and returns a response indicating that the suggestion has been successfully created.
        /// If the provided model is invalid, a 400 Bad Request response will be returned.
        /// The method uses the <see cref="CreatedAtRoute"/> method to return a 201 Created status along with the created suggestion's details.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="model"/> is null.</exception>
        return Ok(response);
    }

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
