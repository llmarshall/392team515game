using OrderEntryDataAccess;
using OrderEntryEngine.Models;

namespace OrderEntrySystem.ViewModels
{
    public class CategoryViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// the property category of the view model.
        /// </summary>
        private Category category;

        /// <summary>
        /// the property used to represent the repository.
        /// </summary>
        private Repository repository;

        /// <summary>
        /// indicator used to represent the selection state.
        /// </summary>
        private bool isSelected = false;

        /// <summary>
        /// initializes a new instance.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="repository"></param>
        public CategoryViewModel(Category category, Repository repository)
            : base("New category")
        {
            this.category = category;
            this.repository = repository;
        }

        public void Save()
        {
            repository.AddCategory(category);
            repository.SaveToDatabase();
        }

        public string Name
        {
            get
            {
                return category.Name;
            }
            set
            {
                category.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
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

        protected override void CreateCommands()
        {
            Commands.Add(new CommandViewModel("OK", new DelegateCommand(c => OkExecute())));
            Commands.Add(new CommandViewModel("Cancel", new DelegateCommand(c => CancelExecute())));
        }
    }
}
