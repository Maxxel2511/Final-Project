using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thinh_Ecom.Data;
using System.Linq;
using Thinh_Ecom.Models;
using Thinh_Ecom.Function;
using Microsoft.EntityFrameworkCore;
using Thinh_Ecom.Entities;
using System.Threading.Tasks;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Thinh_Ecom.Controllers.ClientPage
{
    public class PizzaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PizzaController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: PizzaController
        [Route("/pizza")]
        [HttpGet("{Search}")]
        public ActionResult Index(string Search, string sortOrder, string currentFilter, int? pageNumber)
        {
            bool checkLogin = (User?.Identity.IsAuthenticated).GetValueOrDefault();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // Count Cart
            ViewBag.CountCart = CalculatorStatic.CountProductInCart(_context, checkLogin, userId);
            // Acctive Menu
            ViewBag.ActiveClassMenu = "current-list-item";

            //Query Food
            var queryFood = from a in _context.Products
                            join b in _context.Categories on a.CategoriesFK equals b.cg_Id
                            select new { a, b };

            queryFood = queryFood.Where(a=> a.a.IsDelete != true);

            if (Search != null)
            {
                queryFood = queryFood.Where(a => a.a.pd_Name.Contains(Search));
            }

            // Insert data into model
            var FoodModelQuery = queryFood
                .Select(x => new FoodModels()
                {
                    Id = x.a.pd_Id,
                    Img = x.a.pd_Img1,
                    Name = x.a.pd_Name,
                    Price = x.a.pd_Price,
                    ShortDescription = x.a.pd_ShortDescription.Substring(0, 15) +"...",
                    CategoriesName = x.b.cg_Name,
                    Discount = x.a.pd_ReducePrice
                });
            
            //Query Categories Name
            var queryCategories = _context.Categories;
            ViewBag.Categories = queryCategories;

            //Paging
            int pageSize = 20;
            return View(PaginatedList<FoodModels>.Create(FoodModelQuery.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


        

        // GET: PizzaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        [Authorize]
        // POST: PizzaController/Delete/5
        [Route("addtocart")]
        [HttpGet("pd_Id")]
        public async Task<IActionResult> AddToCart(Products products, string pd_Id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var userName = User.FindFirstValue(ClaimTypes.Name);
                string cartId = Guid.NewGuid().ToString();

                // Logined
                // Query cart
                var queryCart = _context.Cart.FirstOrDefault(a => a.cart_UserID == userId.ToString());

                // Check Cart
                if (queryCart == null)
                {
                    //Create cart 
                    var cartCreate = new Cart()
                    {
                        cart_Id = cartId,
                        cart_UserID = userId
                    };
                    _context.Cart.Add(cartCreate);
                }
                else
                {
                    cartId = queryCart.cart_Id;
                }

                //Check product in cart
                var queryProductInCart = _context.ProductInCart.FirstOrDefault(a => a.pic_ProductId == pd_Id);
                if (queryProductInCart is not null)
                {
                    queryProductInCart.pic_amount += 1;

                    _context.ProductInCart.Update(queryProductInCart);
                }
                else
                {
                    //Create ProductInCart
                    var ProductInCartCreate = new ProductInCart()
                    {
                        pic_CartId = cartId,
                        pic_ProductId = pd_Id.ToString(),
                        pic_amount = 1,
                    };
                    _context.ProductInCart.Add(ProductInCartCreate);
                }

                await _context.SaveChangesAsync();
                return Redirect("/pizza");
            }
            catch
            {
                return Redirect("/pizza");
            }

        }
    }
}
