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
        /// Posts the suggestion asynchronous.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult PostSuggestionAsync()
        {
            return Ok();
        }
    }
}
