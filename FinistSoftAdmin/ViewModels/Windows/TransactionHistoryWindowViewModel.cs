using FinistSoftWebApi.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace FinistSoftAdmin.ViewModels
{

    internal class TransactionHistoryWindowViewModel : BaseViewModel
    {
        private readonly TransactionHistory TransactionHistory;
        public ObservableCollection<Contract> Contracts { get; set; } = new ObservableCollection<Contract>();
        private bool isNewHistory = false;

        public TransactionHistoryWindowViewModel()
        {
            TransactionHistory = new TransactionHistory();
            isNewHistory = true;
            LoadContracts();

        }
        public TransactionHistoryWindowViewModel(TransactionHistory transactionHistory)
        {
            TransactionHistory = transactionHistory;
            LoadContracts();
            FillStartData();
        }

        private int senderId = -1;

        public int SenderId
        {
            get => senderId;
            set
            {
                if (senderId != value)
                {
                    senderId = value;
                    OnPropertyChanged(nameof(SenderId));
                }
            }
        }

        private int reciverId = -1;

        public int ReciverId
        {
            get => reciverId;
            set
            {
                if (reciverId != value)
                {
                    reciverId = value;
                    OnPropertyChanged(nameof(ReciverId));
                }
            }
        }

        private string sum = string.Empty;

        public string Sum
        {
            get => sum;
            set
            {
                if (sum != value)
                {
                    sum = value;
                    OnPropertyChanged(nameof(Sum));
                }
            }
        }

        private DateTime transactionDate = DateTime.Now;

        public DateTime TransactionDate
        {
            get => transactionDate;
            set
            {
                if (transactionDate != value)
                {
                    transactionDate = value;
                    OnPropertyChanged(nameof(TransactionDate));
                }
            }
        }

        private void LoadContracts()
        {
            var contracts = ContextManager.context.Contracts.ToList();
            foreach (var contract in contracts)
            {
                Contracts.Add(contract);
            }
        }

        private void FillStartData()
        {
            SenderId = TransactionHistory.SenderId;
            ReciverId = TransactionHistory.ReciverId;
            Sum = TransactionHistory.Sum.ToString();
            TransactionDate = TransactionHistory.TransactionDate;
        }

        public bool SaveChanges()
        {
            try
            {
                CheckData();

                TransactionHistory.SenderId = SenderId;
                TransactionHistory.ReciverId = ReciverId;
                TransactionHistory.Sum = decimal.Parse(Sum);
                TransactionHistory.TransactionDate = TransactionDate;

                if (isNewHistory)
                    ContextManager.context.TransactionHistories.Add(TransactionHistory);
                else
                    ContextManager.context.TransactionHistories.Update(TransactionHistory);
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
            if (SenderId < 0)
                throw new Exception("Выберите отправителя");
            if (ReciverId < 0)
                throw new Exception("Выберите получателя");
            if (!decimal.TryParse(Sum, out decimal _))
                throw new Exception("Сумма введена некорректно");
            if (TransactionDate >= DateTime.Now)
                throw new Exception("Введите корректную дату совершения платежа");
        }
    }
}
