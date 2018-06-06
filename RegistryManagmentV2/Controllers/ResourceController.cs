using System;
using System.Net;
using System.Web.Mvc;
using RegistryManagmentV2.Controllers.Attributes;
using RegistryManagmentV2.Models;
using RegistryManagmentV2.Models.Domain;
using RegistryManagmentV2.Services;

namespace RegistryManagmentV2.Controllers
{
    [ClaimsAuthorize(AccountStatus = AccountStatus.Approved)]
    public class ResourceController : Controller
    {
        private const int DefaultSecurityLevel = 5;
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private readonly IResourceService _resourceService = new ResourceService();
        private readonly ICatalogService _catalogService = new CatalogService();

        // GET: Resource/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var resource = _db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // GET: Resource/Create
        public ActionResult Create(long? catalogId)
        {
            var catalog = _catalogService.GetById(catalogId.GetValueOrDefault());
            var securityLevel = DefaultSecurityLevel;
            if (catalog != null)
            {
                securityLevel = catalog.SecurityLevel;
            }
            return View(new ResourceViewModel{SecurityLevel = securityLevel});
        }

        // POST: Resource/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ResourceViewModel resourceViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {    
                    var catalogId = resourceViewModel.CatalogId ?? default(int);
                    _resourceService.CreateResource(resourceViewModel, catalogId);
                    return RedirectToAction("Index", "Catalog");  
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                } 
            }

            return View(resourceViewModel);
        }

        // GET: Resource/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = _db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // POST: Resource/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UpdateResourceViewModel resourceViewModel)
        {
            var resource = _resourceService.GetById(resourceViewModel.Id.GetValueOrDefault(-1));
            if (resource == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (!User.IsInRole("Admin"))
            {
                resource.ResourceStatus = ResourceStatus.PendingForEditApprove;
            }
            if (ModelState.IsValid)
            {
                _resourceService.UpdateResource(resourceViewModel, resource);
            }
            return View(resource);
        }

        // GET: Resource/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = _db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // POST: Resource/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var resource = _db.Resources.Find(id);
            _db.Resources.Remove(resource);
            _db.SaveChanges();
            return RedirectToAction("Index", "Catalog");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult ViewResourceDocument(string fileName)
        {
            System.Diagnostics.Process.Start(fileName);
            return RedirectToAction("Index", "Catalog");
        }
    }
}
