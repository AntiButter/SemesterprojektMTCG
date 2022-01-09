
using System;
using System.Collections.Generic;
using System.Text;
using MonsterTradingCardsGame.Cards;
using MonsterTradingCardsGame.DataBase;
namespace MonsterTradingCardsGame.Users
{
    class BaseUser : IUser
    {
        public string Username { get; set; }
        public int Currency { get; set; }
        public int UserID { get; set; }
        public int Token { get; set; }
        public int Elo { get; set; }
        List<cardBase> UserCollection = new List<cardBase>();
        List<cardBase> Deck = new List<cardBase>();

        public BaseUser(string UserLoginName, int ID, int currency, int token, int elo)
        {
            Username = UserLoginName;
            Currency = currency;
            UserID = ID;
            Token = token;
            Elo = elo;
            
        }

        public void StartTrade(cardBase card)
        {
            
        }
        public void SetDeck(List<cardBase> UserDeck)
        {
            Deck = UserDeck;
        }

        public void AddCardToUserCollection(cardBase CardToAdd)
        {
            UserCollection.Add(CardToAdd);
            Console.WriteLine(UserCollection.Count);
        }
        public void AddCardToDeck(cardBase card)
        {
            DataBaseConnection.getInstance().PlayerDeckAdd(this, card);
            Deck.Add(card);
        }
       
        public void CreateDeck()
        {
           
            bool deckFinish = false;
            while(!deckFinish)
            {
                Console.Clear();
                ShowUserCollection();
                Console.WriteLine("Choose Card to add: ");
                int input = Convert.ToInt32(Console.ReadLine());
                AddCardToDeck(UserCollection[input]);
                if(Deck.Count >= 4)
                {
                    deckFinish = true;
                }
            }
        }
        public void ShowDeck()
        {
            int counter = 1;
            Console.Clear();
            foreach (cardBase card in Deck)
            {
                Console.WriteLine($"{counter}: ");
                card.ShowStats();
                counter++;
            }
        }
        public List<cardBase> GetDeck()
        {
            return Deck;
        }

        public void ShowUserCollection()
        {
            int counter = 0;
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
        public void Trade(cardBase card)
        {


        }
    }
}
