using FinistSoftWebApi.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace FinistSoftAdmin.ViewModels
{
    internal class ContractWindowViewModel : BaseViewModel
    {
        private readonly Contract Contract;

        private bool isNewContract = false;

        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        public ContractWindowViewModel()
        {
            Contract = new Contract();
            isNewContract = true;
            LoadUsers();
        }

        public ContractWindowViewModel(Contract contract)
        {
            Contract = contract;
            LoadUsers();
            FillStartData();
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

        private string number = string.Empty;

        public string Number
        {
            get => number;
            set
            {
                if (number != value)
                {
                    number = value;
                    OnPropertyChanged(nameof(Number));
                }

            }
        }

        private DateTime dateOpen = DateTime.Now;

        public DateTime DateOpen
        {
            get => dateOpen;
            set
            {
                if (dateOpen != value)
                {
                    dateOpen = value;
                    OnPropertyChanged(nameof(DateOpen));
                }
            }
        }

        private string state = string.Empty;

        public string State
        {
            get => state;
            set
            {
                if (state != value)
                {
                    state = value;
                    OnPropertyChanged(nameof(State));
                }
            }
        }

        public string amount = string.Empty;

        public string Amount
        {
            get => amount;
            set
            {
                if (amount != value)
                {
                    amount = value;
                    OnPropertyChanged(nameof(Amount));
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

        private void FillStartData()
        {
            UserId = Contract.UserId;
            Number = Contract.Number;
            DateOpen = Contract.DateOpen;
            State = Contract.State;
            Amount = Contract.Amount.ToString();
        }

        public bool SaveChanges()
        {
            try
            {
                CheckData();

                Contract.UserId = UserId;
                Contract.Number = Number;
                Contract.DateOpen = dateOpen;
                Contract.State = State;
                Contract.Amount = decimal.Parse(Amount);

                if (isNewContract)
                    ContextManager.context.Contracts.Add(Contract);
                else
                    ContextManager.context.Contracts.Update(Contract);
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
            if (string.IsNullOrWhiteSpace(Number))
                throw new Exception("Введите номер счёта");
            if (string.IsNullOrWhiteSpace(State))
                throw new Exception("Введите состояние счёта");
            if (UserId < 0)
                throw new Exception("Выберите пользователя");
            if (DateOpen >= DateTime.Now)
                throw new Exception("Введите верную дату открытия счёта");
            if (!decimal.TryParse(Amount, out decimal _))
                throw new Exception("Некорректно введена сумма");


        }
    }
}
