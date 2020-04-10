using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiuserItemGrouper.Models
{
    public class user
    {
		//object for owner
		public class User // object to keep track of the Users
		{
			public string  name { get; set; }//owner name
			public int id { get; set; }//owner id
			public User(string name, int id) //make an owner
			{
				this.name = name;
				this.id = id;
			}
		}
	}
}
