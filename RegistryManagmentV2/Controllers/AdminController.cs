using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistryManagmentV2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationUserManager _userManager;

        public ActionResult ManageUsers()
        {
            return View("UsersManagment");
        }

        // GET: UserManagment
        public ActionResult ManageResources()
        {
            return View();
        }
    }
}