using System;
using System.Net;
using System.Web.Mvc;
using RegistryManagmentV2.Models.Domain;
using RegistryManagmentV2.Services;

namespace RegistryManagmentV2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserGroupsController : Controller
    {
        private readonly IUserGroupService _userGroupService = new UserGroupService();

        // GET: UserGroups
        public ActionResult Index()
        {
            return View(_userGroupService.GetAllUserGroups());
        }

        

        // GET: UserGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] UserGroup userGroup)
        {
            if (ModelState.IsValid)
            {
                _userGroupService.CreateUserGroup(userGroup);
                return RedirectToAction("Index");
            }

            return View(userGroup);
        }

        // GET: UserGroups/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userGroup = _userGroupService.GetUserGroupById(id.Value);
            if (userGroup == null)
            {
                return HttpNotFound();
            }
            return View(userGroup);
        }

        // POST: UserGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] UserGroup userGroup)
        {
            if (ModelState.IsValid)
            {
                _userGroupService.UpdateUserGroup(userGroup);
                return RedirectToAction("Index");
            }
            return View(userGroup);
        }

        public ActionResult Delete(long id)
        {
            _userGroupService.DeleteUserGroup(id);
            return RedirectToAction("Index");
        }

        /*protected override void Dispose(bool disposing)
        {
            base.Dispose();
        }*/
    }
}
