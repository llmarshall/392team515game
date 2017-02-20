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
    /// the class used to represent the MultiCategoryViewModel 
    /// </summary>
    public class MultiCategoryViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// the property used to represent the repository.
        /// </summary>
        private Repository repository;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="repository">the passed in repository</param>
        public MultiCategoryViewModel(Repository repository) : base("Categories List")
        {
            this.repository = repository;

            this.repository.CategoryAdded += OnCategoryAdded;

            IEnumerable<CategoryViewModel> categories =
                from c in this.repository.GetCategories()
                select new CategoryViewModel(c, this.repository);

            AllCategories = new ObservableCollection<CategoryViewModel>();

            foreach (CategoryViewModel cvm in AllCategories)
            {
                cvm.PropertyChanged += OnCategoryViewModelPropertyChanged;
            }
        }

        /// <summary>
        /// gets or sets the collection of all categories.
        /// </summary>
        public ObservableCollection<CategoryViewModel> AllCategories { get; private set; }

        /// <summary>
        /// the method used to check for updated categories added.
        /// </summary>
        /// <param name="sender">the object that initiated the event.</param>
        /// <param name="e">the event executed against.</param>
        private void OnCategoryAdded(object sender, CategoryEventArgs e)
        {
            CategoryViewModel cvm = new CategoryViewModel(e.Category, repository);

            cvm.PropertyChanged += OnCategoryViewModelPropertyChanged;

            AllCategories.Add(cvm);
        }

        /// <summary>
        /// the method used to check the number of items selected.
        /// </summary>
        /// <param name="sender">the object that initiated the event.</param>
        /// <param name="e">the event being executed against.</param>
        private void OnCategoryViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelected")
            {
                base.OnPropertyChanged("NumberOfItemsSelected");
            }
        }

        /// <summary>
        /// ...
        /// </summary>
        private void CreateNewCategoryExecute()
        {
            ShowCategory(new CategoryViewModel(new Category(), repository));
        }

        private void ShowCategory(CategoryViewModel cvm)
        {
            WorkspaceWindow wsw = new WorkspaceWindow() { Width = 100, Title = DisplayName };
            cvm.CloseAction = b => wsw.DialogResult = b;
            CategoryView cv = new CategoryView() { DataContext = cvm };
            wsw.Content = cv;
            wsw.ShowDialog();
        }

        /// <summary>
        /// the method used to retrieve the list of categories.
        /// </summary>
        private void EditCategoryExecute()
        {
            CategoryViewModel viewModel = AllCategories.SingleOrDefault(vm => vm.IsSelected);

            if (viewModel != null)
            {
                ShowCategory(viewModel);
                repository.SaveToDatabase();
            }
            else
            {
                MessageBox.Show("Please select only one category.");
            }
        }

        /// <summary>
        /// the method used create new commands.
        /// </summary>
        protected override void CreateCommands()
        {
            Commands.Add(new CommandViewModel("New...", new DelegateCommand(c => CreateNewCategoryExecute())));
            Commands.Add(new CommandViewModel("Edit...", new DelegateCommand(c => EditCategoryExecute())));
        }

        /// <summary>
        /// gets the count of all categories in the repository.
        /// </summary>
        public int NumberOfItemsSelected
        {
            get
            {
                return AllCategories.Count(vm => vm.IsSelected);
            }
        }
    }
}
