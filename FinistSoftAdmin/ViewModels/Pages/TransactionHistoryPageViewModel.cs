using FinistSoftAdmin.Interfaces;
using FinistSoftAdmin.Windows;
using FinistSoftWebApi.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace FinistSoftAdmin.ViewModels
{
    public class TransactionHistoryPageViewModel : BaseViewModel, IRefreshable
    {
        public TransactionHistory? SelectedTransactionHistory { get; set; } = null;
        public ObservableCollection<TransactionHistory> TransactionHistories { get; set; } = new ObservableCollection<TransactionHistory>();


        public TransactionHistoryPageViewModel()
        {
            Refresh();
        }

        public void Refresh()
        {
            TransactionHistories.Clear();
            var transactionHistories = ContextManager.context.TransactionHistories.ToList();
            foreach (var transaction in transactionHistories)
            {
                TransactionHistories.Add(transaction);
            }
        }

        public void DeleteTransaction()
        {
            if (SelectedTransactionHistory != null)
            {
                ContextManager.context.TransactionHistories.Remove(SelectedTransactionHistory);
                ContextManager.context.SaveChanges();
                TransactionHistories.Remove(SelectedTransactionHistory);
            }
        }
        public void AddTransaction()
        {
            TransactionHistoryWindow window = new TransactionHistoryWindow();
            if (window.ShowDialog() == true)
                Refresh();
        }
        public void UpdateTransaction()
        {
            if (SelectedTransactionHistory != null)
            {
                TransactionHistoryWindow window = new TransactionHistoryWindow(SelectedTransactionHistory);
                if (window.ShowDialog() == true)
                    Refresh();
            }
        }

    }
}
