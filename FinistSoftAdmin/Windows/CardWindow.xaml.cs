using FinistSoftAdmin.ViewModels;
using FinistSoftWebApi.Models;
using System.Windows;

namespace FinistSoftAdmin.Windows
{
    /// <summary>
    /// Логика взаимодействия для CardWindow.xaml
    /// </summary>
    public partial class CardWindow : Window
    {

        private readonly CardWindowViewModel ViewModel;
        public CardWindow()
        {
            InitializeComponent();
            ViewModel = new CardWindowViewModel();
            DataContext = ViewModel;
        }
        public CardWindow(Card card)
        {
            InitializeComponent();
            ViewModel = new CardWindowViewModel(card);
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
