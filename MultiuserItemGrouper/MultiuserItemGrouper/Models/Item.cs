using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiuserItemGrouper.Models
{
    public class Item
    {
   //object for the items
            private string ItemName { get; set; }//holds item name
            private string ItemText { get; set; }//holds item's text
            private int GroupID { get; set; }//groupID
            private int ItemID { get; set; }//itemID
            private user User { get; set; }//owner
            private bool hidden { get; set; }//hidden boolean
            private bool locked { get; set; }//locked boolean

            //create item
            public Item(Item newitem)
            {
                this.ItemName = newitem.ItemName;
                this.ItemText = newitem.ItemText;
                this.GroupID = newitem.GroupID;
                this.ItemID = newitem.ItemID;
                this.User = newitem.User;
                this.hidden = newitem.hidden;
                this.locked = newitem.locked;
            }
            //update item
            public void updateItem(Item newitem)
            {
                //loop through to find the right item then do this.
                this.ItemName = newitem.ItemName;
                this.ItemText = newitem.ItemText;
                this.GroupID = newitem.GroupID;
                this.ItemID = newitem.ItemID;
                this.User = newitem.User;
                this.hidden = newitem.hidden;
                this.locked = newitem.locked;
            }

            //unlock item

            //lock item

            //delete item

        
    }
}
