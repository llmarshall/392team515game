using System.ComponentModel;

namespace EvolutionEndeavorSystem.Framework
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModel(string displayName)
        {
            DisplayName = displayName;
        }

        public string DisplayName { get; private set; }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
