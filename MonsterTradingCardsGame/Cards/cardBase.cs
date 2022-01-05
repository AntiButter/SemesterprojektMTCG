using System;
using System.Collections.Generic;
using System.Text;
using MonsterTradingCardsGame.EnumsAreTheEnemy;
using MonsterTradingCardsGame.Users;
using MonsterTradingCardsGame.CardShop;
namespace MonsterTradingCardsGame.Cards
{
    class cardBase : ICard
    {
        public cardBase(string NameOfCard, int DamageValue, ElementsEnum.elements CardElement, CardTypeEnum.CardTypes CardType, int ID)
        {
            CardName = NameOfCard;
            CardDamage = DamageValue;
            Element = CardElement;
            Type = CardType;
            CardID = ID;
        }

        public string CardName { get; set; }
        public int CardID { get; }
        int CardDamage;
        public ElementsEnum.elements Element { get; set; }
        public CardTypeEnum.CardTypes Type { get; set; }

        public int GetCardDamage()
        {
            return CardDamage;
        }
        public void ShowStats()
        {
            Console.WriteLine();
            Console.WriteLine($"{CardName} Type: {Type} Element: {Element}");
            Console.WriteLine($"Damage: {CardDamage}");
            Console.WriteLine();

        }
 
    }
}
