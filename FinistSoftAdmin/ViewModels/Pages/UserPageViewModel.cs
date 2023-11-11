using FinistSoftAdmin.Interfaces;
using FinistSoftAdmin.Windows;
using FinistSoftWebApi.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace FinistSoftAdmin.ViewModels
{
    public class UserPageViewModel : BaseViewModel, IRefreshable
    {
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        public User? SelectedUser { get; set; } = null;

        public UserPageViewModel()
        {
            Refresh();
        }

        public void Refresh()
        {
            Users.Clear();
            var users = ContextManager.context.Users.ToList();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }

        public void DeleteUser()
        {
            if (SelectedUser != null)
            {
                ContextManager.context.Users.Remove(SelectedUser);
                ContextManager.context.SaveChanges();
                Users.Remove(SelectedUser);
            }
        }

        public void AddUser()
        {
            UserWindow window = new UserWindow();
            if (window.ShowDialog() == true)
                Refresh();
        }

        public void UpdateUser()
        {
            if (SelectedUser != null)
            {
                UserWindow window = new UserWindow(SelectedUser);
                if (window.ShowDialog() == true)
                    Refresh();
            }
        }
    }
}
