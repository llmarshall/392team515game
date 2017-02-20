using OrderEntryEngine;
using OrderEntryDataAccess;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using OrderEntrySystem;
using OrderEntryEngine.Models;
using OrderEntrySystem.ViewModels;

namespace OrderEntrySystem
{
    /// <summary>
    /// class used to represent MainWindowViewModel: ViewModel
    /// </summary>
    public class MainWindowViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// property used to represent list of view models.
        /// </summary>
        private ObservableCollection<WorkspaceViewModel> viewModels;

        /// <summary>
        /// property used to represent the repository of products.
        /// </summary>
        private Repository repository;
        
        /// <summary>
        /// initializes a new instance of MainWindowViewModel.
        /// </summary>
        public MainWindowViewModel()
            : base("Order Entry Systems - Marshall")
        {
            repository = new Repository();
        }

        /// <summary>
        /// the method used to show all producs in the local repository.
        /// </summary>
        public void ShowAllProducts()
        {
            MultiProductViewModel mpv = ViewModels.FirstOrDefault(vm => vm is MultiProductViewModel) as MultiProductViewModel;
            if (mpv == null)
            {
                mpv = new MultiProductViewModel(repository);
                mpv.RequestClose += OnWorkspaceRequestClose;
                ViewModels.Add(mpv);
                // activate view model.
                ActivateViewModel(mpv);
            }
        }

        /// <summary>
        /// the method used to show all the customers in the local repository.
        /// </summary>
        public void ShowAllCustomers()
        {
            MultiCustomerViewModel mcv = ViewModels.FirstOrDefault(vm => vm is MultiCustomerViewModel) as MultiCustomerViewModel;
            if (mcv == null)
            {
                mcv = new MultiCustomerViewModel(repository);
                mcv.RequestClose += OnWorkspaceRequestClose;
                ViewModels.Add(mcv);
                ActivateViewModel(mcv);
            }
        }


        /// <summary>
        /// gets the list of viewmodels.
        /// </summary>
        public ObservableCollection<WorkspaceViewModel> ViewModels
        {
            get
            {
                if (viewModels == null)
                {
                    viewModels = new ObservableCollection<WorkspaceViewModel>();
                }
                return viewModels;
            }
        }

        /// <summary>
        /// the method used to create new locations.
        /// </summary>
        /// <returns></returns>
        public Location CreateNewLocation()
        {
            Location location = new Location()
            {
                Description = "Location"
            };

            LocationViewModel locationViewModel = new LocationViewModel(location, repository);

            locationViewModel.RequestClose += OnWorkspaceRequestClose;

            ViewModels.Add(locationViewModel);

            ActivateViewModel(locationViewModel);

            return location;
        }

        /// <summary>
        /// the method used to show all locations.
        /// </summary>
        public void ShowAllLocations()
        {
            MultiLocationViewModel viewModel = ViewModels.FirstOrDefault(vm => vm is MultiLocationViewModel) as MultiLocationViewModel;

            if (viewModel == null)
                viewModel = new MultiLocationViewModel(repository);

            viewModel.RequestClose += OnWorkspaceRequestClose;

            ViewModels.Add(viewModel);

            ActivateViewModel(viewModel);

        }

        /// <summary>
        /// the method used to show all the categories.
        /// </summary>
        public void ShowAllCategories()
        {
            MultiCategoryViewModel viewModel = this.ViewModels.FirstOrDefault(vm => vm is MultiCategoryViewModel) as MultiCategoryViewModel;

            if (viewModel == null)
                viewModel = new MultiCategoryViewModel(repository);

            viewModel.RequestClose += OnWorkspaceRequestClose;

            ViewModels.Add(viewModel);

            ActivateViewModel(viewModel);

        }

        /// <summary>
        /// creates a new product view model.
        /// </summary>
        /// <returns>product view model</returns>
        public void CreateNewProduct()
        {
            Product product = new Product();
            ProductViewModel viewModel = new ProductViewModel(product, repository);
            viewModel.RequestClose += OnWorkspaceRequestClose;
            ViewModels.Add(viewModel);
            ActivateViewModel(viewModel);
        }

        /// <summary>
        /// creates a new customer view model.
        /// </summary>
        /// <returns>customer view model</returns>
        public void CreateNewCustomer()
        {
            Customer customer = new Customer();
            CustomerViewModel viewModel = new CustomerViewModel(customer, repository);
            viewModel.RequestClose += OnWorkspaceRequestClose;
            ViewModels.Add(viewModel);
            ActivateViewModel(viewModel);
        }

        /// <summary>
        /// returns a current viewModel
        /// </summary>
        /// <param name="vm">passed in view model</param>
        /// <returns>view model</returns>
        public void ActivateViewModel(WorkspaceViewModel vm)
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(viewModels);

            if (collectionView != null)
                collectionView.MoveCurrentTo(vm);
        }

        /// <summary>
        /// Initializes a cast then alters the workspace view model
        /// </summary>
        /// <param name="sender">object initiated request</param>
        /// <param name="e">arguement passed to event handler</param>
        private void OnWorkspaceRequestClose(object sender, EventArgs e){
            ViewModels.Remove((WorkspaceViewModel)sender);
        }

        /// <summary>
        /// create a new command to be used as a model.
        /// </summary>
        protected override void CreateCommands()
        {
            Commands.Add(new CommandViewModel("View all Products", new DelegateCommand(aps => ShowAllProducts())));
            Commands.Add(new CommandViewModel("View all Customers", new DelegateCommand(acs => ShowAllCustomers())));
            Commands.Add(new CommandViewModel("View all Locations", new DelegateCommand(c => ShowAllLocations())));
            Commands.Add(new CommandViewModel("View all Categories", new DelegateCommand(c => ShowAllCategories())));
        }
    }
}
