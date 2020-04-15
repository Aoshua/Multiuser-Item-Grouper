using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiuserItemGrouper.Models
{
    public class Item
    {
        //object for the items
        public int ItemID { get; set; }//itemID
        public string ItemName { get; set; }//holds item name
        public string ItemText { get; set; }//holds item's text
        public int GroupID { get; set; }//groupID
        public int UserID { get; set; }//owner
        public bool IsHidden { get; set; }//hidden boolean
        public bool IsLocked { get; set; }//locked boolean

        //create item
        public Item(Item newitem)
        {
            ItemName = newitem.ItemName;
            ItemText = newitem.ItemText;
            GroupID = newitem.GroupID;
            ItemID = newitem.ItemID;
            UserID = newitem.UserID;
            IsHidden = newitem.IsHidden;
            IsLocked = newitem.IsLocked;
        }
        public Item()
        {
            ItemName = "";
            ItemText = "";
            GroupID = -1;
            ItemID = -1;
            UserID = -1;
            IsHidden = false;
            IsLocked = false;
        }
        //update item
        public void updateItem(Item newitem)
        {
            //loop through to find the right item then do this.
            ItemName = newitem.ItemName;
            ItemText = newitem.ItemText;
            GroupID = newitem.GroupID;
            ItemID = newitem.ItemID;
            UserID = newitem.UserID;
            IsHidden = newitem.IsHidden;
            IsLocked = newitem.IsLocked;
        }

        //unlock item

        //lock item

        //delete item

        
    }
}
