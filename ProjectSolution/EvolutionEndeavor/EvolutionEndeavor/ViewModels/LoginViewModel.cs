using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionEndeavorSystem.ViewModels
{
    public class LoginViewModel : GamespaceViewModel
    {

        public LoginViewModel() 
            : base("Evolution Endeavor")
        {
            // initialize the repository.
        }

        public void InitiateLoginSequence()
        {

        }

        /// <summary>
        /// create a new command to be used as a model.
        /// </summary>
        protected override void CreateCommands()
        {
            Commands.Add(new CommandViewModel("Login", new DelegateCommand(login => InitiateLoginSequence())));
            
        }
    }
}
