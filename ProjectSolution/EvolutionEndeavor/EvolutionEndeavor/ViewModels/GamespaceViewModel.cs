using EvolutionEndeavorSystem.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvolutionEndeavorSystem.ViewModels
{
    /// <summary>
    /// class used to represent the gamespace view model.
    /// </summary>
    public abstract class GamespaceViewModel : ViewModel
    {
        /// <summary>
        /// property to represent action delegate command.
        /// </summary>
        private DelegateCommand closeCommand;

        /// <summary>
        /// copy of a list of commandViewModels.
        /// </summary>
        private ObservableCollection<CommandViewModel> commands;

        /// <summary>
        /// Initializes a new instance of GamespaceViewModel.
        /// </summary>
        /// <param name="displayName">passed in name to be displayed in view model.</param>
        public GamespaceViewModel(string displayName) 
            : base(displayName)
        {
            CreateCommands();
        }

        /// <summary>
        /// method used to handle button click event.
        /// </summary>
        public event EventHandler RequestClose;

        /// <summary>
        /// Action delegate to call close action.
        /// </summary>
        public Action<bool> CloseAction { get; set; }

        /// <summary>
        /// gets the  close command by creating an action delegate
        /// </summary>
        public ICommand CloseCommand
        {
            get
            {
                closeCommand = new DelegateCommand(p => OnRequestClose());
                return closeCommand;
            }
        }

        /// <summary>
        /// list of command views models
        /// </summary>
        public ObservableCollection<CommandViewModel> Commands
        {
            get
            {
                if (commands == null)
                    commands = new ObservableCollection<CommandViewModel>();

                return commands;
            }
        }

        /// <summary>
        /// protected abstraction of create command method.
        /// </summary>
        protected abstract void CreateCommands();

        /// <summary>
        /// method used to plug view model into event handler.
        /// </summary>
        private void OnRequestClose()
        {
            if (RequestClose != null)
            {
                RequestClose(this, EventArgs.Empty);
            }
        }
    }
}
