
using System;
using System.Collections.Generic;
using System.Text;
using MonsterTradingCardsGame.Cards;
namespace MonsterTradingCardsGame.Users
{
    class BaseUser : IUser
    {
        readonly string Password;
        string Username;
        int Currency;
        int UserID;
        List<cardBase> UserCollection = new List<cardBase>();
        List<cardBase> Deck1 = new List<cardBase>();

        public BaseUser(string UserPassword, string UserLoginName, int ID)
        {
            Username = UserLoginName;
            Password = UserPassword;
            Currency = 20;
            UserID = ID;
            
        }

        public void AddCardToUserCollection(cardBase CardToAdd)
        {
            UserCollection.Add(CardToAdd);
        }

        public void CreateDeck()
        {
            foreach(cardBase card in UserCollection)
            {
                Deck1.Add(card);
            }
        }

        public List<cardBase> GetDeck()
        {
            return Deck1;
        }

        public void ShowUserCollection()
        {
            var counter = 1;
            foreach (cardBase card in UserCollection)
            {
                Console.WriteLine($"Card {counter}");
                card.ShowStats();
                counter++;
            }
        }

        public void ShowUserInformation()
        {
            Console.WriteLine($"User: {Username}");
            Console.WriteLine($"Coins: {Currency}");
            Console.WriteLine();

        }
    }
}
