using NUnit.Framework;
using MonsterTradingCardsGame;
using MonsterTradingCardsGame.Cards;
using MonsterTradingCardsGame.EnumsAreTheEnemy;
using MonsterTradingCardsGame.Fights;
namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckGetCardDamage()
        {
            //ARRANGE
            var Card = new cardBase("Test", 20, ElementsEnum.elements.fire, CardTypeEnum.CardTypes.monster, CardRaceEnum.Races.Goblin, 300);
            //ACT
            int value = Card.GetCardDamage();
            //ASSERT
            Assert.AreEqual(value, 20);
        }

        [Test]
        public void CheckCardID()
        {
            //ARRANGE
            var Card = new cardBase("Test", 20, ElementsEnum.elements.fire, CardTypeEnum.CardTypes.monster, CardRaceEnum.Races.Goblin, 300);
            //ACT
            int value = Card.CardID;
            //ASSERT
            Assert.AreEqual(value, 300);
        }
        [Test]
        public void CheckCardID()
        {
            //ARRANGE
            var Card = new cardBase("Test", 20, ElementsEnum.elements.fire, CardTypeEnum.CardTypes.monster, CardRaceEnum.Races.Goblin, 300);
            //ACT
            int value = Card.CardID;
            //ASSERT
            Assert.AreEqual(value, 300);
        }
    }
}