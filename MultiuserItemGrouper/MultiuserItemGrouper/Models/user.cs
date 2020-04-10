using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiuserItemGrouper.Models
{
		//object for owner
	public class User // object to keep track of the Users
	{
		public int Id { get; set; }//owner id

		public string  Name { get; set; }//owner name
		public User(string name, int id) //make an owner
		{
			Id = id;
			Name = name;
		}
	}
}
