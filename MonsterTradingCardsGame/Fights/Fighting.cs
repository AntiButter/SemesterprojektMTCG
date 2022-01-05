using MonsterTradingCardsGame.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterTradingCardsGame.Fights
{
    class Fighting : IFights
    {
        private static Random rng = new Random();
        DamageCalc damageCalc = new DamageCalc();
        public void fightAI(List<cardBase> DeckUser, List<cardBase> DeckAI)
        {
            DeckUser = DeckUser.OrderBy(x => rng.Next()).ToList();
            DeckAI = DeckAI.OrderBy(x => rng.Next()).ToList();
            int Round = 0;
            while (DeckAI.Count != 0 && DeckUser.Count != 0)
            {
                Round++;
                Console.WriteLine("________________________________________");
                Console.WriteLine($"Round {Round}");
                int winner = damageCalc.fight(DeckUser[0], DeckAI[0]);
                if (winner == 1)
                {
                    Console.WriteLine($"{DeckUser[0].CardName} has won against {DeckAI[0].CardName}");
                    cardBase temp = DeckUser[0];
                    cardBase temp2 = DeckAI[0];
                    DeckUser.RemoveAt(0);
                    DeckAI.RemoveAt(0);
                    DeckUser.Add(temp);
                    DeckUser.Add(temp2);
                }
                else if (winner == 2)
                {
                    Console.WriteLine($"{DeckAI[0].CardName} has won against {DeckUser[0].CardName}");
                    cardBase temp = DeckUser[0];
                    cardBase temp2 = DeckAI[0];
                    DeckUser.RemoveAt(0);
                    DeckAI.RemoveAt(0);
                    DeckAI.Add(temp);
                    DeckAI.Add(temp2);
                }
                else if (winner == 0)
                {
                    Console.WriteLine($"{DeckUser[0].CardName} and {DeckAI[0].CardName} have drawn");
                    cardBase temp = DeckUser[0];
                    cardBase temp2 = DeckAI[0];
                    DeckUser.RemoveAt(0);
                    DeckAI.RemoveAt(0);
                    DeckUser.Add(temp);
                    DeckAI.Add(temp2);
                }

                if(DeckUser.Count == 0)
                {
                    Console.WriteLine("The AI has won the battle!");
                    return;
                }
                else if(DeckAI.Count == 0)
                {
                    Console.WriteLine("You have won the battle!");
                    return;
                }
                

                if(Round >= 100)
                {
                    Console.WriteLine("Maximum Rounds have been reached, DRAW");
                    return;
                }
                Console.WriteLine("________________________________________");
            }

            return;
        }




    }
}
