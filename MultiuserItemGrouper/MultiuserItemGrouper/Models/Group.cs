using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MultiuserItemGrouper.Models
{
    public class Group
    {
        public string Name { get; set; }
        public List<Item> Items { get; set; }

        public Group(string name)
        {
            this.Name = name;
            this.Items = new List<Item>();
        }
        
        // todo return serialized group
        public string returnItems(string user)
        {
            return "";
        }

        public SerializableGroup SerializeGroupForUser(string user)
        {
            SerializableGroup sg = new SerializableGroup();
            sg.Name = this.Name;
            sg.Items = new List<SerializableItem>();

            foreach (Item item in Items)
            {
                SerializableItem si = item.ConvertToSerializableItem();

                // Unlock the item in display if the user is the owner.
                if (user == item.Owner)
                {
                    si.IsLocked = false;
                }

                // Do not show the item if the item is hidden and the user
                // is not the owner.
                if (item.IsHidden)
                {
                    if (user == item.Owner)
                    {
                        sg.Items.Add(si);
                    }
                }
                else
                {
                    sg.Items.Add(si);
                }
            }

            return sg;
        }
    }

    public struct SerializableGroup
    {
        public string Name;
        public List<SerializableItem> Items;
    }
}
