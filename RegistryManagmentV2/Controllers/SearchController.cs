using System.Collections.ObjectModel;
using System.Net;
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
            var tagNames = new Collection<string>(searhViewModel.Tags.Split(','));
            //var tags = _tagService.GetTagsWithNames(tagNames);
            var resources = _searchService.SearchResourcesByTags(tagNames);
            return View("SearchResults", resources);
        }
    }
}