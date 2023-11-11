using FinistSoftAdmin.Interfaces;
using FinistSoftAdmin.Pages;
using FinistSoftWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace FinistSoftAdmin.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        {
            ContextManager.FillContext();
            currentPage = new UserPage();
        }

        private Page currentPage;
        public Page CurrentPage
        {
            get => currentPage;
            set
            {
                if (currentPage != value)
                {
                    currentPage = value;
                    OnPropertyChanged(nameof(CurrentPage));
                }
            }
        }

        public void FillStartData()
        {
            FillUsers();
            FillContracts();
            FillTransactionHistory();
            FillFavorites();
            FillCards();
            IRefreshable currentContext = (IRefreshable)CurrentPage.DataContext;
            currentContext.Refresh();
        }

        public void FillUsers()
        {
            for (int i = 0; i < 5; i++)
            {
                ContextManager.context.Users.Add(new User()
                {
                    Login = $"Логин{i}",
                    Password = $"Пароль{i}",
                    FirstName = $"Имя{i}",
                    LastName = $"Фамилия{i}",
                    Patronymic = $"Отчество{i}",
                    Birthday = DateTime.Now.AddYears(-i),
                });
            }
            ContextManager.context.SaveChanges();
        }

        public void FillContracts()
        {
            int i = 0;
            List<User> users = ContextManager.context.Users.ToList();
            foreach (User user in users)
            {
                ContextManager.context.Contracts.Add(new Contract()
                {

                    UserId = user.Id,
                    User = user,
                    Number = $"Номер{i}",
                    DateOpen = DateTime.Now.AddYears(i),
                    State = $"Открыт",
                    Amount = (i + 1) * 100
                });
                i++;
            }
            ContextManager.context.SaveChanges();
        }
        public void FillTransactionHistory()
        {
            int i = 0;
            List<Contract> contracts = ContextManager.context.Contracts.ToList();
            foreach (Contract contract in contracts)
            {
                int anotherContract = Random.Shared.Next(0, contracts.Count);

                ContextManager.context.TransactionHistories.Add(new TransactionHistory()
                {
                    SenderId = contract.Id,
                    Sender = contract,
                    ReciverId = anotherContract,
                    Reciver = contracts[anotherContract],
                    Sum = (i + 1) * 100,
                    TransactionDate = DateTime.Now.AddDays(-i)
                });
                i++;
            }
            ContextManager.context.SaveChanges();
        }
        public void FillFavorites()
        {
            int i = 0;
            List<User> users = ContextManager.context.Users.ToList();
            List<TransactionHistory> transactionHistories = ContextManager.context.TransactionHistories.ToList();
            foreach (User user in users)
            {
                int transaction = Random.Shared.Next(0, transactionHistories.Count);
                ContextManager.context.Favourites.Add(new Favourite()
                {
                    Name = $"Шаблон{i}",
                    UserId = user.Id,
                    User = user,
                    TransactionId = transaction,
                    Transaction = transactionHistories[transaction]
                });
                i++;
            }
            ContextManager.context.SaveChanges();
        }

        public void FillCards()
        {
            int i = 1;
            List<Contract> contracts = ContextManager.context.Contracts.ToList();
            foreach (Contract contract in contracts)
            {

                ContextManager.context.Cards.Add(new Card()
                {
                    DateOpen = DateTime.Now.AddMonths(-i),
                    DateClosed = DateTime.Now.AddYears(i),
                    ContractId = contract.Id,
                    Contract = contract,
                    Number = $"Номер{i}",
                    CVV = $"{i * 100}",
                    Image = "Пусть к фото идут моряки"
                });
                i++;

            }
            ContextManager.context.SaveChanges();
        }

    }
}
