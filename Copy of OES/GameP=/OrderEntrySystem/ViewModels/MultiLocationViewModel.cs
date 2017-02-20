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
    /// the class used to represent the MultiLocationViewModel.
    /// </summary>
    public class MultiLocationViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// property used to represent the repository.
        /// </summary>
        private Repository repository;

        /// <summary>
        /// initializes a new instance.
        /// </summary>
        /// <param name="repository">the passed in repository.</param>
        public MultiLocationViewModel(Repository repository) : base("Locations List")
        {
            this.repository = repository;

            repository.LocationsAdded += OnLocationAdded;

            IEnumerable<LocationViewModel> locations =
                from l in this.repository.GetLocations()
                select new LocationViewModel(l, this.repository);

            AllLocations = new ObservableCollection<LocationViewModel>(locations);

            foreach (LocationViewModel lvm in AllLocations)
            {
                lvm.PropertyChanged += OnLocationViewModelPropertyChanged;
            }
        }

        /// <summary>
        /// gets or sets all available locations in repository.
        /// </summary>
        public ObservableCollection<LocationViewModel> AllLocations { get; private set; }

        /// <summary>
        /// the method used to add a new location view model.
        /// </summary>
        /// <param name="sender">the object that initiated the event</param>
        /// <param name="e">event argument passed.</param>
        private void OnLocationAdded(object sender, LocationEventArgs e)
        {
            LocationViewModel lvm = new LocationViewModel(e.Location, repository);

            lvm.PropertyChanged += OnLocationViewModelPropertyChanged;

            AllLocations.Add(lvm);
        }

        /// <summary>
        /// the method used check if a property is changed.
        /// </summary>
        /// <param name="sender">the object that initiated the event</param>
        /// <param name="e">the event arguement passed.</param>
        private void OnLocationViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelected")
            {
                base.OnPropertyChanged("NumberOfItemsSelected");
            }
        }

        private void CreateNewLocationExecute()
        {
            ShowLocation(new LocationViewModel(new Location(), repository));
        }

        private void ShowLocation(LocationViewModel lvm)
        {
            WorkspaceWindow wsw = new WorkspaceWindow() { Width = 100, Title = DisplayName };
            lvm.CloseAction = b => wsw.DialogResult = b;
            LocationView lv = new LocationView() { DataContext = lvm };
            wsw.Content = lv;
            wsw.ShowDialog();
        }

        private void EditLocationExecute()
        {
            LocationViewModel viewModel = this.AllLocations.SingleOrDefault(vm => vm.IsSelected);

            if (viewModel != null)
            {
                ShowLocation(viewModel);
                repository.SaveToDatabase();
            }
            else
            {
                MessageBox.Show("Please select only one location.");
            }
        }

        protected override void CreateCommands()
        {
            Commands.Add(new CommandViewModel("New...", new DelegateCommand(c => CreateNewLocationExecute())));
            Commands.Add(new CommandViewModel("Edit...", new DelegateCommand(c => EditLocationExecute())));
        }

        public int NumberOfItemsSelected
        {
            get
            {
                return AllLocations.Count(vm => vm.IsSelected);
            }
        }
    }
}
