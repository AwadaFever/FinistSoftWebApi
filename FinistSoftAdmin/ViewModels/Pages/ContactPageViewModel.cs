using FinistSoftAdmin.Interfaces;
using FinistSoftAdmin.Windows;
using FinistSoftWebApi.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace FinistSoftAdmin.ViewModels
{
    public class ContactPageViewModel : BaseViewModel, IRefreshable
    {
        public ObservableCollection<Contract> Contracts { get; set; } = new ObservableCollection<Contract>();

        public Contract? SelectedContract { get; set; } = null;
        public ContactPageViewModel()
        {
            Refresh();
        }

        public void Refresh()
        {
            Contracts.Clear();
            var contracts = ContextManager.context.Contracts.ToList();
            foreach (var contract in contracts)
            {
                Contracts.Add(contract);
            }
        }
        public void DeleteContract()
        {
            if (SelectedContract != null)
            {
                ContextManager.context.Contracts.Remove(SelectedContract);
                ContextManager.context.SaveChanges();
                Contracts.Remove(SelectedContract);
            }
        }

        public void AddContract()
        {
            ContractWindow window = new ContractWindow();
            if (window.ShowDialog() == true)
                Refresh();
        }
        public void UpdateContract()
        {
            if (SelectedContract != null)
            {
                ContractWindow window = new ContractWindow(SelectedContract);
                if (window.ShowDialog() == true)
                    Refresh();
            }
        }
    }
}
