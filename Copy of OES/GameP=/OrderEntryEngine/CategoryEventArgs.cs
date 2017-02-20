using OrderEntryEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntryEngine
{
    /// <summary>
    /// the class used to represent the category event arguements
    /// </summary>
    public class CategoryEventArgs
    {
        /// <summary>
        /// initializes a new instance.
        /// </summary>
        /// <param name="category">the passed in category.</param>
        public CategoryEventArgs(Category category)
        {
            Category = category;
        }

        /// <summary>
        /// gets or private sets the category of the event argument.
        /// </summary>
        public Category Category { get; private set; }
    }
}
