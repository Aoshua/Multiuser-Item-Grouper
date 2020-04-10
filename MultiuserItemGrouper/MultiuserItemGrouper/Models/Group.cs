using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiuserItemGrouper.Models
{
    public class Group
    {//object for the group
        private string GroupName { get; set; }//holds group name
        private int GroupID { get; set; }//group ID
        private user Owner { get; set; }//owner
        private List<Item> ItemList { get; set; }//list of item object

        //create group
        public Group(Group group)
        {
            this.GroupID = group.GroupID;
            this.GroupName = group.GroupName;
            this.Owner = group.Owner;
            this.ItemList = group.ItemList;
        }

        //update group

        //return group's

        //delete group
    }
}
