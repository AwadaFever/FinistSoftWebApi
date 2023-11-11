using FinistSoftAdmin.Interfaces;
using FinistSoftAdmin.Windows;
using FinistSoftWebApi.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace FinistSoftAdmin.ViewModels
{
    public class FavoritsPageViewModel : BaseViewModel, IRefreshable
    {
        public ObservableCollection<Favourite> Favourites { get; set; } = new ObservableCollection<Favourite>();
        public Favourite? SelectedFavourite { get; set; } = null;
        public FavoritsPageViewModel()
        {
            Refresh();
        }

        public void Refresh()
        {
            Favourites.Clear();
            var favourites = ContextManager.context.Favourites.ToList();
            foreach (var favourite in favourites)
            {
                Favourites.Add(favourite);
            }
        }

        public void DeleteFavorite()
        {
            if (SelectedFavourite != null)
            {
                ContextManager.context.Favourites.Remove(SelectedFavourite);
                ContextManager.context.SaveChanges();
                Favourites.Remove(SelectedFavourite);
            }
        }
        public void AddFavorite()
        {
            FavoriteWindow window = new FavoriteWindow();
            if (window.ShowDialog() == true)
                Refresh();
        }
        public void UpdateFavorite()
        {
            if (SelectedFavourite != null)
            {
                FavoriteWindow window = new FavoriteWindow(SelectedFavourite);
                if (window.ShowDialog() == true)
                    Refresh();
            }
        }
    }
}
