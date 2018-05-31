using System;
using System.Collections.ObjectModel;
using System.Web.Mvc;
using RegistryManagmentV2.Models;
using RegistryManagmentV2.Services;

namespace RegistryManagmentV2.Controllers
{
    public class SearchController : Controller
    {
        private readonly ITagService _tagService = new TagService();
        private readonly ISearchService _searchService = new SearchService();

        // GET: /Search
        public ActionResult SearchResources(SearchViewModel searhViewModel)
        {
            if (String.IsNullOrEmpty(searhViewModel.Tags))
            {
                return RedirectToAction("Index", "Catalog");
            }
            var tagNames = new Collection<string>(searhViewModel.Tags.Split(','));
            var isAdmin = User.IsInRole("Admin");
            var resources = _searchService.SearchResourcesByTags(tagNames, isAdmin);
            return View("SearchResults", resources);
        }
    }
}