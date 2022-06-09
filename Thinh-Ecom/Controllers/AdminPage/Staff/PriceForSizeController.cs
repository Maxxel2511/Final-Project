using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thinh_Ecom.Data;
using System.Linq;
using Thinh_Ecom.Entities;

namespace Thinh_Ecom.Controllers.AdminPage.Staff
{
    public class PriceForSizeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PriceForSizeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PriceForSizeController
        [Route("/priceforsizemanagement")]
        public ActionResult Index()
        {
            var query = from a in _context.PriceForSize select a;

            return View(query);
        }

        // GET: PriceForSizeController/Details/5
        [Route("/priceforsizemanagement/Details")]
        public ActionResult Details(string id)
        {
            var queryproduct = _context.PriceForSize.FirstOrDefault(a => a.Id == id);
            return View(queryproduct);
        }



        // GET: PriceForSizeController/Edit/5
        [Route("/priceforsizemanagement/Edit")]
        public ActionResult Edit(string id)
        {
            var queryproduct = _context.PriceForSize.FirstOrDefault(a => a.Id == id);
            return View(queryproduct);
        }

        // POST: PriceForSizeController/Edit/5
        [Route("/priceforsizemanagement/Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( PriceForSize priceForSize)
        {
            try
            {
                var queryproduct = _context.PriceForSize.FirstOrDefault(a => a.Id == priceForSize.Id);
                queryproduct.Price = priceForSize.Price;

                _context.PriceForSize.Update(queryproduct);
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
