using OrderEntryEngine.Models;
using System.Data.Entity;

namespace OrderEntryDataAccess
{
    /// <summary>
    /// the class used to represent OrderEntryContext.
    /// </summary>
    public class OrderEntryContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public OrderEntryContext() : base("OrderEntryContext")
        {
            Database.Initialize(true);
        }

        /// <summary>
        /// gets or sets the products of the oder entry context
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// gets or sets the products of the oder entry context
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// gets or sets the products of the oder entry context
        /// </summary>
        public DbSet<Location> Locations { get; set; }

        /// <summary>
        /// gets or sets the categories of the oder entry context
        /// </summary>
        public DbSet<Category> Categories { get; set; }
    }
}
