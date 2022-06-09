using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using Thinh_Ecom.Data;
using System.Linq;
using Thinh_Ecom.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Thinh_Ecom.Function;

namespace Thinh_Ecom.Controllers.ClientPage
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: CartController
        [Route("cart")]
        [HttpGet]
        public ActionResult Index()
        {
            bool checkLogin = (User?.Identity.IsAuthenticated).GetValueOrDefault();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // Count Cart
            ViewBag.CountCart = CalculatorStatic.CountProductInCart(_context, checkLogin, userId);
            // Acctive Menu
            ViewBag.ActiveClassMenu = "current-list-item";


            if (checkLogin)
            {
                //login
                // Query data
                var query = from a in _context.Products
                            join b in _context.ProductInCart on a.pd_Id equals b.pic_ProductId
                            join c in _context.Cart on b.pic_CartId equals c.cart_Id
                            join d in _context.AppUser on c.cart_UserID equals d.Id
                            join f in _context.Categories on a.CategoriesFK equals f.cg_Id
                            select new { a, b, c, d ,f };

                query = query.Where(x => x.d.Id == userId);

                // Pass Query data to Cart Model
                var cartModelQuery = query
                    .Select(x => new CartModels()
                     {
                        cart_ProductId = x.a.pd_Id,
                        cart_ProductName = x.a.pd_Name,
                        cart_ProductType = x.f.cg_Name,
                        //cart_ProductPrice = CalculatorStatic.CalculatorPriceForSize(x.b.pic_size, x.a.pd_Price,_context),
                        cart_ProductPrice = x.a.pd_Price,
                        cart_ProductImg = x.a.pd_Img1,
                        cart_ProductQuantity = x.b.pic_amount, 
                        cart_ProductSize = x.b.pic_size,
                        cart_totalPrice = CalculatorStatic.CalculatorPriceForSize(x.b.pic_size, x.a.pd_Price, _context) * x.b.pic_amount

                    });

                // Query Price
                var queryPriceM = _context.PriceForSize.FirstOrDefault(a => a.SizeName == "M");
                ViewBag.queryPriceM = queryPriceM.Price;

                var queryPriceL = _context.PriceForSize.FirstOrDefault(a => a.SizeName == "L");
                ViewBag.queryPriceL = queryPriceL.Price;

                //Pass value to ViewBag
                ViewBag.Cart = cartModelQuery;

                //Pass SubToTal to ViewBag
                ViewBag.SubToTal = CalculatorSubTotalPrice(cartModelQuery.ToList(),_context);


                //Pass Discount to ViewBag
                ViewBag.Discount = DiscountPrice();

                //Pass Shipping to ViewBag
                ViewBag.Shipping = ShippingPrice();

                //Pass  Calculator Total to ViewBag
                ViewBag.Total = CalculatorTotalPrice(cartModelQuery.ToList(), _context);

                return View();
            }

            return View();
        }

        public int CalculatorSubTotalPrice(List<CartModels> cartModelQuery, ApplicationDbContext context)
        {
            //Calculator price
            int subTotal = 0;
            foreach (var itemProduct in cartModelQuery)
            {
                //subTotal += itemProduct.cart_ProductPrice * itemProduct.cart_ProductQuantity;
                subTotal += CalculatorStatic.CalculatorPriceForSize(itemProduct.cart_ProductSize, itemProduct.cart_ProductPrice, context) * itemProduct.cart_ProductQuantity;
            }
            return subTotal;
        }

        public int DiscountPrice()
        {
            //Calculator price
            var price = HttpContext.Session.GetString(KeySession.SessionCoupon);
            int discount = 0;
            return discount = (price is null) ? 0 : Int32.Parse(HttpContext.Session.GetString(KeySession.SessionCoupon)); ;
        }

        public int ShippingPrice()
        {
            //Calculator price

            return 1;
        }

        public int CalculatorTotalPrice(List<CartModels> cartModelQuery, ApplicationDbContext context)
        {
            //Calculator price

            return CalculatorSubTotalPrice(cartModelQuery,context) - DiscountPrice() + ShippingPrice();
        }



        // GET: CartController/Edit/5
        [Route("cart/edit")]
        public ActionResult Edit()
        {
            return View();
        }

        // POST: CartController/Edit/5
        [Route("cart/edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ICollection<CartModels> cartModels)
        {
            try
            {
                foreach (var itemProductInCart in cartModels)
                {
                    var queryCart = _context.ProductInCart.FirstOrDefault(a => a.pic_ProductId == itemProductInCart.cart_ProductId);

                    queryCart.pic_amount = itemProductInCart.cart_ProductQuantity;
                    queryCart.pic_size = itemProductInCart.cart_ProductSize;
                    

                    _context.ProductInCart.Update(queryCart);
                }

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       

        // GET: CartController/Delete/5
        [Route("cart/remove")]
        [HttpGet("pd_Id")]
        public ActionResult Remove(string pd_Id)
        {
            string namePc = Environment.MachineName;
            bool checkLogin = (User?.Identity.IsAuthenticated).GetValueOrDefault();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (checkLogin)
            {
                //Logined
                var queryProduct = _context.ProductInCart.FirstOrDefault(a=>a.pic_ProductId == pd_Id);

                _context.ProductInCart.Remove(queryProduct);
                _context.SaveChanges();
            }
            else
            {
                //Not login

            }
                
            return RedirectToAction(nameof(Index));
        }

        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCoupon(CouponModels couponModels)
        {
            try
            {
                var queryCoupon = _context.Coupons.FirstOrDefault(a => a.couponCode == couponModels.Code);
                if (queryCoupon is not null)
                {
                    HttpContext.Session.SetString(KeySession.SessionCoupon, queryCoupon.couponPrice.ToString());
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
