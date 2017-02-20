using System;
using System.Windows.Input;

namespace OrderEntrySystem
{
    /// <summary>
    /// the class used to represent the delegate command class.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> command;

        public DelegateCommand(Action<object> command)
        {
            if (command == null)
                throw new NullReferenceException("The command cannot be null.");

            this.command = command;
        }

        /// <summary>
        /// the event used to add a check of the execution.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        /// <summary>
        /// the method used check for execution of the command delegate.
        /// </summary>
        /// <param name="parameter">the passed in event handler.</param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// the method used to execute
        /// </summary>
        /// <param name="parameter">the passed in event handler.</param>
        public void Execute(object parameter)
        {
            command(parameter);
        }
    }
}
