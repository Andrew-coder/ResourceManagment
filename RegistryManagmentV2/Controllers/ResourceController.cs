using System;
using System.Data.Entity;
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
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private readonly IResourceService _resourceService = new ResourceService();

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
        public ActionResult Create()
        {
            return View();
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
        public ActionResult Edit(int? id)
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
        public ActionResult Edit([Bind(Include = "Id")] Resource resource)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(resource).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
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
            Resource resource = _db.Resources.Find(id);
            _db.Resources.Remove(resource);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
