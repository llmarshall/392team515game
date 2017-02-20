using System.ComponentModel.DataAnnotations;

namespace OrderEntryEngine.Models
{
    /// <summary>
    /// the class used to represent the customer.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// the property used to represent the id of the customer.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// gets or sets customer first name.
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string FirstName{ get; set; }

        /// <summary>
        /// gets or sets customer last name.
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string LastName { get; set; }

        /// <summary>
        /// gets or sets customer phone number.
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Phone { get; set; }

        /// <summary>
        /// gets or sets email customer.
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Email { get; set; }

        /// <summary>
        /// gets or sets address customer resides.
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        /// <summary>
        /// gets or sets city customer resides.
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string City { get; set; }

        /// <summary>
        /// gets or sets state customer resides.
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string State { get; set; }
    }
}
