using System;
using OrderEntryDataAccess;
using OrderEntryEngine.Models;
using OrderEntryEngine;
using System.Collections.Generic;


namespace OrderEntrySystem
{
    public class ProductViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// property used to represent a product model
        /// </summary>
        private Product product;

        /// <summary>
        /// property used to represent the repository of products.
        /// </summary>
        private Repository repository;

        /// <summary>
        /// indicator for products selected.
        /// </summary>
        private bool isSelected;

        /// <summary>
        /// initializes a new instance of a product view model.
        /// </summary>
        /// <param name="p">passed in product model</param>
        public ProductViewModel(Product p, Repository repository)
            : base("Product")
        {
            this.repository = repository;
            product = p;
        }

        /// <summary>
        /// gets or sets the location of a product.
        /// </summary>
        public IEnumerable<Location> Locations
        {
            get
            {
                return repository.GetLocations();
            }
        }

        /// <summary>
        /// gets or sets the category of the product.
        /// </summary>
        public IEnumerable<Category> Categories
        {
            get
            {
                return repository.GetCategories();
            }
        }

        /// <summary>
        /// gets or sets the name of a product.
        /// </summary>
        public string Name
        {
            get
            {
                return product.Name;
            }
            set
            {
                product.Name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// gets or sets the descripion of a product.
        /// </summary>
        public string Description
        {
            get
            {
                return product.Description;
            }
            set
            {
                product.Description = value;
                OnPropertyChanged("Description");
            }
        }
        /// <summary>
        /// gets or sets the price of a product.
        /// </summary>
        public decimal Price
        {
            get
            {
                return product.Price;
            }
            set
            {
                product.Price = value;
                OnPropertyChanged("Price");
            }
        }

        
        /// <summary>
        /// gets or sets the value for the private property indicator.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }

            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public void Save()
        {
            repository.AddProduct(product);
            repository.SaveToDatabase();
        }

        /// <summary>
        /// the condition enumeration of the state of a product.
        /// </summary>
        public Condition Condition
        {
            get
            {
                return product.Condition;
            }
            set
            {
                product.Condition = value;
                OnPropertyChanged("Condition");
            }
        }

        /// <summary>
        /// gets the collection of enum values.
        /// </summary>
        public IEnumerable<Condition> Conditions
        {
            get
            {
                return Enum.GetValues(typeof(Condition)) as IEnumerable<Condition>;
            }
        }

        private void OkExecute()
        {
            Save();
            CloseAction(true);
        }

        private void CancelExecute()
        {
            CloseAction(false);
        }

        /// <summary>
        /// override create command method.
        /// </summary>
        protected override void CreateCommands()
        {
            Commands.Add(new CommandViewModel("OK", new DelegateCommand(c => OkExecute())));
            Commands.Add(new CommandViewModel("Cancel", new DelegateCommand(c => CancelExecute())));
        }
    }
}
