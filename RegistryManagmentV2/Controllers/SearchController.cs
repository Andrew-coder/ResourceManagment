using System;
using System.Collections.ObjectModel;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using RegistryManagmentV2.Models;
using RegistryManagmentV2.Services;

namespace RegistryManagmentV2.Controllers
{
    public class SearchController : Controller
    {
        private readonly ITagService _tagService = new TagService();
        private readonly ISearchService _searchService = new SearchService();
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: /Search
        public ActionResult SearchResources(SearchViewModel searhViewModel)
        {
            if (String.IsNullOrEmpty(searhViewModel.Tags))
            {
                return RedirectToAction("Index", "Catalog");
            }
            var tagNames = new Collection<string>(searhViewModel.Tags.Split(','));
            var isAdmin = User.IsInRole("Admin");
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var user = UserManager.FindById(identity.Identity.GetUserId());
            var resources = _searchService.SearchResourcesByTags(tagNames, user, isAdmin);
            return View("SearchResults", resources);
        }
    }
}