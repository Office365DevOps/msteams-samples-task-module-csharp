using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.Teams.Samples.TaskModule.Web
{
    public static class ItemDB
    {
        public static List<ItemInfo> Items;
        static ItemDB()
        {
            Items = new List<ItemInfo>();
            Items.AddRange(LoadItems());
        }

        public static void AddItem(ItemInfo item)
        {
            if (item == null)
                return;

            Items.Add(item);
        }

        public static List<ItemInfo> SearchItems(string nameKeyword)
        {
            return (from item in Items
                    where item.Name.Contains(nameKeyword) || item.Description.Contains(nameKeyword)
                    select item).ToList();
        }

        public static List<ItemInfo> LoadItems()
        {
            var random = new Random();
            var items = new List<ItemInfo>();
            items.Add(new ItemInfo() { Id = Guid.NewGuid(),
                Name = "Microsoft surface Book / Book 2 1798 AC Charger",
                Description = "Original 102W Power Adapter For Microsoft surface Book / Book 2 1798 AC Charger",
                CreatedUser = "Griffin Liu",
                Image = "https://c1.neweggimages.com/ProductImageCompressAll300/V017_1_201903041648712141.jpg",
                CreatedTime = DateTime.Now,
                Link = "https://www.newegg.com/Product/Product.aspx?Item=9SIAH9B8ZS0459&Description=book&cm_re=book-_-9SIAH9B8ZS0459-_-Product",
                StarCount = random.Next(1000),
                UpdatedTime = DateTime.Now.AddHours(-81536) });
            items.Add(new ItemInfo()
            {
                Name = "Laptop Battery",
                Description = "BattPit: Laptop Battery Replacement for Samsung Notebook 9 NP900X5L-K02US, AA-PBUN4AR, Notebook 9 900X5L, ATIV Book 9 Spin 940X3L (7.7V 4000mAh 31Wh)",
                CreatedUser = "Jerry Wu",
                Image = "https://c1.neweggimages.com/NeweggImage/ProductImageCompressAll300/A3E4_1_201805311072186346.jpg",
                Link = "https://www.newegg.com/Product/Product.aspx?Item=9SIA3E47F30202&Description=book&cm_re=book-_-9SIA3E47F30202-_-Product",
                StarCount = random.Next(1000),
                CreatedTime = DateTime.Now.AddHours(-546),
            });
            items.Add(new ItemInfo()
            {
                Name = "Microsoft Surface Book 2",
                Description = "Microsoft Surface Book 2 HNN-00001 Intel Core i7 8th Gen 8650U (1.90 GHz) 16 GB Memory 1 TB PCIe SSD NVIDIA GeForce GTX 1050 13.5",
                CreatedUser = "Tom Yang",
                Image = "https://images10.newegg.com/ProductImageCompressAll300/34-735-554-V01.jpg",
                Link = "https://www.newegg.com/Product/Product.aspx?Item=9SIA3E47F30202&Description=book&cm_re=book-_-9SIA3E47F30202-_-Product",
                StarCount = random.Next(1000),
                CreatedTime = DateTime.Now.AddHours(-48611),
            });

            return items;
        }
    }

    public class ItemInfo
    {
        [JsonProperty("Id")]
        public Guid Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("Link")]
        public string Link { get; set; }
        [JsonProperty("CreatedUser")]
        public string CreatedUser { get; set; }
        public string UpdatedUser { get; set; }
        [JsonProperty("Image")]
        public string Image { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }

        [JsonProperty("WantToSee")]
        public bool WantToSee { get; set; }
        public int WantToSeeCount { get; set; }
        [JsonProperty("Star")]
        public bool Star { get; set; }
        public int StarCount { get; set; }
    }
}