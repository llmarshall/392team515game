using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntryEngine.Models
{
    /// <summary>
    /// the class used to represent location
    /// </summary>
    public class Location
    {
        /// <summary>
        /// the property used to represent the id of the customer.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// property to represent a list of products.
        /// </summary>
        public virtual List<Product> Products { get; set; }

        /// <summary>
        /// gets or sets the name of the location class.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// gets or sets the description of the location class.
        /// </summary>
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        /// <summary>
        /// gets or sets the city of the location class.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        /// <summary>
        /// gets or sets the state of the location class.
        /// </summary>
        [Required]
        [MaxLength(2)]
        public string State { get; set; }

        /// <summary>
        /// gets or sets the string of the type location class.
        /// </summary>
        public override string ToString()
        {
            return Name;
        }
    }
}
