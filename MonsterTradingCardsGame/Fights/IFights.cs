﻿using System;
using System.Collections.Generic;
using System.Text;
using MonsterTradingCardsGame.Cards;
namespace MonsterTradingCardsGame.Fights
{
    interface IFights 
    {
        public void fight(List<cardBase> DeckUser, List<cardBase> DeckAI);
    }
}
