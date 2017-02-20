using OrderEntryEngine;
using OrderEntryEngine.Models;
using System;
using System.Collections.Generic;

namespace OrderEntryDataAccess
{
    /// <summary>
    /// the class used to represent the repository.
    /// </summary>
    public class Repository
    {
        /// <summary>
        /// property used to represent a new orderentrycontext.
        /// </summary>
        private OrderEntryContext context = new OrderEntryContext();

        /// <summary>
        /// the event used to handle products added to the local repository.
        /// </summary>
        public event EventHandler<ProductEventArgs> ProductsAdded;

        /// <summary>
        /// the event used to handle products added to the local repository.
        /// </summary>
        public event EventHandler<CustomerEventArgs> CustomersAdded;

        /// <summary>
        /// the event used to handle locations added to the local repository
        /// </summary>
        public event EventHandler<LocationEventArgs> LocationsAdded;

        ///// <summary>
        ///// the event used to handle categories added to the local repository.
        ///// </summary>
        public event EventHandler<CategoryEventArgs> CategoryAdded;

        /// <summary>
        /// initializes a new instance of the repository class.
        /// </summary>
        public Repository()
        {
        }

        /// <summary>
        /// the method used to save all changes to the local database.
        /// </summary>
        public void SaveToDatabase() { context.SaveChanges(); }

        public Product GetProduct(int id)
        {
            return context.Products.Find(id);
        }

        public Customer GetCustomer(int id)
        {
            return context.Customers.Find(id);
        }

        public Location GetLocation(int id)
        {
            return context.Locations.Find(id);
        }

        private bool ContainsProduct(Product product)
        {
            return GetProduct(product.Id) != null;
        }

        private bool ContainsCustomer(Customer customer)
        {
            return GetCustomer(customer.Id) != null;
        }

        private bool ContainsLocation(Location location)
        {
            return GetLocation(location.Id) != null;
        }

        private bool ContainsCategory(Category category)
        {
            return GetLocation(category.Id) != null;
        }

        /// <summary>
        /// the method used to retireve a copy of the private list of categories from the repository.
        /// </summary>
        /// <returns></returns>
        public List<Category> GetCategories()
        {
            return new List<Category>(context.Categories);
        }

        /// <summary>
        /// the method used to retrieve a copy of the private list of products from the repository.
        /// </summary>
        /// <returns></returns>
        public List<Location> GetLocations()
        {
            return new List<Location>(context.Locations);
        }

        /// <summary>
        /// the method used to retrieve a copy of the private list of products from the repository.
        /// </summary>
        /// <returns>copy of this list of products.</returns>
        public List<Product> GetProducts()
        {
            return new List<Product>(context.Products);
        }

        /// <summary>
        /// the method used to retrieve a copy of the private list of products from the repository.
        /// </summary>
        /// <returns>copy of this list of products.</returns>
        public List<Customer> GetCustomers()
        {
            return new List<Customer>(context.Customers);
        }

        /// <summary>
        /// the method used to add products to the repository.
        /// </summary>
        /// <param name="product">the passed in product</param>
        public void AddProduct(Product product)
        {
            if (!ContainsProduct(product))
            {
                context.Products.Add(product);

                //check to see if the local event is not null.
                if (ProductsAdded != null)
                {
                    ProductsAdded(this, new ProductEventArgs(product));
                }
            }
        }

        /// <summary>
        /// the method used to add categories to the repository.
        /// </summary>
        /// <param name="category"></param>
        public void AddCategory(Category category)
        {
            if (!ContainsCategory(category))
            {
                context.Categories.Add(category);

                if (CategoryAdded != null)
                {
                    CategoryAdded(this, new CategoryEventArgs(category));
                }
            }
        }

        /// <summary>
        /// the method used to add customers to the repository.
        /// </summary>
        /// <param name="customer">the passed in customer</param>
        public void AddCustomers(Customer customer)
        {
            if (!ContainsCustomer(customer))
            {
                context.Customers.Add(customer);

                //check to see if the local event is not null.
                if (CustomersAdded != null)
                {
                    CustomersAdded(this, new CustomerEventArgs(customer));
                }
            }
        }

        /// <summary>
        /// the method used to add locations to the repository.
        /// </summary>
        /// <param name="customer">the passed in customer</param>
        public void AddLocation(Location location)
        {
            if (!ContainsLocation(location))
            {
                context.Locations.Add(location);

                if (LocationsAdded != null)
                {
                    LocationsAdded(this, new LocationEventArgs(location));
                }
            }
        }
    }
}
