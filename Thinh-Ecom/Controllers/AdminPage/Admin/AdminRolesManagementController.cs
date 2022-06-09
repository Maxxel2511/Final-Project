using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Thinh_Ecom.Data;
using Thinh_Ecom.EntitiesThinh_Ecom.Entities;
using System.Linq;

namespace Thinh_Ecom.Controllers.AdminPage.Admin
{
    [Authorize(Roles ="Admin")]
    public class AdminRolesManagementController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminRolesManagementController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: AdminRolesManagementController
        [Route("/rolesmanagement")]
        [HttpGet]
        public ActionResult Index()
        {
            var QueryRole = from a in _context.AppRole select a;
            QueryRole = QueryRole.Where(a => a.IsDelete != true);
            return View(QueryRole);
        }

        // GET: AdminRolesManagementController/Details/5
        [Route("/rolesmanagement/details/{id:guid}")]
        [HttpGet]
        public ActionResult Details(string id)
        {
            //Print information or roles
            var queryRole = _context.AppRole.Find(id);

            return View(queryRole);
        }

        // GET: AdminRolesManagementController/Create
        [Route("/rolesmanagement/create")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminRolesManagementController/Create
        [Route("/rolesmanagement/create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppRole appRole)
        {
            try
            {
                // import information of role
                var roleInfo = new AppRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = appRole.Name,
                    Description = appRole.Description,
                    NormalizedName = appRole.Name.ToUpper(),
                    IsDelete = false,
                };
                //Add approle
                _context.AppRole.Add(roleInfo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminRolesManagementController/Edit/5
        [Route("/rolesmanagement/edit/{id:guid}")]
        [HttpGet]
        public ActionResult Edit(string id)
        {
            //Print information or roles
            var queryRole = _context.AppRole.Find(id);

            return View(queryRole);
        }

        // POST: AdminRolesManagementController/Edit/5
        [Route("/rolesmanagement/edit/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, AppRole appRole)
        {
            try
            {
               var queryRole = _context.AppRole.Find(appRole.Id);

                queryRole.Description = appRole.Description;
                queryRole.Name = appRole.Name;
                queryRole.NormalizedName = appRole.NormalizedName;

                //Update information of role
                _context.AppRole.Update(queryRole);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminRolesManagementController/Delete/5
        [Route("/rolesmanagement/delete/{id:guid}")]
        [HttpGet]
        public ActionResult Delete(string id)
        {
            var queryRole = _context.AppRole.Find(id);

            return View(queryRole);
        }

        // POST: AdminRolesManagementController/Delete/5
        [Route("/rolesmanagement/delete/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AppRole appRole)
        {
            try
            {
                var queryRole = _context.AppRole.Find(appRole.Id);
                queryRole.IsDelete = true;
                //Remove role 
                _context.AppRole.Update(queryRole);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
