using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thinh_Ecom.Data;

namespace Thinh_Ecom.Controllers.AdminPage.Staff
{
    [Authorize(Roles = "Admin, Staff")]
    public class EmailStaffController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmailStaffController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: EmailStaffController
        [Route("admin/email")]
        public ActionResult Index()
        {
            var queryEmail = _context.EmailGuest;
            return View(queryEmail);
        }

        // GET: EmailStaffController/Details/5
        [Route("admin/email/detail")]
        public ActionResult Details(string id)
        {
            var queryEmail = _context.EmailGuest.Find(id);
            return View(queryEmail);
        }

    }
}
