using System;
using System.Windows.Input;

namespace OrderEntrySystem
{
    /// <summary>
    /// class used to represent the command view model.
    /// </summary>
    public class CommandViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// command interface used to represent a command delegate
        /// </summary>
        private ICommand command;

        /// <summary>
        /// Initializes a new instance of a command view model.
        /// </summary>
        /// <param name="displayName">passed in display name</param>
        /// <param name="command">passed in command delegate</param>
        public CommandViewModel(string displayName, ICommand command)
            : base(displayName)
        {
            if (command == null)
            {
                throw new Exception("command is null");
            }
            Command = command;
        }

        /// <summary>
        /// gets or private sets command delegate.
        /// </summary>
        public ICommand Command
        {
            get
            {
                return command;
            }
            private set
            {
                command = value;
            }
        }

        /// <summary>
        /// override the create commands method.
        /// </summary>
        protected override void CreateCommands()
        {
            //throw new NotImplementedException();
        }
    }
}
