﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using RegistryManagmentV2.Controllers.Attributes;
using RegistryManagmentV2.Models;
using RegistryManagmentV2.Models.Domain;
using RegistryManagmentV2.Services;

namespace RegistryManagmentV2.Controllers
{
    [ClaimsAuthorize(AccountStatus = AccountStatus.Approved)]
    public class CatalogController : Controller
    {
        private readonly ICatalogService _catalogService = new CatalogService();
        private readonly IResourceService _resourceService = new ResourceService();
        private readonly IUserGroupService _userGroupService = new UserGroupService();
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;



        public ApplicationUserManager UserManager {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Catalog
        public ActionResult Index(long? catalogId)
        {
            var catalogs = new List<Catalog>();
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var user = UserManager.FindById(identity.Identity.GetUserId());
            var isAdmin = User.IsInRole("Admin");
            if (isAdmin)
            {
                catalogs = _catalogService.GetAllCatalogs(catalogId);
            }
            else
            {
                var userGroup = identity.Claims
                    .Where(c => c.Type == "userGroup")
                    .Select(c => c.Value)
                    .SingleOrDefault();
                catalogs = _catalogService.GetChildCatalogsByUserGroup(catalogId, userGroup);
            }
            var resources = _resourceService.GetAllResourcesForCatalogAndUser(catalogId, user, isAdmin);
            var tuple = new Tuple<IList<Catalog>, IList<Resource>>(catalogs, resources);
            return View(tuple);
        }

        // GET: Catalog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalog catalog = db.Catalogs.Find(id);
            if (catalog == null)
            {
                return HttpNotFound();
            }
            return View(catalog);
        }
        
        // GET: Catalog/Create
        public ActionResult Create(int? id)
        {
            var userGroups = _userGroupService.GetAllUserGroups();
            var tuple = new Tuple<CatalogViewModel, List<UserGroup>>(new CatalogViewModel {SecurityLevel = 5}, userGroups);
            return View(tuple);
        }

        // POST: Catalog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CatalogViewModel catalogViewModel)
        {
            
            var catalog = new Catalog();
            catalog.SuperCatalogId = catalogViewModel.CatalogId;
            catalog.Name = catalogViewModel.Name;
            if(!String.IsNullOrEmpty(catalogViewModel.Groups))
            catalog.UserGroups = _userGroupService.GetUserGroupsWithNames(new Collection<string>(catalogViewModel.Groups.Split(',')));
            if (ModelState.IsValid)
            {
                _catalogService.SaveCatalog(catalog);
                return RedirectToAction("Index");
            }

            return View(catalogViewModel);
        }

        // GET: Catalog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalog catalog = db.Catalogs.Find(id);
            if (catalog == null)
            {
                return HttpNotFound();
            }
            return View(catalog);
        }

        // POST: Catalog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Catalog catalog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catalog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catalog);
        }

        // GET: Catalog/Delete/5
        public ActionResult Delete(long? catalogId)
        {
            if (catalogId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var id = catalogId.GetValueOrDefault();
            var catalog = db.Catalogs.Find(id);
            if (catalog == null)
            {
                return HttpNotFound();
            }

            if (!_catalogService.ContainsSubCatalogs(id))
            {
                _catalogService.RemoveCatalog(id);
            }
            return RedirectToAction("Index", "Catalog");
        }

        // POST: Catalog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            _catalogService.RemoveCatalog(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
