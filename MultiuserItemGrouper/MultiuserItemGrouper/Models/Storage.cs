using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiuserItemGrouper.Models
{
    public static class Storage
    {
        public static List<User> Users { get; set; }
        public static List<Group> Groups { get; set; }

        static Storage()
        {
            Users = new List<User>();
            Groups = new List<Group>();
        }
    }
}
