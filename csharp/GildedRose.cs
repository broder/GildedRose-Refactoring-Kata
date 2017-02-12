using System;
using System.Collections.Generic;

namespace GildedRose
{
    internal class GildedRose
    {
        private readonly IList<Item> Items;
        public const string AGED_BRIE = "Aged Brie";
        public const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        public const string BACKSTAGE_PASS = "Backstage passes to a TAFKAL80ETC concert";

        public GildedRose(IList<Item> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
                UpdateQuality(item);
        }

        private void UpdateQuality(Item item)
        {
            switch (item.Name)
            {
                case SULFURAS:
                    return;

                case AGED_BRIE:
                    item.Quality++;
                    break;

                case BACKSTAGE_PASS:
                    if (item.SellIn == 0)
                        item.Quality = 0;
                    else if (item.SellIn <= 5)
                        item.Quality += 3;
                    else if (item.SellIn <= 10)
                        item.Quality += 2;
                    else
                        item.Quality++;
                    break;

                default:
                    if (item.SellIn <= 0)
                        item.Quality -= 2;
                    else
                        item.Quality--;
                    break;
            }

            item.Quality = Math.Max(0, Math.Min(50, item.Quality));
            item.SellIn--;
        }
    }
}