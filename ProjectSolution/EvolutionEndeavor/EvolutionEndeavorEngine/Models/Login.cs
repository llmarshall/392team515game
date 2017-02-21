using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations;

namespace EvolutionEndeavorEngine.Models
{
    public class Login
    {
        /// <summary>
        /// the property used to represent the id of the customer.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// gets or sets customer first name.
        /// </summary>
        //[Required]
        //[MaxLength(200)]
        public string Username { get; set; }

        /// <summary>
        /// gets or sets customer last name.
        /// </summary>
        //[Required]
        //[MaxLength(200)]
        public string Password { get; set; }
    }
}
