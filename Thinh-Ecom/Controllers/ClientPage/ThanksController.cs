using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Thinh_Ecom.Controllers.ClientPage
{
    public class ThanksController : Controller
    {
        // GET: ThanksController
        [Route("thanks")]
        public ActionResult Index()
        {

            // Acctive Menu
            ViewBag.ActiveClassMenu = "current-list-item";

            return View();
        }
    }
}
