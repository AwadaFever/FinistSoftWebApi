using FinistSoftWebApi.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace FinistSoftAdmin.ViewModels
{
    public class FavouriteWindowViewModel : BaseViewModel
    {

        private readonly Favourite Favourite;
        private bool isNewFavourite = false;
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
        public ObservableCollection<TransactionHistory> TransactionHistories { get; set; } = new ObservableCollection<TransactionHistory>();

        public FavouriteWindowViewModel()
        {
            Favourite = new Favourite();
            isNewFavourite = true;
            LoadUsers();
            LoadTransactions();
        }

        public FavouriteWindowViewModel(Favourite favourite)
        {
            Favourite = favourite;
            LoadUsers();
            LoadTransactions();
            FillStartData();
        }

        private string name = string.Empty;
        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private int userId = -1;
        public int UserId
        {
            get => userId;
            set
            {
                if (userId != value)
                {
                    userId = value;
                    OnPropertyChanged(nameof(UserId));
                }
            }
        }

        private int transactionId = -1;
        public int TransactionId
        {
            get => transactionId;
            set
            {
                if (transactionId != value)
                {
                    transactionId = value;
                    OnPropertyChanged(nameof(TransactionId));
                }
            }
        }

        private void LoadUsers()
        {
            var users = ContextManager.context.Users.ToList();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }

        private void LoadTransactions()
        {
            var transactions = ContextManager.context.TransactionHistories.ToList();
            foreach (var transactionHistory in transactions)
            {
                TransactionHistories.Add(transactionHistory);
            }
        }

        private void FillStartData()
        {
            Name = Favourite.Name;
            UserId = Favourite.UserId;
            TransactionId = Favourite.TransactionId;
        }

        public bool SaveChanges()
        {
            try
            {
                CheckData();

                Favourite.Name = Name;
                Favourite.UserId = UserId;
                Favourite.TransactionId = TransactionId;

                if (isNewFavourite)
                    ContextManager.context.Favourites.Add(Favourite);
                else
                    ContextManager.context.Favourites.Update(Favourite);
                ContextManager.context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void CheckData()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new Exception("Введите название шаблона");
            if (UserId < 0)
                throw new Exception("Выбери пользователя");
            if (TransactionId < 0)
                throw new Exception("Выберите операцию");
        }


    }
}
