using FinistSoftAdmin.Interfaces;
using FinistSoftAdmin.Windows;
using FinistSoftWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;

namespace FinistSoftAdmin.ViewModels
{
    public class CardsPageViewModel : BaseViewModel, IRefreshable
    {
        public ObservableCollection<Card> Cards { get; set; } = new ObservableCollection<Card>();

        public Card? SelectedCard { get; set; } = null;

        public CardsPageViewModel()
        {
            Refresh();
        }

        public void Refresh()
        {
            Cards.Clear();
            var cards = ContextManager.context.Cards.Include(c => c.Contract).ToList();
            foreach (var card in cards)
            {
                Cards.Add(card);
            }
        }

        public void DeleteCard()
        {
            if (SelectedCard != null)
            {
                ContextManager.context.Cards.Remove(SelectedCard);
                ContextManager.context.SaveChanges();
                Cards.Remove(SelectedCard);
            }
        }
        public void AddCard()
        {
            CardWindow window = new CardWindow();
            if (window.ShowDialog() == true)
                Refresh();
        }
        public void UpdateCard()
        {
            if (SelectedCard != null)
            {
                CardWindow window = new CardWindow(SelectedCard);
                if (window.ShowDialog() == true)
                    Refresh();
            }
        }
    }
}
