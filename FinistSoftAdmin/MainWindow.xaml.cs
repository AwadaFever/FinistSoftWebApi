using FinistSoftAdmin.Pages;
using FinistSoftAdmin.ViewModels;
using System.Windows;

namespace FinistSoftAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel ViewModel = new MainWindowViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }

        private void openUserButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CurrentPage = new UserPage();
        }

        private void openContractButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CurrentPage = new ContractPage();
        }

        private void openCardsButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CurrentPage = new CardsPage();
        }

        private void openTransactionHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CurrentPage = new TransactionHistoryPage();
        }

        private void openFavoritesButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CurrentPage = new FavoritsPage();
        }

        private void fillDataButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.FillStartData();
        }
    }
}
