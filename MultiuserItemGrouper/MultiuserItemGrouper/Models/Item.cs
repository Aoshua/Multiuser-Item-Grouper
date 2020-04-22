using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiuserItemGrouper.Models
{
    public class Item
    {
        public static int ItemCount = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public string Owner { get; set; }
        public bool IsHidden { get; set; }
        public bool IsLocked { get; set; }

        //create item
        public Item(string name, string body, string owner, bool IsHidden)
        {
            // ItemIDs are based off the ItemCount,
            // which shall increment each time a new Item is created.
            this.Id = ItemCount;
            ItemCount++;

            this.Name = name;
            this.Body = body;
            this.Owner = owner;
            this.IsHidden = IsHidden;
            this.IsLocked = false;
        }

        public SerializableItem ConvertToSerializableItem()
        {
            SerializableItem si = new SerializableItem
            {
                Id = this.Id,
                Name = this.Name,
                Body = this.Body,
                IsLocked = this.IsLocked,
                IsHidden = this.IsHidden
            };
            return si;
        }
    }

    public struct SerializableItem
    {
        public int Id;
        public string Name;
        public string Body;
        public bool IsLocked;
        public bool IsHidden;
    }
}
