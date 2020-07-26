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

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SugestaoDeProdutos.Commands;
using SugestaoDeProdutos.Models;
using SugestaoDeProdutos.Queries;
using System;
using System.Threading;

namespace SugestaoDeProdutos.Controllers
{
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
        /// Gets the suggestion asynchronous.
        /// </summary>
        /// <param name="suggestionId">The suggestion identifier.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The suggestion identified by the supplied identifier.</returns>
        /// <response code="200">Returns the suggestion data simplified (Id, Date, StoreName properties only).</response>
        /// <response code="404">If the supplied identifier isn't valid.</response>
        [HttpGet("{suggestionId:guid}", Name = nameof(GetSuggestionAsync))]
        [ProducesResponseType(typeof(FoundSuggestionDto), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetSuggestionAsync([FromRoute] Guid suggestionId, CancellationToken cancellationToken)
        {
            var response = new FoundSuggestionDto
                {
                    SuggestionId = suggestionId,
                    Date = DateTime.Now,
                    StoreName = "example store name"
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
        public IActionResult PostSuggestionAsync([FromBody] SuggestionModel model, CancellationToken cancellationToken)
        {
            var response = new CreatedSuggestionDto { SuggestionId = Guid.NewGuid() };

            return CreatedAtRoute(nameof(GetSuggestionAsync), response, response);
        }
    }
}
