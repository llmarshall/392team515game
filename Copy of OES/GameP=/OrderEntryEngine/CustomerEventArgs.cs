using OrderEntryEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntryEngine
{
    /// <summary>
    /// the class used to represent
    /// </summary>
    public class CustomerEventArgs
    {
        /// <summary>
        /// initializes a new instance the the CustomerEventArgs class.
        /// </summary>
        /// <param name="customer">the passed in customer.</param>
        public CustomerEventArgs(Customer customer)
        {
            Customer = customer;
        }

        /// <summary>
        /// gets or sets the customer property of the CustomerEventArgs class.
        /// </summary>
        public Customer Customer { get; private set; }
    }
}