using System;
using System.Collections.Generic;

namespace GildedRose
{
    internal class GildedRose
    {
        public const string AGED_BRIE = "Aged Brie";
        public const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        public const string BACKSTAGE_PASS = "Backstage passes to a TAFKAL80ETC concert";

        public static void UpdateQuality(IList<Item> items)
        {
            foreach (var item in items)
                UpdateQuality(item);
        }

        private static void UpdateQuality(Item item)
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