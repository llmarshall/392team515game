using OrderEntryEngine.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace OrderEntryDataAccess
{
    /// <summary>
    /// the class used to represent the orderEntryInitialzer.
    /// </summary>
    public class OrderEntryInitializer : DropCreateDatabaseIfModelChanges<OrderEntryContext>
    {
        /// <summary>
        /// the method used to set the data context.
        /// </summary>
        /// <param name="context"> the passed in context.</param>
        protected override void Seed(OrderEntryContext context)
        {
            // create an object initialized list of categories.
            var categories = new List<Category>
            {
                new Category() { Name =  "Exclusive" },
                new Category() { Name =  "Tier Two Deals" },
                new Category() { Name =  "Cats Pajamas" }
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            // create an object intialized list of customers.
            var locations = new List<Location>
            {
                new Location {  Name = "The Beach", Description = "Storefront", City = "Long Beach", State = "CA"},
                new Location {  Name = "The Warehouse", Description = "Industrial Building", City = "San Pedro", State = "CA"},
                new Location {  Name = "Boulevard", Description = "Storefront", City = "Lakewood", State = "CA"}
            };

            // add the customers to the repository's list of customers as a range.
            context.Locations.AddRange(locations);
            context.SaveChanges();

            // create an object initialized list of products.
            var products = new List<Product>
            {
                new Product { LocateId = 2221152, Name = "Skateboard", Category = new Category() { Name = "Category 1" } },
                new Product { LocateId = 2000152, Name = "Billa-Bong T-shirt",  Category = new Category() { Name = "Category 2" } },
                new Product { LocateId = 2220442, Name = "Nike SB dunk-low Hawaii",  Category = new Category() { Name = "Category 3" } },
            };

            // add the products to the repository's list of products as a range.
            context.Products.AddRange(products);
            context.SaveChanges();

            // create an object intialized list of customers.
            var customers = new List<Customer>
            {
                new Customer { FirstName = "Larry", LastName = "Marshall", Address = "2508 Adriatic Ave", Email = "llmarshall@ntc.edu", Phone = "562-288-7783", City = "Long Beach", State = "California"},
                new Customer { FirstName = "Ursula", LastName = "Cutrier", Address = "3605 Winding Ridge", Email = "ucutrier@gmail.com", Phone = "715-887-3653", City = "Weston", State = "Wisconsin"},
                new Customer { FirstName = "Travis", LastName = "Scott", Address = "4425 Jefferson Court", Email = "tscott@yahoo.com", Phone = "708-478-2253", City = "Boca Raton", State = "Florida"}
            };

            // add the customers to the repository's list of customers as a range.
            context.Customers.AddRange(customers);
            context.SaveChanges();
        }
    }
}
