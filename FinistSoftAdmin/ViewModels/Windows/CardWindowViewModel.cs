using FinistSoftWebApi.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace FinistSoftAdmin.ViewModels
{
    internal class CardWindowViewModel : BaseViewModel
    {
        private readonly Card Card;
        private bool isNewCard = false;

        public ObservableCollection<Contract> Contracts { get; set; } = new ObservableCollection<Contract>();

        public CardWindowViewModel()
        {
            Card = new Card();
            isNewCard = true;
            LoadContracts();
        }
        public CardWindowViewModel(Card card)
        {
            Card = card;
            LoadContracts();
            FillStartData();

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

        private DateTime dateClose = DateTime.Now;

        public DateTime DateClose
        {
            get => dateOpen;
            set
            {
                if (dateClose != value)
                {
                    dateClose = value;
                    OnPropertyChanged(nameof(DateClose));
                }
            }
        }

        private int contractId = -1;

        public int ContractId
        {
            get => contractId;
            set
            {
                if (contractId != value)
                {
                    contractId = value;
                    OnPropertyChanged(nameof(ContractId));
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

        private string cvv = string.Empty;

        public string CVV
        {
            get => cvv;
            set
            {
                if (cvv != value)
                {
                    cvv = value;
                    OnPropertyChanged(nameof(CVV));
                }

            }
        }
        private string image = string.Empty;
        public string Image
        {
            get => image;
            set
            {
                if (image != value)
                {
                    image = value;
                    OnPropertyChanged(nameof(Image));
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
            DateOpen = Card.DateOpen;
            DateClose = Card.DateClosed;
            ContractId = Card.ContractId;
            Number = Card.Number;
            CVV = Card.CVV;
            Image = Card.Image;
        }

        public bool SaveChanges()
        {
            try
            {
                CheckData();

                Card.DateOpen = DateOpen;
                Card.DateClosed = DateClose;
                Card.ContractId = ContractId;
                Card.Number = Number;
                Card.CVV = CVV;
                Card.Image = Image;

                if (isNewCard)
                    ContextManager.context.Cards.Add(Card);
                else
                    ContextManager.context.Cards.Update(Card);
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
                throw new Exception("Введите номер карты");
            if (string.IsNullOrWhiteSpace(CVV))
                throw new Exception("Введите CVV карты");
            if (ContractId < 0)
                throw new Exception("Введите номер контракта");
            if (DateOpen >= DateTime.Now)
                throw new Exception("Введите верную дату открытия карты");
            if (DateClose >= DateTime.Now)
                throw new Exception("Введите верную дату окончания действия карты");
        }
    }
}
