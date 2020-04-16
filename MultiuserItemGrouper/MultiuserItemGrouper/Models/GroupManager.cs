using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MultiuserItemGrouper.Models
{
    public static class GroupManager
    {
        public static List<Group> Groups { get; set; }

        public enum CreateGroupResult
        {
            FAIL = 0,
            SUCCESS = 1
        }

        static GroupManager()
        {
            Groups = new List<Group>();
        }

        // Return list of group names.
        public static string GetGroupNames()
        {
            List<string> GroupNames = new List<string>();
            foreach (Group group in Groups)
            {
                GroupNames.Add(group.Name);
            }

            return JsonConvert.SerializeObject(GroupNames);
        }

        // Create Group, check that name has not already been used
        public static CreateGroupResult CreateGroup(string name)
        {
            foreach (Group group in Groups)
            {
                if (name == group.Name)
                {
                    return CreateGroupResult.FAIL;
                }
            }

            Groups.Add(new Group(name));
            return CreateGroupResult.SUCCESS;
        }

        // todo the endless "what if the group doesn't exist?"
        public static void AddItem(string owner, string groupName, string itemName, string itemBody)
        {
            FindGroupByName(groupName).Items.Add(new Item(itemName, itemBody, owner));
        }

        // todo possibly add owner permission?
        public static void LockItem(string user, string groupName, int itemId)
        {
            FindGroupByName(groupName).Items.Where(i => i.Id == itemId).FirstOrDefault().IsLocked = true;
        }

        // todo catch possible null? add owner permission?
        public static void UnlockItem(string user, string groupName, int itemId)
        {
            FindGroupByName(groupName).Items.Where(i => i.Id == itemId).FirstOrDefault().IsLocked = false;
        }

        // todo
        // Delete Item from Group
        public static void DeleteItem(string user, string groupName, int itemId)
        {
            Group g = FindGroupByName(groupName);
            Item toDelete = g.Items.Where(i => i.Id == itemId).FirstOrDefault();
            if (toDelete.Owner == user)
            {
                g.Items.Remove(toDelete);
            }

            // todo should figure out a way to return errors like
            // "Not owner of item", "Item does not exist"
        }

        // todo maybe add owner permissions? skipping for now
        // Update Item in Group
        public static void UpdateItem(string user, string groupName, int itemId, 
            string itemName, string itemBody, bool hideItem)
        {
            
        }

        // todo
        // Serialize a selected group
        public static string SerializeGroupForUser(string groupName, string user)
        {
            // todo edge case for not-found group
            return JsonConvert.SerializeObject(FindGroupByName(groupName).SerializeGroupForUser(user));
        }

        // todo: null pointer exception if not found??
        private static Group FindGroupByName(string name)
        {
            // This returns the first (and only in this case) group with the exact same name:
            return Groups.Where(g => g.Name == name).FirstOrDefault(); 
        }
    }
}
