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
        public int fight(List<cardBase> DeckUser, List<cardBase> DeckEnemy)
        {
            DeckUser = DeckUser.OrderBy(x => rng.Next()).ToList();
            DeckEnemy = DeckEnemy.OrderBy(x => rng.Next()).ToList();
            int Round = 0;
            while (DeckEnemy.Count != 0 && DeckUser.Count != 0)
            {
                Round++;
                Console.WriteLine("________________________________________");
                Console.WriteLine($"Round {Round}");
                int winner = damageCalc.fight(DeckUser[0], DeckEnemy[0]);
                if (winner == 1)
                {
                    Console.WriteLine($"{DeckUser[0].CardName} has won against {DeckEnemy[0].CardName}");
                    cardBase temp = DeckUser[0];
                    cardBase temp2 = DeckEnemy[0];
                    DeckUser.RemoveAt(0);
                    DeckEnemy.RemoveAt(0);
                    DeckUser.Add(temp);
                    DeckUser.Add(temp2);
                }
                else if (winner == 2)
                {
                    Console.WriteLine($"{DeckEnemy[0].CardName} has won against {DeckUser[0].CardName}");
                    cardBase temp = DeckUser[0];
                    cardBase temp2 = DeckEnemy[0];
                    DeckUser.RemoveAt(0);
                    DeckEnemy.RemoveAt(0);
                    DeckEnemy.Add(temp);
                    DeckEnemy.Add(temp2);
                }
                else if (winner == 0)
                {
                    Console.WriteLine($"{DeckUser[0].CardName} and {DeckEnemy[0].CardName} have drawn");
                    cardBase temp = DeckUser[0];
                    cardBase temp2 = DeckEnemy[0];
                    DeckUser.RemoveAt(0);
                    DeckEnemy.RemoveAt(0);
                    DeckUser.Add(temp);
                    DeckEnemy.Add(temp2);
                }

                if(DeckUser.Count == 0)
                {
                    Console.WriteLine("The enemy has won the battle!");

                    return 2;
                }
                else if(DeckEnemy.Count == 0)
                {
                    Console.WriteLine("You have won the battle!");
                    return 1;
                }
                

                if(Round >= 100)
                {
                    Console.WriteLine("Maximum Rounds have been reached, DRAW");
                    return 0;
                }
                Console.WriteLine("________________________________________");
            }

            return;
        }




    }
}
