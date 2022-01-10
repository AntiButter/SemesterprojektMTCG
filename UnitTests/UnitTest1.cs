using NUnit.Framework;
using MonsterTradingCardsGame;
using MonsterTradingCardsGame.Cards;
using MonsterTradingCardsGame.EnumsAreTheEnemy;
using MonsterTradingCardsGame.Fights;
using System;
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
        public void CheckCardName()
        {
            //ARRANGE
            var Card = new cardBase("Test", 20, ElementsEnum.elements.fire, CardTypeEnum.CardTypes.monster, CardRaceEnum.Races.Goblin, 300);
            //ACT
            var value = Card.CardName;
            //ASSERT
            Assert.AreEqual(value, "Test");
        }

        [Test]
        public void CheckElementFire()
        {
            //ARRANGE
            var Card = new cardBase("Test", 20, ElementsEnum.elements.fire, CardTypeEnum.CardTypes.monster, CardRaceEnum.Races.Goblin, 300);
            //ACT
            int value = (int)Card.Element;
            //ASSERT
            Assert.AreEqual(value, 0);
        }
        [Test]
        public void CheckElementNormal()
        {
            //ARRANGE
            var Card = new cardBase("Test", 20, ElementsEnum.elements.normal, CardTypeEnum.CardTypes.monster, CardRaceEnum.Races.Goblin, 300);
            //ACT
            int value = (int)Card.Element;
            //ASSERT
            Assert.AreEqual(value, 2);
        }

        [Test]
        public void CheckElementWater()
        {
            //ARRANGE
            var Card = new cardBase("Test", 20, ElementsEnum.elements.water, CardTypeEnum.CardTypes.monster, CardRaceEnum.Races.Goblin, 300);
            //ACT
            int value = (int)Card.Element;
            //ASSERT
            Assert.AreEqual(value, 1);
        }
        [Test]
        public void CheckTypeMonster()
        {
            //ARRANGE
            var Card = new cardBase("Test", 20, ElementsEnum.elements.normal, CardTypeEnum.CardTypes.monster, CardRaceEnum.Races.Goblin, 300);
            //ACT
            int value = (int)Card.Type;
            //ASSERT
            Assert.AreEqual(value, 0);
        }

        [Test]
        public void CheckTypeSpell()
        {
            //ARRANGE
            var Card = new cardBase("Test", 20, ElementsEnum.elements.normal, CardTypeEnum.CardTypes.spell, CardRaceEnum.Races.Goblin, 300);
            //ACT
            int value = (int)Card.Type;
            //ASSERT
            Assert.AreEqual(value, 1);
        }

        [Test]
        public void CheckRaceGoblin()
        {
            //ARRANGE
            var Card = new cardBase("Test", 20, ElementsEnum.elements.normal, CardTypeEnum.CardTypes.spell, CardRaceEnum.Races.Goblin, 300);
            //ACT
            int value = (int)Card.Race;
            //ASSERT
            Assert.AreEqual(value, 0);
        }

        [Test]
        public void CheckRNG()
        {
            //ARRANGE
            var rng = new Random();
            //ACT
            int value = rng.Next(1, 4);
            //ASSERT
            if(value >= 1 && value <= 4)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        [Test]
        public void CheckBattle()
        {
            //ARRANGE
            var Card = new cardBase("Test", 20, ElementsEnum.elements.normal, CardTypeEnum.CardTypes.spell, CardRaceEnum.Races.Goblin, 300);
            var Card2 = new cardBase("Test2", 30, ElementsEnum.elements.fire, CardTypeEnum.CardTypes.spell, CardRaceEnum.Races.Goblin, 300);
            var damageCalc = new DamageCalc();
            //ACT
            var value = damageCalc.fight(Card, Card2);
            //ASSERT
            Assert.AreEqual(2, value);
        }
        [Test]
        public void CheckKrakenImmunity()
        {
            //ARRANGE
            var Card = new cardBase("Test", 50000, ElementsEnum.elements.normal, CardTypeEnum.CardTypes.spell, CardRaceEnum.Races.Goblin, 300);
            var Card2 = new cardBase("Test2", 1, ElementsEnum.elements.fire, CardTypeEnum.CardTypes.monster, CardRaceEnum.Races.Kraken, 300);
            var damageCalc = new DamageCalc();
            //ACT
            var value = damageCalc.fight(Card, Card2);
            //ASSERT
            Assert.AreEqual(2, value);
        }

        [Test]
        public void CheckKnightWater()
        {
            //ARRANGE
            var Card = new cardBase("Test", 1, ElementsEnum.elements.water, CardTypeEnum.CardTypes.spell, CardRaceEnum.Races.Goblin, 300);
            var Card2 = new cardBase("Test2", 500000, ElementsEnum.elements.fire, CardTypeEnum.CardTypes.monster, CardRaceEnum.Races.Knight, 300);
            var damageCalc = new DamageCalc();
            //ACT
            var value = damageCalc.fight(Card, Card2);
            //ASSERT
            Assert.AreEqual(1, value);
        }

        [Test]
        public void CheckDragonFireElves()
        {
            //ARRANGE
            var Card = new cardBase("Test", 50000, ElementsEnum.elements.normal, CardTypeEnum.CardTypes.monster, CardRaceEnum.Races.Dragon, 300);
            var Card2 = new cardBase("Test2", 1, ElementsEnum.elements.fire, CardTypeEnum.CardTypes.monster, CardRaceEnum.Races.FireElves, 300);
            var damageCalc = new DamageCalc();
            //ACT
            var value = damageCalc.fight(Card, Card2);
            //ASSERT
            Assert.AreEqual(2, value);
        }

        [Test]
        public void CheckOrkWizard()
        {
            //ARRANGE
            var Card = new cardBase("Test", 50000, ElementsEnum.elements.normal, CardTypeEnum.CardTypes.monster, CardRaceEnum.Races.Ork, 300);
            var Card2 = new cardBase("Test2", 1, ElementsEnum.elements.fire, CardTypeEnum.CardTypes.monster, CardRaceEnum.Races.Wizard, 300);
            var damageCalc = new DamageCalc();
            //ACT
            var value = damageCalc.fight(Card, Card2);
            //ASSERT
            Assert.AreEqual(2, value);
        }

        [Test]
        public void CheckSpells()
        {
            //ARRANGE
            var Card = new cardBase("Test", 50, ElementsEnum.elements.fire, CardTypeEnum.CardTypes.spell, CardRaceEnum.Races.Goblin, 300);
            var Card2 = new cardBase("Test2", 25, ElementsEnum.elements.water, CardTypeEnum.CardTypes.spell, CardRaceEnum.Races.Kraken, 300);
            var damageCalc = new DamageCalc();
            //ACT
            var value = damageCalc.fight(Card, Card2);
            //ASSERT
            Assert.AreEqual(2, value);
        }
    }
}