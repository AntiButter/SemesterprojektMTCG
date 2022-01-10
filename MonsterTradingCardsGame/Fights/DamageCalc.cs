using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterTradingCardsGame.Cards;
using MonsterTradingCardsGame.EnumsAreTheEnemy;
namespace MonsterTradingCardsGame.Fights
{
    public class DamageCalc
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
                if(Card1.Race == CardRaceEnum.Races.Goblin && Card2.Race == CardRaceEnum.Races.Dragon)
                {
                    winner = 2;
                    Console.WriteLine("Race Specialty");
                    Console.WriteLine("Goblins are too afraid of Dragons to Attack!");
                    return winner;
                }
                if (Card2.Race == CardRaceEnum.Races.Goblin && Card1.Race == CardRaceEnum.Races.Dragon)
                {
                    winner = 1;
                    Console.WriteLine("Race Specialty");
                    Console.WriteLine("Goblins are too afraid of Dragons to Attack!");
                    return winner;
                }

                if (Card1.Race == CardRaceEnum.Races.Wizard && Card2.Race == CardRaceEnum.Races.Ork)
                {
                    winner = 1;
                    Console.WriteLine("Race Specialty");
                    Console.WriteLine("Wizard can control Orks so they are not able to Damage them!");
                    return winner;
                }
                if (Card2.Race == CardRaceEnum.Races.Ork && Card1.Race == CardRaceEnum.Races.Wizard)
                {
                    winner = 2;
                    Console.WriteLine("Race Specialty");
                    Console.WriteLine("Wizard can control Orks so they are not able to Damage them!");
                    return winner;
                }

                if (Card2.Race == CardRaceEnum.Races.FireElves && Card1.Race == CardRaceEnum.Races.Dragon)
                {
                    winner = 1;
                    Console.WriteLine("Race Specialty");
                    Console.WriteLine("The FireElves know Dragons since they were little and can evade their attacks");
                    return winner;
                }
                if (Card2.Race == CardRaceEnum.Races.Dragon && Card1.Race == CardRaceEnum.Races.FireElves)
                {
                    winner = 2;
                    Console.WriteLine("Race Specialty");
                    Console.WriteLine("The FireElves know Dragons since they were little and can evade their attacks");
                    return winner;
                }

            }
            else 
            {
                if(Card1.Race == CardRaceEnum.Races.Kraken)
                {
                    winner = 1;
                    Console.WriteLine("Race Specialty");
                    Console.WriteLine("The Kraken is immune to spells");
                    return winner;

                }
                else if(Card2.Race == CardRaceEnum.Races.Kraken)
                {
                    winner = 2;
                    Console.WriteLine("Race Specialty");
                    Console.WriteLine("The Kraken is immune to spells");
                    return winner;
                }


                if(Card1.Race == CardRaceEnum.Races.Knight && Card2.Element == ElementsEnum.elements.water)
                {
                    winner = 2;
                    Console.WriteLine("Race Specialty");
                    Console.WriteLine("The armor of knights is so heavy that WaterSpells make them drown instantly");
                    return winner;
                }
                else if (Card2.Race == CardRaceEnum.Races.Knight && Card1.Element == ElementsEnum.elements.water)
                {
                    winner = 1;
                    Console.WriteLine("Race Specialty");
                    Console.WriteLine("The armor of knights is so heavy that WaterSpells make them drown instantly");
                    return winner;
                }



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
