using FinistSoftAdmin.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace FinistSoftAdmin.Pages
{
    /// <summary>
    /// Логика взаимодействия для CardsPage.xaml
    /// </summary>
    public partial class CardsPage : Page
    {
        public CardsPageViewModel ViewModel = new CardsPageViewModel();
        public CardsPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddCard();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.UpdateCard();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            ViewModel?.DeleteCard();
        }

    }
}
