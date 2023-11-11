using FinistSoftAdmin.ViewModels;
using FinistSoftWebApi.Models;
using System.Windows;

namespace FinistSoftAdmin.Windows
{
    /// <summary>
    /// Логика взаимодействия для ContractWindow.xaml
    /// </summary>
    public partial class ContractWindow : Window
    {
        private readonly ContractWindowViewModel ViewModel;
        public ContractWindow()
        {
            InitializeComponent();
            ViewModel = new ContractWindowViewModel();
            DataContext = ViewModel;
        }
        public ContractWindow(Contract contract)
        {
            InitializeComponent();
            ViewModel = new ContractWindowViewModel(contract);
            DataContext = ViewModel;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SaveChanges())
                DialogResult = true;
        }

    }
}
