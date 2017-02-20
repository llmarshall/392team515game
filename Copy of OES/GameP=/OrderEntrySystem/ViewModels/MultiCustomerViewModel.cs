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
    /// <summary>
    /// class used to represent a multiCustomerViewModel.
    /// </summary>
    public class MultiCustomerViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// property used to represent the repository of customers.
        /// </summary>
        private Repository repository;

        /// <summary>
        /// initializes a new instance
        /// </summary>
        /// <param name="repository">passed in repository</param>
        public MultiCustomerViewModel(Repository repository) : base("All Customers")
        {
            this.repository = repository;

            repository.CustomersAdded += OnCustomerAdded;

            IEnumerable<CustomerViewModel> customers =
                from c in this.repository.GetCustomers()
                select new CustomerViewModel(c, this.repository);

            AllCustomers = new ObservableCollection<CustomerViewModel>(customers);

            foreach (CustomerViewModel cvm in AllCustomers)
            {
                cvm.PropertyChanged += OnCustomerViewModelPropertyChanged;
            }
        }

        /// <summary>
        /// the metho
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCustomerViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelected")
            {
                base.OnPropertyChanged("NumberOfItemsSelected");
            }
        }

        /// <summary>
        /// gets the count of view models selected.
        /// </summary>
        public int NumberOfItemsSelected
        {
            get
            {
                return AllCustomers.Count(vm => vm.IsSelected);
            }
        }

        /// <summary>
        /// gets or private sets the class collection of customers.
        /// </summary>
        public ObservableCollection<CustomerViewModel> AllCustomers { get; private set; }

        /// <summary>
        /// add new product view model to multi product view model observable collection.
        /// </summary>
        /// <param name="sender">object that initiated the event</param>
        /// <param name="e">argument for the event</param>
        private void OnCustomerAdded(object sender, CustomerEventArgs e)
        {
            CustomerViewModel cvm = new CustomerViewModel(e.Customer, repository);

            cvm.PropertyChanged += OnCustomerViewModelPropertyChanged;

            AllCustomers.Add(cvm);
        }

        private void CreateNewCustomerExecute()
        {
            ShowCustomer(new CustomerViewModel(new Customer(), repository));
        }

        private void ShowCustomer(CustomerViewModel cvm)
        {
            WorkspaceWindow wsw = new WorkspaceWindow() { Width = 100, Title = cvm.DisplayName };
            cvm.CloseAction = b => wsw.DialogResult = b;
            CustomerView cv = new CustomerView() { DataContext = cvm };
            wsw.Content = cv;
            wsw.ShowDialog();
        }

        private void EditCustomerExecute()
        {
            CustomerViewModel viewModel = this.AllCustomers.SingleOrDefault(vm => vm.IsSelected);

            if (viewModel != null)
            {
                ShowCustomer(viewModel);
                repository.SaveToDatabase();
            }
            else
            {
                MessageBox.Show("Please select only one customer.");
            }
        }

        /// <summary>
        /// protected method to override the inherited create commands method's.
        /// </summary>
        protected override void CreateCommands()
        {
            Commands.Add(new CommandViewModel("New...", new DelegateCommand(c => CreateNewCustomerExecute())));
            Commands.Add(new CommandViewModel("Edit...", new DelegateCommand(c => EditCustomerExecute())));
        }
    }
}
