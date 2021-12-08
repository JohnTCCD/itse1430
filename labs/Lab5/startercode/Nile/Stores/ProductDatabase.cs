/*
 * ITSE 1430
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public abstract class ProductDatabase : IProductDatabase
    {        
        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        public Product Add ( Product product )
        {
            //TODO: Check arguments
            if (product == null)
                throw new ArgumentNullException("Product is null.");

            //TODO: Validate product
            var context = new ValidationContext(product);
            var validation = product.Validate(context);
            if (validation == null)
                throw new ValidationException("Product is not valid.");

            var existing = FindByName(product.Name);
            if (existing != null)
                throw new InvalidOperationException("Product must have unique name.");

            //Emulate database by storing copy
            return AddCore(product);
        }

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        public Product Get ( int id )
        {
            //TODO: Check arguments
            if (id < 0)
                throw new ArgumentOutOfRangeException("Id must be equal to or greater than 0.");

            return GetCore(id);
        }
        
        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        public IEnumerable<Product> GetAll ()
        {
            return GetAllCore();
        }
        
        /// <summary>Removes the product.</summary>
        /// <param name="id">The product to remove.</param>
        public void Remove ( int id )
        {
            //TODO: Check arguments
            if (id < 0)
                throw new ArgumentOutOfRangeException("Id must be equal to or greater than 0.");

            RemoveCore(id);
        }
        
        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        public Product Update ( Product product)
        {
            //TODO: Check arguments
            if (product == null)
                throw new ArgumentNullException("Product is null.");

            //TODO: Validate product
            var context = new ValidationContext(product);
            var validation = product.Validate(context);
            if (validation == null)
                throw new ValidationException("Product is not valid.");

            //Get existing product
            var existing = GetCore(product.Id);
            var changed = false;

            if (existing.Price != product.Price || existing.Description.CompareTo(product.Description) != 0 ||
                existing.IsDiscontinued != product.IsDiscontinued)
                changed = true;

            var sameName = FindByName(product.Name);
            if (sameName != null && !changed)
                throw new InvalidOperationException("Product must have unique name.");

            

            return UpdateCore(existing, product);
        }

        #region Protected Members

        protected abstract Product GetCore( int id );

        protected abstract IEnumerable<Product> GetAllCore();

        protected abstract void RemoveCore( int id );

        protected abstract Product UpdateCore( Product existing, Product newItem );

        protected abstract Product AddCore( Product product );

        protected abstract Product FindByName ( string name );
        #endregion
    }
}
