using System.Collections.Generic;
using NUnit.Framework;

namespace GildedRose
{
    [TestFixture]
    public class GildedRoseTest
    {
        private static IList<Item> SetupTest(string name, int sellIn, int quality)
        {
            IList<Item> items = new List<Item> {new Item {Name = name, SellIn = sellIn, Quality = quality}};
            GildedRose.UpdateQuality(items);
            return items;
        }

        [Test]
        public void Name_Unchanging()
        {
            var items = SetupTest("foo", 1, 1);
            Assert.AreEqual("foo", items[0].Name);
        }

        [Test]
        public void SellIn_Decreases()
        {
            var items = SetupTest("foo", 1, 1);
            Assert.AreEqual(0, items[0].SellIn);
        }

        [Test]
        public void Quality_Decreases()
        {
            var items = SetupTest("foo", 1, 1);
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void Quality_ForZeroSellIn_DecreasesTwiceAsFast()
        {
            var items = SetupTest("foo", 0, 2);
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void Quality_ForNegativeSellIn_DecreasesTwiceAsFast()
        {
            var items = SetupTest("foo", -1, 2);
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void Quality_NeverNegative()
        {
            var items = SetupTest("foo", 1, 0);
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void Quality_ForAgedBrie_Increases()
        {
            var items = SetupTest(GildedRose.AGED_BRIE, 1, 1);
            Assert.AreEqual(2, items[0].Quality);
        }

        [Test]
        public void Quality_CannotExceedFifty()
        {
            var items = SetupTest(GildedRose.AGED_BRIE, 1, 50);
            Assert.AreEqual(50, items[0].Quality);
        }

        [Test]
        public void Quality_ForSulfuras_IsConstant()
        {
            var items = SetupTest(GildedRose.SULFURAS, 1, 80);
            Assert.AreEqual(80, items[0].Quality);
        }

        [Test]
        public void SellIn_ForSulfuras_IsConstant()
        {
            var items = SetupTest(GildedRose.SULFURAS, 1, 80);
            Assert.AreEqual(1, items[0].SellIn);
        }

        [Test]
        public void Quality_ForBackstagePasses_Increases()
        {
            var items = SetupTest(GildedRose.BACKSTAGE_PASS, 11, 1);
            Assert.AreEqual(2, items[0].Quality);
        }

        [Test]
        public void Quality_ForBackstagePassesAndSellInLessThanTen_IncreasesByTwo()
        {
            var items = SetupTest(GildedRose.BACKSTAGE_PASS, 10, 1);
            Assert.AreEqual(3, items[0].Quality);
        }

        [Test]
        public void Quality_ForBackstagePassesAndSellInLessThanFive_IncreasesByThree()
        {
            var items = SetupTest(GildedRose.BACKSTAGE_PASS, 5, 1);
            Assert.AreEqual(4, items[0].Quality);
        }

        [Test]
        public void Quality_ForBackstagePassesAndZeroSellIn_IsZero()
        {
            var items = SetupTest(GildedRose.BACKSTAGE_PASS, 0, 1);
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void Quality_ForConjured_DecreasesTwiceAsFast()
        {
            var items = SetupTest(GildedRose.CONJURED, 1, 2);
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void Quality_ForConjuredAndZeroSellIn_DecreasesFourTimesAsFast()
        {
            var items = SetupTest(GildedRose.CONJURED, 0, 4);
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void Quality_ForConjuredAndNegativeSellIn_DecreasesFourTimesAsFast()
        {
            var items = SetupTest(GildedRose.CONJURED, -1, 4);
            Assert.AreEqual(0, items[0].Quality);
        }
    }
}