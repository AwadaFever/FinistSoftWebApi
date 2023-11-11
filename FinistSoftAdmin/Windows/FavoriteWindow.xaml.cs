using FinistSoftAdmin.ViewModels;
using FinistSoftWebApi.Models;
using System.Windows;

namespace FinistSoftAdmin.Windows
{
    /// <summary>
    /// Логика взаимодействия для FavoriteWindow.xaml
    /// </summary>
    public partial class FavoriteWindow : Window
    {
        private readonly FavouriteWindowViewModel ViewModel;
        public FavoriteWindow()
        {
            InitializeComponent();
            ViewModel = new FavouriteWindowViewModel();
            DataContext = ViewModel;
        }

        public FavoriteWindow(Favourite favourite)
        {
            InitializeComponent();
            ViewModel = new FavouriteWindowViewModel(favourite);
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
