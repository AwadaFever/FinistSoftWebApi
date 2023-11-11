using FinistSoftAdmin.ViewModels;
using FinistSoftWebApi.Models;
using System.Windows;

namespace FinistSoftAdmin.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {

        private readonly UserWindowViewModel ViewModel;

        public UserWindow()
        {
            InitializeComponent();
            ViewModel = new UserWindowViewModel();
            DataContext = ViewModel;
        }
        public UserWindow(User user)
        {
            InitializeComponent();
            ViewModel = new UserWindowViewModel(user);
            DataContext = ViewModel;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SaveChanges())
                DialogResult = true;
        }

    }
}
