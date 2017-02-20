using System.Windows;

namespace OrderEntrySystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void newProductButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel w = DataContext as MainWindowViewModel;
            w.CreateNewProduct();
        }
    }
}
