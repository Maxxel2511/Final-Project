using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Thinh_Ecom.Controllers.ClientPage
{
    public class SearchController : Controller
    {
        // GET: SearchController
        
        [HttpPost]
        public ActionResult Search(string search)
        {
            return Redirect("/pizza?Search="+ search);
        }

      
    }
}
