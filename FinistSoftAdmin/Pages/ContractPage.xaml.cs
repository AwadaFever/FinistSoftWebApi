using FinistSoftAdmin.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace FinistSoftAdmin.Pages
{
    /// <summary>
    /// Логика взаимодействия для ContractPage.xaml
    /// </summary>
    public partial class ContractPage : Page
    {
        private ContactPageViewModel ViewModel = new ContactPageViewModel();
        public ContractPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddContract();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.UpdateContract();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteContract();
        }
    }
}
