using FinistSoftAdmin.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace FinistSoftAdmin.Pages
{
    /// <summary>
    /// Логика взаимодействия для FavoritsPage.xaml
    /// </summary>
    public partial class FavoritsPage : Page
    {
        private readonly FavoritsPageViewModel ViewModel;
        public FavoritsPage()
        {
            InitializeComponent();
            ViewModel = new FavoritsPageViewModel();
            DataContext = ViewModel;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddFavorite();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.UpdateFavorite();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteFavorite();
        }
    }
}
