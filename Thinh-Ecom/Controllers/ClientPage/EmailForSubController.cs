using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Thinh_Ecom.Data;
using Thinh_Ecom.Entities;
using Thinh_Ecom.Models;

namespace Thinh_Ecom.Controllers.ClientPage
{
    public class EmailForSubController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmailForSubController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: EmailForSubController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmailModels emailModels)
        {
            try
            {
                //Create Email
                var createEmail = new EmailGuest()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = emailModels.Email
                };

                // Save Email 
                await _context.EmailGuest.AddAsync(createEmail);

                await _context.SaveChangesAsync();
                return Redirect("/");
            }
            catch
            {
                return Redirect("/");
            }
        }

       
      
    }
}
