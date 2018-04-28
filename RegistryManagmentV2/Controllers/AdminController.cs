using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web.Mvc;
using RegistryManagmentV2.Models.Domain;
using RegistryManagmentV2.Services;

namespace RegistryManagmentV2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationUserManager _userManager;
        private readonly ICatalogService _catalogService = new CatalogService();
        private readonly IResourceService _resourceService = new ResourceService();

        public ActionResult UsersManagment()
        {
            return View(_userManager.Users.ToList());
        }

        // GET: UserManagment
        public ActionResult ResourceManagment(long? catalogId)
        {
            List<Catalog> catalogs;
            List<Resource> resources;
            
            catalogs = _catalogService.GetAllCatalogs(catalogId);
            resources = _resourceService.GetAllResources(catalogId);

            var tuple = new Tuple<List<Catalog>, List<Resource>>(catalogs, resources);
            return View("~/Views/Catalog/Index.cshtml", tuple);
        }

        public ActionResult ApproveResource(long id)
        {
            _resourceService.ApproveResource(id);
            return RedirectToAction("ResourceManagment");
        }
    }
}