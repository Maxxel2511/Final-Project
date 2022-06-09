using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thinh_Ecom.Data;
using Thinh_Ecom.Models;
using Thinh_Ecom.Entities;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Thinh_Ecom.Controllers.AdminPage.Admin
{
    [Authorize(Roles = "Admin")]
    public class AdminUsersManagementController : Controller
    {

        public UsersModel usersModel;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public AdminUsersManagementController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: AdminUsersManagementController
        [Route("/usersmanagement")]
        [HttpGet]
        public ActionResult Index()
        {
            // Print list Users
            var queryUsers = from a in _context.AppUser select a;
            queryUsers = queryUsers.Where(a => a.IsDelete != true);
            return View(queryUsers);
        }

        // GET: AdminUsersManagementController/Details/5
        [Route("/usersmanagement/details/{id:guid}")]
        [HttpGet]
        public ActionResult Details(string id)
        {
            //Print information or user
            var queryUsers = _context.AppUser.Find(id);

            return View(queryUsers);
        }

        // GET: AdminUsersManagementController/Edit/5
        [Route("/usersmanagement/edit/{id:guid}")]
        [HttpGet]
        public ActionResult Edit(string id)
        {
            // Edit Users
            var queryUsers = _context.AppUser.Find(id);

            return View(queryUsers);
        }

        // POST: AdminUsersManagementController/Edit/5
        [Route("/usersmanagement/edit/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, AppUser appUser)
        {
            try
            {
                //Edit information or user
                var queryUsers = _context.AppUser.Find(appUser.Id);
                queryUsers.FirstName = appUser.FirstName;
                queryUsers.LastName = appUser.LastName;

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminUsersManagementController/Delete/5
        [Route("/usersmanagement/delete/{id:guid}")]
        [HttpGet]
        public ActionResult Delete(string id)
        {
            //Print information of user
            var queryUsers = _context.AppUser.Find(id);
            return View(queryUsers);
        }

        // POST: AdminUsersManagementController/Delete/5
        [Route("/usersmanagement/delete/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, AppUser appUser)
        {
            try
            {
                //Find user by id
                var queryUsers = _context.AppUser.Find(appUser.Id);
                queryUsers.IsDelete = true;
                queryUsers.EmailConfirmed = false;
                //Remove User
                _context.AppUser.Update(queryUsers);
                _context.SaveChanges();


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminUsersManagementController/Delete/5
        [Route("/usersmanagement/roleinuser/{id:guid}")]
        [HttpGet]
        public ActionResult RoleInUser(string id)
        {
            try
            {
                //Check and Query Infomation
                var userQuery = _context.AppUser.FirstOrDefault(a => a.Id == id);
                var roleQuery = from a in _context.AppRole select a;
                roleQuery = roleQuery.Where(x => x.IsDelete == false);
                var checkUserInRole = _context.UserRoles.FirstOrDefault(a => a.UserId == id);
                ViewBag.RoleName = "";


                if (checkUserInRole != null)
                {
                    var RoleName = _context.AppRole.FirstOrDefault(a => a.Id == checkUserInRole.RoleId);
                    ViewBag.RoleName = RoleName.Name;
                }
                ViewBag.Id = id;
                ViewBag.UserName = userQuery.UserName;
                ViewBag.FirstName = userQuery.FirstName;
                ViewBag.LastName = userQuery.LastName;
                ViewBag.Email = userQuery.Email;

                ViewBag.Role = roleQuery;
                return View();
            }
            catch
            {

                return View();
            }
        }

        // POST: AdminUsersManagementController/Delete/5
        [Route("/usersmanagement/roleinuser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RoleInUser(AssignToRoleModels assignToRoleModels)
        {
            try
            {
                var roleQuery = _context.AppRole.FirstOrDefault(a => a.Id == assignToRoleModels.UserId);

                string idUser = assignToRoleModels.UserId;

                var RoleName = _context.AppRole.FirstOrDefault(a => a.Id == assignToRoleModels.RoleId);
                var UserQueryName = _context.AppUser.FirstOrDefault(a => a.Id == idUser);

                // Delete Role
                var checkUserInRole = _context.UserRoles.FirstOrDefault(a => a.UserId == idUser);
                if (checkUserInRole != null)
                {
                    _context.UserRoles.Remove(checkUserInRole);
                    //await _userManager.RemoveFromRoleAsync(UserQueryName, RoleName);
                }

                await _userManager.AddToRoleAsync(UserQueryName, RoleName.Name);
                //_context.UserRoles.Add(createUserRole);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }

    
}
