using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EvolutionEndeavorSystem.ViewModels
{
    /// <summary>
    /// class used to represent MainWindowViewModel: ViewModel
    /// </summary>
    public class MainWindowViewModel : GamespaceViewModel
    {
        /// <summary>
        /// property used to represent list of view models.
        /// </summary>
        private ObservableCollection<GamespaceViewModel> viewModels;

        /// <summary>
        /// property used to represent the repository of data.
        /// </summary>
        //private Repository repository;

        /// <summary>
        /// initializes a new instance of MainWindowViewModel.
        /// </summary>
        public MainWindowViewModel() 
            : base("Evolution Endeavor")
        {
            // initialize the repository

        }

        /// <summary>
        /// gets the list of viewmodels.
        /// </summary>
        public ObservableCollection<GamespaceViewModel> ViewModels
        {
            get
            {
                if (viewModels == null)
                {
                    viewModels = new ObservableCollection<GamespaceViewModel>();
                }
                return viewModels;
            }
        }

        private void GoBack()
        {
            MainWindowViewModel viewModel = ViewModels.Last(vm => vm is MainWindowViewModel) as MainWindowViewModel;

            if (viewModel == null)
                viewModel = new MainWindowViewModel();

            viewModel.RequestClose += OnWorkspaceRequestClose;

            ViewModels.Add(viewModel);

            ActivateViewModel(viewModel);
        }

        /// <summary>
        /// returns a current viewModel
        /// </summary>
        /// <param name="vm">passed in view model</param>
        /// <returns>view model</returns>
        public void ActivateViewModel(GamespaceViewModel vm)
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
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            ViewModels.Remove((GamespaceViewModel)sender);
        }

        /// <summary>
        /// Initializes a cast then alters the workspace view model
        /// </summary>
        /// <param name="sender">object initiated request</param>
        /// <param name="e">arguement passed to event handler</param>
        private void OnGamespaceRequestClose(object sender, EventArgs e)
        {
            ViewModels.Remove((GamespaceViewModel)sender);
        }

        protected override void CreateCommands()
        {
            Commands.Add(new CommandViewModel("Go Back", new DelegateCommand(back => GoBack())));
        }
    }
}
