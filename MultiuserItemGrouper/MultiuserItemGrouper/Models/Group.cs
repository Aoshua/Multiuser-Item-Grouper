using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MultiuserItemGrouper.Models
{
    
    public class Group
    {//object for the group
        
        public int GroupID { get; set; }//group ID
        public string GroupName { get; set; }//holds group name
        public string OwnerName { get; set; }//owner
        public List<Item> ItemList { get; set; }//list of item object

        public Group()
        {
        }
        //create group
        public void createGroup(Group group)
        {
            this.GroupID = group.GroupID;
            this.GroupName = group.GroupName;
            this.OwnerName = group.OwnerName;
            this.ItemList = group.ItemList;
        }
        
        //create group overload
        public void createGroup(int id, string groupName, string ownerName)
        {
            this.GroupID = id;
            this.GroupName = groupName;
            this.OwnerName = ownerName;
            this.ItemList = new List<Item>();
        }

        // Use Context.Items has 

        //add Item
        public void addItem(Item item)
        {
            this.ItemList.Add(item);
        }

        //delete Item
        public void deleteItem(Item item)
        {

            if (this.ItemList.Contains(item))
            {
                ItemList.Remove(item);
            }
            
        }
        
        //editItem
        public void editItem(Item item)
        {
            ItemList.Remove(new Item()
            {
                ItemID = item.ItemID,
                GroupID = item.GroupID,
                IsHidden = item.IsHidden,
                IsLocked = item.IsLocked,
                ItemName = item.ItemName,
                ItemText = item.ItemText,
                UserID = item.UserID
            });
            ItemList.Add(item);
        }
        
        //getItemlist
        public string returnItems(string user)
        {
            List<Item> Itemlist = new List<Item>();
            foreach (Item items in ItemList)
            {
                if(items.IsHidden == false || items.IsHidden == true)
                {
                    Itemlist.Add(items);
                }

            }

            string json = JsonConvert.SerializeObject(ItemList, Formatting.None);
            return json;
        }

        //getItemlist overload
        public string returnItems(int user)
        {
            List<Item> Itemlist = new List<Item>();
            foreach (Item items in ItemList)
            {
                if (items.IsHidden == false || items.IsHidden == true && items.UserID == user)
                {
                    Itemlist.Add(items);
                }

            }

            string json = JsonConvert.SerializeObject(ItemList, Formatting.None);
            return json;
        }
    }
}
