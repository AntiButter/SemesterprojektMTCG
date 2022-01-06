using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterTradingCardsGame.Cards
{
    class Set
    {
        List<ICard> CardSet;

        public Set()
        {
            CardSet = new List<ICard>();
        }
        
        public void addCard(cardBase card)
        {
            CardSet.Add(card);
        }

        public void PrintSet()
        {
            foreach (cardBase card in CardSet)
            {
                card.ShowStats();
            }
        }


    }
}
