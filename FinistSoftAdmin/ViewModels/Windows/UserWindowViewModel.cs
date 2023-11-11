using FinistSoftWebApi.Models;
using System;
using System.Windows;


namespace FinistSoftAdmin.ViewModels
{
    public class UserWindowViewModel : BaseViewModel
    {

        private readonly User User;
        private bool isNewUser = false;

        public UserWindowViewModel()
        {
            User = new User();
            isNewUser = true;
        }

        public UserWindowViewModel(User user)
        {
            User = user;
            FillStartData();
        }

        private string login = string.Empty;
        public string Login
        {
            get => login;
            set
            {
                if (login != value)
                {
                    login = value;
                    OnPropertyChanged(nameof(Login));
                }
            }
        }

        private string password = string.Empty;
        public string Password
        {
            get => password;
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        private string firstName = string.Empty;
        public string FirstName
        {
            get => firstName;
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        private string lastName = string.Empty;
        public string LastName
        {
            get => lastName;
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        private string patronymic = string.Empty;
        public string Patronymic
        {
            get => patronymic;
            set
            {
                if (patronymic != value)
                {
                    patronymic = value;
                    OnPropertyChanged(nameof(Patronymic));
                }
            }
        }

        private DateTime birthday = DateTime.Now;
        public DateTime Birthday
        {
            get => birthday;
            set
            {
                if (birthday != value)
                {
                    birthday = value;
                    OnPropertyChanged(nameof(Birthday));
                }
            }
        }

        private void FillStartData()
        {
            Login = User.Login;
            Password = User.Password;
            FirstName = User.FirstName;
            LastName = User.LastName;
            Patronymic = User.Patronymic;
            Birthday = User.Birthday;
        }

        public bool SaveChanges()
        {
            try
            {
                CheckData();

                User.Login = Login;
                User.Password = Password;
                User.FirstName = FirstName;
                User.LastName = LastName;
                User.Patronymic = Patronymic;
                User.Birthday = Birthday;


                if (isNewUser)
                    ContextManager.context.Users.Add(User);
                else
                    ContextManager.context.Users.Update(User);
                ContextManager.context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void CheckData()
        {
            if (string.IsNullOrWhiteSpace(FirstName))
                throw new Exception("Введите имя");
            if (string.IsNullOrWhiteSpace(LastName))
                throw new Exception("Введите фамилию");
            if (string.IsNullOrWhiteSpace(Patronymic))
                throw new Exception("Введите отчество");
            if (string.IsNullOrWhiteSpace(Login))
                throw new Exception("Введите логин");
            if (string.IsNullOrWhiteSpace(Password))
                throw new Exception("Введите пароль");
            if (birthday >= DateTime.Now)
                throw new Exception("Введите верную дату рождения");

        }

    }
}
