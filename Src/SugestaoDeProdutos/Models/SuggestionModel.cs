// ***********************************************************************
// Assembly         : SugestaoDeProdutos
// Author           : Guilherme Branco Stracini
// Created          : 07-26-2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 07-26-2020
// ***********************************************************************
// <copyright file="SuggestionModel.cs" company="Guilherme Branco Stracini ME">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.DataAnnotations;

namespace SugestaoDeProdutos.Models
{
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
}
