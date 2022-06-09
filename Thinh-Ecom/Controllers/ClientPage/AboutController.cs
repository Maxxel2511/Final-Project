using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Thinh_Ecom.Data;
using Thinh_Ecom.Function;

namespace Thinh_Ecom.Controllers.ClientPage
{
    public class AboutController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AboutController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: AboutController
        [Route("about")]
        public ActionResult Index()
        {
            bool checkLogin = (User?.Identity.IsAuthenticated).GetValueOrDefault();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // Count Cart
            ViewBag.CountCart = CalculatorStatic.CountProductInCart(_context, checkLogin, userId);
            // Acctive Menu
            ViewBag.ActiveClassAbout = "current-list-item";

            return View();
        }

        
    }
}
