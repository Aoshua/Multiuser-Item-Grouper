using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MultiuserItemGrouper.Models
{
    public static class Storage
    {
        //private list holding the objects of groups.
        private static List<Group> AllGroups { get; set; }//holds all the groups
        private static List<int> GroupIDs { get; set; }//keeps track of all the group ID's

        public static List<User> Users { get; set; }


        //update group <- don't see use in this List

        //add group
        public static void AddGroup(Group group)
        {
            AllGroups.Add(group);
            GroupIDs.Add(group.GroupID);
        }
        //add group overload
        public static void AddGroup(string name, string user)
        {
            int maxID = 0;
            foreach (int i in GroupIDs)
            {
                if(maxID <= i)
                {
                    maxID = i + 1;
                }
            }

            Group group = new Group();
            group.createGroup(maxID, name, user);
            AllGroups.Add(group);
        }

        //delete group
        public static void DeleteGroup(Group group, string user)
        {
            if (group.OwnerName == user)
            {
                AllGroups.Remove(group);
            }
        }

        //return group's
        public static string GetGroups()
        {
            string json = JsonConvert.SerializeObject(AllGroups, Formatting.None);
            return json;
        }
        //return group's names
        public static string GetGroupNames()
        {
            List<string> names = new List<string>();
            foreach (Group group in AllGroups)
            {
                names.Add(group.GroupName);
            }
            string json = JsonConvert.SerializeObject(names, Formatting.None);
            return json;
        }

        //add item
        public static void AddItemToGroup(Item item)
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
        public static void RemoveItemFromGroup(Item item)
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
        public static void EditItemInGroup(Item item)
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
        public static string ReturnItemsInGroup(Group group, User user)
        {
            foreach(Group groups in AllGroups)
            {
                if(group.GroupID == groups.GroupID)
                {
                    return groups.returnItems(user);
                }
            }
            return "";
        }

        //return items overload
        public static string ReturnItemsInGroup(int groupID, User user)
        {
            foreach (Group groups in AllGroups)
            {
                if (groupID == groups.GroupID)
                {
                    return groups.returnItems(user);
                }
            }
            return "";
        }
        //return items overload
        public static string ReturnItemsInGroup(int groupID, int UserID)
        {
            foreach (Group groups in AllGroups)
            {
                if (groupID == groups.GroupID)
                {
                    return groups.returnItems(UserID);
                }
            }
            return "";
        }

        public static  User getUser(string username)
        {
            foreach (User user in Users)
            {
                if(user.Name == username)
                {
                    return user;
                }
            }
            User newUser = new User(username);
            Users.Add(newUser);
            return newUser;
        }
    }
}
