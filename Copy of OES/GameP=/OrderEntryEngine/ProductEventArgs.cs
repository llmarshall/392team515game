using OrderEntryEngine.Models;

namespace OrderEntryEngine
{
    /// <summary>
    /// the class used to represent the product event arguments.
    /// </summary>
    public class ProductEventArgs
    {
        /// <summary>
        /// initializes a new instance the the ProductEventArgs class.
        /// </summary>
        /// <param name="product">the passed in product.</param>
        public ProductEventArgs(Product product)
        {
            Product = product;
        }

        /// <summary>
        /// gets or sets the product property of the ProductEventArgs class.
        /// </summary>
        public Product Product { get; private set; }
    }
}
