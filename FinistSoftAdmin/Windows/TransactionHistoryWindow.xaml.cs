using FinistSoftAdmin.ViewModels;
using FinistSoftWebApi.Models;
using System.Windows;

namespace FinistSoftAdmin.Windows
{
    /// <summary>
    /// Логика взаимодействия для TransactionHistoryWindow.xaml
    /// </summary>
    public partial class TransactionHistoryWindow : Window
    {
        private readonly TransactionHistoryWindowViewModel ViewModel;

        public TransactionHistoryWindow()
        {
            InitializeComponent();
            ViewModel = new TransactionHistoryWindowViewModel();
            DataContext = ViewModel;
        }
        public TransactionHistoryWindow(TransactionHistory transactionHistory)
        {
            InitializeComponent();
            ViewModel = new TransactionHistoryWindowViewModel(transactionHistory);
            DataContext = ViewModel;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SaveChanges())
                DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
