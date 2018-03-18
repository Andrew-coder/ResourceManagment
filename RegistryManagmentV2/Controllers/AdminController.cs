using System.Linq;
using System.Web.Mvc;
using RegistryManagmentV2.Services;

namespace RegistryManagmentV2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationUserManager _userManager;
        private IResourceService _resourceService;

        public ActionResult UsersManagment()
        {
            return View(_userManager.Users.ToList());
        }

        // GET: UserManagment
        public ActionResult ResourceManagment()
        {
            return View();
        }
    }
}