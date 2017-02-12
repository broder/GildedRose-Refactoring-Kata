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
            var app = new GildedRose(items);
            app.UpdateQuality();
            return items;
        }

        [Test]
        public void NameUnchanging()
        {
            var items = SetupTest("foo", 1, 1);
            Assert.AreEqual("foo", items[0].Name);
        }

        [Test]
        public void SellInDecreases()
        {
            var items = SetupTest("foo", 1, 1);
            Assert.AreEqual(0, items[0].SellIn);
        }

        [Test]
        public void QualityDecreases()
        {
            var items = SetupTest("foo", 1, 1);
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void QualityDecreasesTwiceAsFastIfSellInZero()
        {
            var items = SetupTest("foo", 0, 2);
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void QualityDecreasesTwiceAsFastIfSellInNegative()
        {
            var items = SetupTest("foo", -1, 2);
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void QualityNeverNegative()
        {
            var items = SetupTest("foo", 1, 0);
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void AgedBrieQualityIncreases()
        {
            var items = SetupTest(GildedRose.AGED_BRIE, 1, 1);
            Assert.AreEqual(2, items[0].Quality);
        }

        [Test]
        public void QualityCannotExceedFifty()
        {
            var items = SetupTest(GildedRose.AGED_BRIE, 1, 50);
            Assert.AreEqual(50, items[0].Quality);
        }

        [Test]
        public void SulfurasQualityConstant()
        {
            var items = SetupTest(GildedRose.SULFURAS, 1, 1);
            Assert.AreEqual(1, items[0].Quality);
        }

        [Test]
        public void SulfurasSellInConstant()
        {
            var items = SetupTest(GildedRose.SULFURAS, 1, 1);
            Assert.AreEqual(1, items[0].SellIn);
        }

        [Test]
        public void BackstagePassesQualityIncreases()
        {
            var items = SetupTest(GildedRose.BACKSTAGE_PASS, 11, 1);
            Assert.AreEqual(2, items[0].Quality);
        }

        [Test]
        public void BackstagePassesQualityIncreasesByTwoIfLessThanTen()
        {
            var items = SetupTest(GildedRose.BACKSTAGE_PASS, 10, 1);
            Assert.AreEqual(3, items[0].Quality);
        }

        [Test]
        public void BackstagePassesQualityIncreasesByThreeIfLessThanFive()
        {
            var items = SetupTest(GildedRose.BACKSTAGE_PASS, 5, 1);
            Assert.AreEqual(4, items[0].Quality);
        }

        [Test]
        public void BackstagePassesQualityZeroAfterSellIn()
        {
            var items = SetupTest(GildedRose.BACKSTAGE_PASS, 0, 1);
            Assert.AreEqual(0, items[0].Quality);
        }
    }
}