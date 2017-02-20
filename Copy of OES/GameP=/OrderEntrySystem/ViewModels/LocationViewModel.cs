using OrderEntryDataAccess;
using OrderEntryEngine.Models;
using System.Windows.Input;

namespace OrderEntrySystem.ViewModels
{
    /// <summary>
    /// the class used to represent the location view model.
    /// </summary>
    public class LocationViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// property used to represent instance of the location class.
        /// </summary>
        private Location location;

        /// <summary>
        /// property used to represent instance of the repository class.
        /// </summary>
        private Repository repository;

        /// <summary>
        /// property indicator to represent
        /// </summary>
        private bool isSelected = false;

        public LocationViewModel(Location location, Repository repository)
            : base("Location")
        {
            this.location = location;
            this.repository = repository;
        }

        /// <summary>
        /// the method used to save a location.
        /// </summary>
        private void Save()
        {
            repository.AddLocation(location);
            repository.SaveToDatabase();
        }

        /// <summary>
        /// the indicator to determine whether or not this is selected.
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
        /// gets or sets the name of the location.
        /// </summary>
        public string Name
        {
            get { return location.Name; }
            set
            {
                location.Name = value;
                OnPropertyChanged(location.Name);
            }
        }

        /// <summary>
        /// gets or sets the description of the location.
        /// </summary>
        public string Description
        {
            get { return location.Description; }
            set
            {
                location.Description = value;
                OnPropertyChanged(location.Description);
            }
        }

        /// <summary>
        /// gets or sets the city of the location.
        /// </summary>
        public string City
        {
            get { return location.City; }
            set
            {
                location.City = value;
                OnPropertyChanged(location.City);
            }
        }

        /// <summary>
        /// gets or sets the state of the location.
        /// </summary>
        public string State
        {
            get { return location.State; }
            set
            {
                location.State = value;
                OnPropertyChanged(location.State);
            }
        }

        /// <summary>
        /// the method that saves input information and closes the window.
        /// </summary>
        private void OkExecute()
        {
            Save();
            CloseAction(true);
        }

        /// <summary>
        /// the method used to exit a window without saving.
        /// </summary>
        private void CancelExecute()
        {
            CloseAction(false);
        }

        /// <summary>
        /// the method used to create delegate commands.
        /// </summary>
        protected override void CreateCommands()
        {
            Commands.Add(new CommandViewModel("OK", new DelegateCommand(c => OkExecute())));
            Commands.Add(new CommandViewModel("Cancel", new DelegateCommand(c => CancelExecute())));
        }
    }
}
