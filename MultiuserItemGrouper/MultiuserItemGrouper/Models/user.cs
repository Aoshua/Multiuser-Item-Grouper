using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiuserItemGrouper.Models
{
		//object for owner
	public class User // object to keep track of the Users
	{
		public string  Name { get; set; }//owner name
		public User(string name) //make an owner
		{
			Name = name;
		}
	}
}
