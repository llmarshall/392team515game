using OrderEntryDataAccess;
using OrderEntryEngine.Models;
using System.Windows.Input;

namespace OrderEntrySystem
{
    public class CustomerViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// property used to represent a customer class.
        /// </summary>
        private Customer customer;

        /// <summary>
        /// indicator for products selected.
        /// </summary>
        private bool isSelected;

        /// <summary>
        /// property used to represent the repository of customers.
        /// </summary>
        private Repository repository;

        /// <summary>
        /// initializes a ne instance.
        /// </summary>
        /// <param name="c">passed in customer</param>
        /// <param name="repository">passed in repository</param>
        public CustomerViewModel(Customer c, Repository repository)
            : base("Customer")
        {
            this.repository = repository;
            customer = c;
        }

        /// <summary>
        /// the method used to save customers to the repository.
        /// </summary>
        public void Save()
        {
            repository.AddCustomers(customer);
            repository.SaveToDatabase();
        }

        /// <summary>
        /// gets or sets the value for the private property indicator.
        /// </summary>
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        /// <summary>
        /// gets or sets the customer first name.
        /// </summary>
        public string FirstName
        {
            get
            {
                return customer.FirstName;
            }

            set
            {
                customer.FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        /// <summary>
        /// gets or sets the customer first name.
        /// </summary>
        public string LastName
        {
            get
            {
                return customer.LastName;
            }

            set
            {
                customer.LastName = value;
                OnPropertyChanged("LastName");
            }
        }

        /// <summary>
        /// gets or sets the customer first name.
        /// </summary>
        public string Phone
        {
            get
            {
                return customer.Phone;
            }

            set
            {
                customer.Phone = value;
                OnPropertyChanged("Phone");
            }
        }

        /// <summary>
        /// gets or sets the customer first name.
        /// </summary>
        public string Email
        {
            get
            {
                return customer.Email;
            }

            set
            {
                customer.Email = value;
                OnPropertyChanged("Email");
            }
        }

        /// <summary>
        /// gets or sets the customer first name.
        /// </summary>
        public string Address
        {
            get
            {
                return customer.Address;
            }

            set
            {
                customer.Address = value;
                OnPropertyChanged("Address");
            }
        }

        /// <summary>
        /// gets or sets the customer first name.
        /// </summary>
        public string City
        {
            get
            {
                return customer.City;
            }

            set
            {
                customer.City = value;
                OnPropertyChanged("City");
            }
        }

        /// <summary>
        /// gets or sets the customer first name.
        /// </summary>
        public string State
        {
            get
            {
                return customer.State;
            }

            set
            {
                customer.State = value;
                OnPropertyChanged("State");
            }
        }

        /// <summary>
        /// the method used to save and close the open window.
        /// </summary>
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
