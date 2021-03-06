/*
 * ITSE 1430
 * Lab 5
 * John Butler
 * Fall 2021
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nile
{
    /// <summary>Represents a product.</summary>
    public class Product : IValidatableObject
    {
        /// <summary>Gets or sets the unique identifier.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>Never returns null.</value>
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value?.Trim(); }
        }
        
        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value?.Trim(); }
        }

        /// <summary>Gets or sets the price.</summary>
        public decimal Price { get; set; } = 0;      

        /// <summary>Determines if discontinued.</summary>
        public bool IsDiscontinued { get; set; }

        public override string ToString()
        {
            return Name;
        }

        /// <summary> Validates the object. </summary>
        /// <param name="validationContext"> Context of the validation. </param>
        /// <returns> The error, if any. </returns>
        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            if (String.IsNullOrEmpty(Name))
                yield return new ValidationResult("Name is required", new[] { nameof(Name) });

            if (Id < 0)
                yield return new ValidationResult("Id must be greater than or equal to 0", new[] { nameof(Id) });

            if (Price < 0)
                yield return new ValidationResult("Price must be greater than or equal to 0", new[] { nameof(Price) });
        }

        #region Private Members

        private string _name;
        private string _description;
        #endregion
    }
}
