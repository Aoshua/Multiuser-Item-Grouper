using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiuserItemGrouper.Models
{
    public static class Storage
    {
        //private list holding the objects of groups.
        public static List<User> Users { get; set; }
        public static List<Group> Groups { get; set; }
    }
}
