using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using RegistryManagmentV2.Models;
using RegistryManagmentV2.Models.Domain;
using RegistryManagmentV2.Services;

namespace RegistryManagmentV2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _dbContext =  new ApplicationDbContext(); 
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private readonly IUserGroupService _userGroupService = new UserGroupService();

        public UserController()
        {
        }

        public UserController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

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


        // GET: User
        public ActionResult Index()
        {
            var roles = _dbContext.Roles.Where(r => r.Name == UserRole.User.ToString());
            var users = new List<ApplicationUser>();
            if (roles.Any())
            {
                var roleId = roles.First().Id;
                users = (from user in _dbContext.Users
                    where user.Roles.Any(r => r.RoleId == roleId)
                    select user).ToList();
            }
            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = UserManager.FindById(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: User/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var applicationUser = UserManager.FindById(id);
            var userGroups = _userGroupService.GetAllUserGroups();
            if (applicationUser == null)
            {
                return HttpNotFound();
            }

            var userViewModel = new ApplicationUserViewModel()
            {
                Id = applicationUser.Id,
                Email = applicationUser.Email,
                PhoneNumber = applicationUser.PhoneNumber,
                AccessFailedCount = applicationUser.AccessFailedCount,
                AccountStatus = applicationUser.AccountStatus.ToString(),
                UserName = applicationUser.UserName,
                UserGroup = applicationUser.UserGroup.Name
            };
            var userInfo = new Tuple<ApplicationUserViewModel, List<UserGroup>>(userViewModel, userGroups);
            return View(userInfo);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AccountStatus,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName, UserGroup")] ApplicationUserViewModel applicationUser)
        {
            var userGroup = _userGroupService.GetUserGroupsWithNames(new Collection<string>() { applicationUser.UserGroup});
               if (ModelState.IsValid)
            {
                var user = UserManager.FindById(applicationUser.Id);
                user.UserGroup = userGroup.First();
                user.Email = applicationUser.Email;
                user.UserName = applicationUser.UserName;
                _userManager.Update(user);
                return RedirectToAction("Index");
            }
            var userGroups = _userGroupService.GetAllUserGroups();
            var userInfo = new Tuple<ApplicationUserViewModel, List<UserGroup>>(applicationUser, userGroups);
            return View(userInfo);
        }

        // GET: User/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var applicationUser = UserManager.FindById(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var applicationUser = UserManager.FindById(id);
            //_userManager.Remove(applicationUser);
            UserManager.RemoveFromRole(applicationUser.Id, UserRole.User.ToString());
            return RedirectToAction("Index");
        }

        public ActionResult Approve(string id)
        {
            var applicationUser = UserManager.FindById(id);
            applicationUser.AccountStatus = AccountStatus.Approved;
            UserManager.Update(applicationUser);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }
    }
}
