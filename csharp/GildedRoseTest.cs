using System.Collections.Generic;
using NUnit.Framework;

namespace GildedRose
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void NameUnchanging()
        {
            IList<Item> items = new List<Item> {new Item {Name = "foo", SellIn = 1, Quality = 1}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual("foo", items[0].Name);
        }

        [Test]
        public void SellInDecreases()
        {
            var sellIn = 2;
            IList<Item> items = new List<Item> {new Item {Name = "foo", SellIn = sellIn, Quality = 1}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(sellIn - 1, items[0].SellIn);
        }

        [Test]
        public void QualityDecreases()
        {
            var quality = 1;
            IList<Item> items = new List<Item> {new Item {Name = "foo", SellIn = 1, Quality = quality}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(quality - 1, items[0].Quality);
        }

        [Test]
        public void QualityDecreasesTwiceAsFastIfSellInZero()
        {
            var quality = 2;
            IList<Item> items = new List<Item> {new Item {Name = "foo", SellIn = 0, Quality = quality}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(quality - 2, items[0].Quality);
        }

        [Test]
        public void QualityDecreasesTwiceAsFastIfSellInNegative()
        {
            var quality = 2;
            IList<Item> items = new List<Item> {new Item {Name = "foo", SellIn = -1, Quality = quality}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(quality - 2, items[0].Quality);
        }

        [Test]
        public void QualityNeverNegative()
        {
            var quality = 0;
            IList<Item> items = new List<Item> {new Item {Name = "foo", SellIn = 1, Quality = quality}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void AgedBrieQualityIncreases()
        {
            var quality = 1;
            IList<Item> items = new List<Item> {new Item {Name = "Aged Brie", SellIn = 1, Quality = quality}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(quality + 1, items[0].Quality);
        }

        [Test]
        public void QualityCannotExceedFifty()
        {
            var quality = 50;
            IList<Item> items = new List<Item> {new Item {Name = "Aged Brie", SellIn = 1, Quality = quality}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(quality, items[0].Quality);
        }

        [Test]
        public void SulfurasQualityConstant()
        {
            var quality = 1;
            IList<Item> items = new List<Item> {new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = quality}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(quality, items[0].Quality);
        }

        [Test]
        public void SulfurasSellInConstant()
        {
            var sellIn = 1;
            IList<Item> items = new List<Item> {new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = 1}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(sellIn, items[0].SellIn);
        }

        [Test]
        public void BackstagePassesQualityIncreases()
        {
            var quality = 1;
            IList<Item> items = new List<Item> {new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = quality}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(quality + 1, items[0].Quality);
        }

        [Test]
        public void BackstagePassesQualityIncreasesByTwoIfLessThanTen()
        {
            var quality = 1;
            IList<Item> items = new List<Item> {new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = quality}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(quality + 2, items[0].Quality);
        }

        [Test]
        public void BackstagePassesQualityIncreasesByThreeIfLessThanFive()
        {
            var quality = 1;
            IList<Item> items = new List<Item> {new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = quality}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(quality + 3, items[0].Quality);
        }

        [Test]
        public void BackstagePassesQualityZeroAfterSellIn()
        {
            var quality = 1;
            IList<Item> items = new List<Item> {new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = quality}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(0, items[0].Quality);
        }
    }
}