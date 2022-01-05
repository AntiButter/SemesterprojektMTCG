using System;
using System.Collections.Generic;
using System.Text;
using MonsterTradingCardsGame.Cards;
namespace MonsterTradingCardsGame.Users
{
    interface IUser
    {
        abstract void ShowUserInformation();
        abstract void CreateDeck();
        abstract void ShowUserCollection();
        abstract void AddCardToUserCollection(cardBase Card);
        abstract List<cardBase> GetDeck();
        
    }
}
