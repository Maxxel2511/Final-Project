using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thinh_Ecom.Data;

namespace Thinh_Ecom.Controllers.AdminPage.Staff
{
    [Authorize(Roles = "Admin, Staff")]
    public class ContactUserController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ContactUserController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: ContactUserController
        [Route("admin/contact")]
        public ActionResult Index()
        {
            var queryContact = _context.ContactForm;
            return View(queryContact);
        }

        // GET: ContactUserController/Details/5
        [Route("admin/contact/detail")]
        public ActionResult Details(string id)
        {
            var queryContact = _context.ContactForm.Find(id);
            return View(queryContact);
        }

    }
}
