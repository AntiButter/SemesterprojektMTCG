using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterTradingCardsGame.Cards;
namespace MonsterTradingCardsGame.Fights
{
    class DamageCalc
    {
        
        public int fight(cardBase Card1, cardBase Card2)
        {
            int DamageCard1, DamageCard2 = 0;
            DamageCard1 = Card1.GetCardDamage();
            DamageCard2 = Card2.GetCardDamage();
            int winner = 0;
            int modifier = 2;
            Card1.ShowStats();
            Console.WriteLine("Fighting with");
            Card2.ShowStats();
            if (Card1.Type == EnumsAreTheEnemy.CardTypeEnum.CardTypes.monster && Card2.Type == EnumsAreTheEnemy.CardTypeEnum.CardTypes.monster)
            {

            }
            else 
            {
                switch (Card1.Element)
                {
                    case EnumsAreTheEnemy.ElementsEnum.elements.fire:
                        switch(Card2.Element)
                        {
                            case EnumsAreTheEnemy.ElementsEnum.elements.fire:
                                break;
                            case EnumsAreTheEnemy.ElementsEnum.elements.water:
                                DamageCard1 /= modifier;
                                DamageCard2 *= modifier;
                                break;
                            case EnumsAreTheEnemy.ElementsEnum.elements.normal:
                                DamageCard1 *= modifier;
                                DamageCard2 /= modifier;
                                break;
                        }
                        break;
                    case EnumsAreTheEnemy.ElementsEnum.elements.water:
                        switch (Card2.Element)
                        {
                            case EnumsAreTheEnemy.ElementsEnum.elements.fire:
                                DamageCard1 *= modifier;
                                DamageCard2 /= modifier;
                                break;
                            case EnumsAreTheEnemy.ElementsEnum.elements.water:
                                break;
                            case EnumsAreTheEnemy.ElementsEnum.elements.normal:
                                DamageCard1 /= modifier;
                                DamageCard2 *= modifier;
                                break;
                        }
                        break;
                    case EnumsAreTheEnemy.ElementsEnum.elements.normal:
                        switch (Card2.Element)
                        {
                            case EnumsAreTheEnemy.ElementsEnum.elements.fire:
                                DamageCard1 /= modifier;
                                DamageCard2 *= modifier;
                                break;
                            case EnumsAreTheEnemy.ElementsEnum.elements.water:
                                DamageCard1 *= modifier;
                                DamageCard2 /= modifier;
                                break;
                            case EnumsAreTheEnemy.ElementsEnum.elements.normal:
                                break;
                        }
                        break;
                }
            }
            Console.WriteLine($"In Fight Damage: {DamageCard1} vs {DamageCard2}");
            if(DamageCard1 > DamageCard2)
            {
                winner = 1;
            }
            else if(DamageCard2 > DamageCard1)
            {
                winner = 2;
            }
            return winner;
        }
    }
}
