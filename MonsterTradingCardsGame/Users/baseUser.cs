
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

        public void Trade()
        {
            Console.WriteLine("Choose a card to trade: ");
            ShowUserCollection();
            int input = Convert.ToInt32(Console.ReadLine());
            input -= 1;
            int cardid = UserCollection[input].CardID;
            Console.WriteLine("Card Type:");
            var Type = Console.ReadLine();
            Console.WriteLine("Card Element:");
            var Element = Console.ReadLine();
            Console.WriteLine("Card Race:");
            var Race = Console.ReadLine();
            Console.WriteLine("Minimum Damage:");
            var minDamage = Convert.ToInt32(Console.ReadLine());
            DataBaseConnection.getInstance().TradeEntry(this, cardid, Type, Race, Element, minDamage);
            DataBaseConnection.getInstance().RemoveCardFromPlayerCollection(this, cardid);
            DataBaseConnection.getInstance().getPlayerstack(this);
            DataBaseConnection.getInstance().GetPlayerDeck(this);

        }
        public bool CheckDeckSize()
        {
            if (Deck.Count == 4)
                return true;
            else
                return false;
        }
        public void SetDeck(List<cardBase> UserDeck)
        {
            Deck = UserDeck;
        }
        public void SetCollection(List<cardBase> Collection)
        {
            UserCollection = Collection;
            ShowUserCollection();
        }
        public void ClearCollection()
        {
            UserCollection.Clear();
        }

        public void AddCardToUserCollection(cardBase CardToAdd)
        {
            UserCollection.Add(CardToAdd);
            Console.WriteLine(UserCollection.Count);
        }
        public void AddCardToDeck(cardBase card, int stackId)
        {
            DataBaseConnection.getInstance().PlayerDeckAdd(this, card, stackId);
            Deck.Add(card);
        }
       
        public void CreateDeck()
        {
           if(UserCollection.Count < 4)
            {
                Console.WriteLine("You don't own enough cards to make a deck!!");
                return;
            }
            bool deckFinish = false;
            while(!deckFinish)
            {
                Console.Clear();
                ShowUserCollection();
                Console.WriteLine("Choose Card to add: ");
                int input = Convert.ToInt32(Console.ReadLine());
                input -= 1;
                int input2 = input + 1;
                AddCardToDeck(UserCollection[input],input2);
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
            UserCollection = DataBaseConnection.getInstance().getPlayerstack(this);
            int counter = 1;
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
