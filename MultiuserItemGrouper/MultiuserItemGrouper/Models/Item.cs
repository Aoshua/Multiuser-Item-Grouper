using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiuserItemGrouper.Models
{
    public class Item
    {
        //object for the items
        private int ItemID { get; set; }//itemID
        private string ItemName { get; set; }//holds item name
        private string ItemText { get; set; }//holds item's text
        private int GroupID { get; set; }//groupID
        private int UserID { get; set; }//owner
        private bool IsHidden { get; set; }//hidden boolean
        private bool IsLocked { get; set; }//locked boolean

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
