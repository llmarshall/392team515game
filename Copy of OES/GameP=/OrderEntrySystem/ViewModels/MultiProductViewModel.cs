using OrderEntryDataAccess;
using OrderEntryEngine;
using OrderEntryEngine.Models;
using OrderEntrySystem.XAML;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace OrderEntrySystem.ViewModels
{
    public class MultiProductViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// property used to represent the repository.
        /// </summary>
        private Repository repository;

        /// <summary>
        /// initializes a new instance.
        /// </summary>
        /// <param name="repository">the passed in repository.</param>
        public MultiProductViewModel(Repository repository)
            : base("All Products")
        {
            this.repository = repository;
            repository.ProductsAdded += OnProductAdded;
            // using linq create a new view model and add them to the observable collection property.
            IEnumerable<ProductViewModel> products =
            from p in repository.GetProducts()
            select new ProductViewModel(p, repository);

            AllProducts = new ObservableCollection<ProductViewModel>(products);

            foreach (var p in AllProducts)
            {
                p.PropertyChanged += OnProductViewModelPropertyChanged;
            }
        }

        /// <summary>
        /// the method used to retrieve all products as a collection.
        /// </summary>
        public ObservableCollection<ProductViewModel> AllProducts { get; private set; }

        /// <summary>
        /// the method that notifies base class of property changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnProductViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelected")
            {
                base.OnPropertyChanged("NumberOfItemsSelected");
            }
        }

        /// <summary>
        /// gets the number of product items selected.
        /// </summary>
        public int NumberOfItemsSelected
        {
            get
            {
                return AllProducts.Count(vm => vm.IsSelected);
            }
        }

        /// <summary>
        /// add new product view model to multi product view model observable collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnProductAdded(object sender, ProductEventArgs e)
        {
            PropertyChanged += OnProductViewModelPropertyChanged;
            AllProducts.Add(new ProductViewModel(e.Product, repository));
        }

        private void CreateNewProductExecute()
        {
            ShowProduct(new ProductViewModel(new Product(), repository));
        }

        private void ShowProduct(ProductViewModel pvm)
        {
            WorkspaceWindow wsw = new WorkspaceWindow() { Width = 100, Title = pvm.DisplayName };
            pvm.CloseAction = b => wsw.DialogResult = b;
            ProductView pv = new ProductView() { DataContext = pvm };
            wsw.Content = pv;
            wsw.ShowDialog();
        }

        private void EditProductExecute()
        {
            ProductViewModel viewModel = AllProducts.SingleOrDefault(vm => vm.IsSelected);

            if (viewModel != null)
            {
                ShowProduct(viewModel);
                repository.SaveToDatabase();
            }
            else
            {
                MessageBox.Show("Please select only one product.");
            }
        }

        /// <summary>
        /// protected method to override the inherited create commands method's.
        /// </summary>
        protected override void CreateCommands()
        {
            // add the new command view for the command delegate getProducts().
            Commands.Add(new CommandViewModel("New...", new DelegateCommand(c => CreateNewProductExecute())));
            Commands.Add(new CommandViewModel("Edit...", new DelegateCommand(c => EditProductExecute())));
        }
    }
}
