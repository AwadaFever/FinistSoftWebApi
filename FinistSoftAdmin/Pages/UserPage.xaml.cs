using FinistSoftAdmin.ViewModels;
using System.Windows;
using System.Windows.Controls;


namespace FinistSoftAdmin.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPageViewModel ViewModel = new UserPageViewModel();
        public UserPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddUser();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.UpdateUser();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteUser();
        }
    }
}
