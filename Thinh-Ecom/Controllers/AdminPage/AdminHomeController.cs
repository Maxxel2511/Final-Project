using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Thinh_Ecom.Controllers.AdminPage
{
    [Authorize(Roles = "Admin, Staff")]
    public class AdminHomeController : Controller
    {
        // GET: AdminHomeController
        [Route("admin")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
