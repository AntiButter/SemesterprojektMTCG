using System;
using System.Collections.Generic;
using System.Text;
using MonsterTradingCardsGame.EnumsAreTheEnemy;
using MonsterTradingCardsGame.Users;
using MonsterTradingCardsGame.CardShop;
namespace MonsterTradingCardsGame.Cards
{
    public class cardBase : ICard
    {
        public cardBase(string NameOfCard, int DamageValue, ElementsEnum.elements CardElement, CardTypeEnum.CardTypes CardType,CardRaceEnum.Races race, int ID)
        {
            CardName = NameOfCard;
            CardDamage = DamageValue;
            Element = CardElement;
            Type = CardType;
            CardID = ID;
            Race = race;
        }
        public cardBase(cardBase card)
        {
            CardName = card.CardName;
            CardDamage = card.CardDamage;
            Element = card.Element;
            Type = card.Type;
            CardID = card.CardID;
            Race = card.Race;
        }

        public string CardName { get; set; }
        public int CardID { get; }
        int CardDamage;
        public ElementsEnum.elements Element { get; set; }
        public CardTypeEnum.CardTypes Type { get; set; }
        public CardRaceEnum.Races Race { get; set; }


        public int GetCardDamage()
        {
            return CardDamage;
        }
        public void ShowStats()
        {
            Console.WriteLine($"{CardName} Type: {Type} Element: {Element} Race: {Race}");
            Console.WriteLine($"Damage: {CardDamage}");
            Console.WriteLine();
        }
 
    }
}
