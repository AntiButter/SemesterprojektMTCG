
using System;
using System.Collections.Generic;
using System.Text;
using MonsterTradingCardsGame.Cards;
namespace MonsterTradingCardsGame.Users
{
    class BaseUser : IUser
    {
        string Username;
        int Currency;
        int UserID;
        int Token;
        int Elo;
        List<cardBase> UserCollection = new List<cardBase>();
        List<cardBase> Deck1 = new List<cardBase>();

        public BaseUser(string UserLoginName, int ID, int currency, int token, int elo)
        {
            Username = UserLoginName;
            Currency = currency;
            UserID = ID;
            Token = token;
            Elo = elo;
            
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
            Console.WriteLine($"Token: {Token}");
            Console.WriteLine($"Elo: {Elo}");
            Console.WriteLine();

        }
    }
}
