using FinistSoftAdmin.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace FinistSoftAdmin.Pages
{
    /// <summary>
    /// Логика взаимодействия для TransactionHistoryPage.xaml
    /// </summary>
    public partial class TransactionHistoryPage : Page
    {
        private TransactionHistoryPageViewModel ViewModel = new TransactionHistoryPageViewModel();
        public TransactionHistoryPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddTransaction();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.UpdateTransaction();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteTransaction();
        }
    }
}
