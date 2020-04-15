using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiuserItemGrouper.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiuserItemGrouper.Controllers
{
    public class LoginController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogUser(string txtUsername)
        {
            // If the list does not contain another username with the same name, add the
            // username to the list of users.
            if(Storage.Users.Where(u => u.Name == txtUsername).Count() == 0)
            {
                Storage.Users.Add(new User(txtUsername, Storage.Users.Count() + 1));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Inform user that that name is taken
                return View();
            }
        }
    }
}
