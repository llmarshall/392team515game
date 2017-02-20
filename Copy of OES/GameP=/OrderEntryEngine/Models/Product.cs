using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderEntryEngine.Models
{
    /// <summary>
    /// the class used to represent a product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// the property used to represent the id of the customer.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// gets or sets the location of the product.
        /// </summary>
        public virtual Location Location{ get; set; }

        /// <summary>
        /// gets or sets the category of the product.
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// gets or sets the location id.
        /// </summary>
        public int LocateId { get; set; }

        /// <summary>
        /// gets or sets the category id.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// gets or sets the name of the product.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// gets or sets the description of the product.
        /// </summary>
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        /// <summary>
        /// gets or sets the price of the product.
        /// </summary>
        [Required]
        public decimal Price{ get; set; }

        /// <summary>
        /// the condition enumeration of the state of a product.
        /// </summary>
        public Condition Condition { get; set; }

        
    }
}
