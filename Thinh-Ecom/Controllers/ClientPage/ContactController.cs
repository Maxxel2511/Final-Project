using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using Thinh_Ecom.Data;
using Thinh_Ecom.Entities;
using Thinh_Ecom.Function;

namespace Thinh_Ecom.Controllers.ClientPage
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContactController
        [Route("/contact")]
        [HttpGet]
        public ActionResult Index()
        {
            // Acctive Menu
            ViewBag.ActiveClassContact = "current-list-item";

            return View();
        }


        // POST: ContactController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactForm contactForm)
        {
            try
            {
                bool checkLogin = (User?.Identity.IsAuthenticated).GetValueOrDefault();
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                // Count Cart
                ViewBag.CountCart = CalculatorStatic.CountProductInCart(_context, checkLogin, userId);
                // Insert Data to ContactForm
                var createForm = new ContactForm();
                {
                    createForm.cf_Id = Guid.NewGuid().ToString();
                    createForm.cf_Name = contactForm.cf_Name;
                    createForm.cf_Phone = contactForm.cf_Phone;
                    createForm.cf_Email = contactForm.cf_Email;
                    createForm.cf_Subject = contactForm.cf_Subject;
                    createForm.cf_Description = contactForm.cf_Description;
                }

                _context.ContactForm.Add(createForm);
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
