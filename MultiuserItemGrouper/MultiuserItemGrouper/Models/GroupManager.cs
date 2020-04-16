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

        // Add Item to Group

        // Remove Item from Group

        // Update Item in Group

        // Serialize a selected group
        public static string SerializeGroupForUser(string groupName, string user)
        {
            return ""; // todo
        }

        private static Group FindGroupByName(string name)
        {
            // todo: proper implementation for a discardable group (class?)
            Group selectedGroup = new Group("discardable");

            /*foreach (Group group in Groups)
            {
                if (name == group.Name)
                    selectedGroup = group;
            }

            return selectedGroup;*/

            // This returns the first (and only in this case) group with the exact same name:
            return Groups.Where(g => g.Name == name).FirstOrDefault(); 
        }
    }
}
