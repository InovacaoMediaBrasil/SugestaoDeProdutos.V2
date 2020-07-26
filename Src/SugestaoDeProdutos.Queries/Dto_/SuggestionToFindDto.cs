// ***********************************************************************
// Assembly         : SugestaoDeProdutos.Queries
// Author           : Guilherme Branco Stracini
// Created          : 07-26-2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 07-26-2020
// ***********************************************************************
// <copyright file="SuggestionToFindDto.cs" company="Guilherme Branco Stracini ME">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace SugestaoDeProdutos.Queries
{
    /// <summary>
    /// Class SuggestionToFindDto.
    /// </summary>
    public class SuggestionToFindDto
    {
        /// <summary>
        /// Gets or sets the suggestion identifier.
        /// </summary>
        /// <value>The suggestion identifier.</value>
        public Guid SuggestionId { get; set; }
    }
}
