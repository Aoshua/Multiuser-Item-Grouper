using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MultiuserItemGrouper.Models
{
    public class Storage
    {
        //private list holding the objects of groups.
        private List<Group> AllGroups { get; set; }//holds all the groups


        //update group <- don't see use in this List

        //add group
        public void AddGroup(Group group)
        {
            AllGroups.Add(group);
        }

        //delete group
        public void DeleteGroup(Group group)
        {
            AllGroups.Remove(group);
        }

        //return group's
        public string GetGroups()
        {
            string json = JsonConvert.SerializeObject(AllGroups, Formatting.None);
            return json;
        }

        //add item
        public void AddItemToGroup(Item item)
        {
            foreach (Group groups in AllGroups)
            {
                if(groups.GroupID == item.GroupID)
                {
                    groups.addItem(item);
                }
            }
        }

        //remove item
        public void RemoveItemFromGroup(Item item)
        {
            foreach (Group groups in AllGroups)
            {
                if (groups.GroupID == item.GroupID)
                {
                    groups.deleteItem(item);
                }
            }
        }

        //edit item
        public void EditItemInGroup(Item item)
        {
            foreach (Group groups in AllGroups)
            {
                if (groups.GroupID == item.GroupID)
                {
                    groups.editItem(item);
                }
            }
        }

        //return items
        public string ReturnItemsInGroup(Group group, User user)
        {
            foreach(Group groups in AllGroups)
            {
                if(group.GroupID == groups.GroupID)
                {
                    return group.returnItems(user);
                }
            }
            return "";
        }

    }
}
