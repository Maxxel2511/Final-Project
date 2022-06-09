using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Claims;
using Thinh_Ecom.Data;
using Thinh_Ecom.Entities;
using Thinh_Ecom.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Thinh_Ecom.Function;

namespace Thinh_Ecom.Controllers.ClientPage
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CheckoutController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CheckoutController
        [Route("/checkout")]
        [HttpGet]
        public ActionResult Index()
        {
            bool checkLogin = (User?.Identity.IsAuthenticated).GetValueOrDefault();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // Count Cart
            ViewBag.CountCart = CalculatorStatic.CountProductInCart(_context, checkLogin, userId);
            // Acctive Menu
            ViewBag.ActiveClassMenu = "current-list-item";

            // Query 
            //Transfer Data

            var query = from a in _context.Products
                        join b in _context.ProductInCart on a.pd_Id equals b.pic_ProductId
                        join c in _context.Cart on b.pic_CartId equals c.cart_Id
                        join d in _context.AppUser on c.cart_UserID equals d.Id
                        select new { a, b, c, d };

            query = query.Where(x => x.d.Id == userId);

            // Pass Query data to Cart Model
            var cartModelQuery = query
                .Select(x => new CartModels()
                {
                    cart_ProductId = x.a.pd_Id,
                    cart_ProductName = x.a.pd_Name,

                    cart_ProductPrice = x.a.pd_Price,
                    cart_ProductImg = x.a.pd_Img1,
                    cart_ProductQuantity = x.b.pic_amount,
                    cart_ProductSize = x.b.pic_size,
                    cart_totalPrice = CalculatorStatic.CalculatorPriceForSize(x.b.pic_size, x.a.pd_Price, _context) * x.b.pic_amount

                });
            //Pass value to ViewBag
            ViewBag.Cart = cartModelQuery;

            ////Pass SubToTal to ViewBag
            //ViewBag.SubToTal = CalculatorSubTotalPrice(cartModelQuery.ToList());

            ////Pass Discount to ViewBag
            //ViewBag.Discount = DiscountPrice();

            ////Pass Shipping to ViewBag
            //ViewBag.Shipping = ShippingPrice();

            ////Pass  Calculator Total to ViewBag
            //ViewBag.Total = CalculatorTotalPrice(cartModelQuery.ToList());

            //Pass SubToTal to ViewBag
            ViewBag.SubToTal = CalculatorSubTotalPrice(cartModelQuery.ToList(), _context);

            //Pass Discount to ViewBag
            ViewBag.Discount = DiscountPrice();

            //Pass Shipping to ViewBag
            ViewBag.Shipping = ShippingPrice();

            //Pass  Calculator Total to ViewBag
            ViewBag.Total = CalculatorTotalPrice(cartModelQuery.ToList(), _context);
            return View(cartModelQuery);
        }

        public int CalculatorTotalPrice(List<CartModels> cartModelQuery, ApplicationDbContext context)
        {
            //Calculator price

            return CalculatorSubTotalPrice(cartModelQuery, context) - DiscountPrice() + ShippingPrice();
        }

        // GET: CheckoutController/Details/5
        public ActionResult Details(int id)
        {

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

        // POST: CheckoutController/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CheckoutModels checkoutModels, string stripeEmail, string stripeToken)
        {
            try
            {
                string MethodPayment;
                if (stripeToken is not null)
                {
                    MethodPayment = "Card";
                }
                else
                {
                    MethodPayment = "Cash";
                }

                bool checkLogin = (User?.Identity.IsAuthenticated).GetValueOrDefault();
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                //Transfer Data
                var query = from a in _context.Products
                            join b in _context.ProductInCart on a.pd_Id equals b.pic_ProductId
                            join c in _context.Cart on b.pic_CartId equals c.cart_Id
                            join d in _context.AppUser on c.cart_UserID equals d.Id
                            select new { a, b, c, d };

                query = query.Where(x => x.d.Id == userId);

                // Pass Query data to Cart Model
                var cartModelQuery = query
                    .Select(x => new CartModels()
                    {
                        cart_ProductId = x.a.pd_Id,
                        cart_ProductName = x.a.pd_Name,
                        //cart_ProductPrice = CalculatorStatic.CalculatorPriceForSize(x.b.pic_size, x.a.pd_Price,_context),
                        cart_ProductPrice = x.a.pd_Price,
                        cart_ProductImg = x.a.pd_Img1,
                        cart_ProductQuantity = x.b.pic_amount,
                        cart_ProductSize = x.b.pic_size,
                        cart_totalPrice = CalculatorStatic.CalculatorPriceForSize(x.b.pic_size, x.a.pd_Price, _context) * x.b.pic_amount

                    });
                string productIdList = "";
                string productNameList = "";
                string productPriceList = "";
                string productQuantityList = "";
                int totalPrice = 0;

                string productListreate = "";
                int i = 0;

                foreach (var item in query)
                {
                    productIdList += item.a.pd_Id + "|";
                    productNameList += item.a.pd_Name + "|";
                    productPriceList += item.a.pd_Price + "|";
                    productQuantityList += item.b.pic_amount + "|";
                    totalPrice = totalPrice + item.a.pd_Price;

                    productListreate += "<tr>" +
                    "<td>" + i + "</td>" +
                    "<td>" + item.a.pd_Name + "</td>" +
                    "<td>" + item.b.pic_amount + "</td>" +
                    "<td>" + item.a.pd_Price * item.b.pic_amount + "</td>" +
                    "</tr>";

                    i++;
                }

                //Edit User
                var queryUser = _context.AppUser.FirstOrDefault(a => a.Id == userId);
                queryUser.FirstName = checkoutModels.Name;
                queryUser.Email = checkoutModels.Email;
                queryUser.user_Address1 = checkoutModels.Address;
                queryUser.PhoneNumber = checkoutModels.Phone;

                _context.AppUser.Update(queryUser);

                // Create Bill
                var createBill = new Bills()
                {
                    bill_Id = Guid.NewGuid().ToString(),
                    bill_ProductIdlist = productIdList,
                    bill_ProductNamelist = productNameList,
                    bill_ProductPricelist = productPriceList,
                    bill_QuantityList = productQuantityList,
                    bill_DatetimeOrder = DateTime.Now,
                    bill_PaymentMethod = MethodPayment,
                    bill_Shipping = ShippingPrice(),
                    bill_Discount = DiscountPrice(),
                    bill_Note = checkoutModels.Note,
                    bill_UserId = userId,
                    bill_PaidTotal = CalculatorTotalPrice(cartModelQuery.ToList(), _context)
                };
                _context.Bills.Add(createBill);

                // Done process with database
                // Start Delete Cart
                // // Query Cart
                var queryCart = _context.Cart.FirstOrDefault(a => a.cart_UserID == userId);

                // // Query Product in cart
                var queryProductList = _context.ProductInCart.Where(a => a.pic_CartId == queryCart.cart_Id);

                _context.ProductInCart.RemoveRange(queryProductList);
                // End Delete Cart
                await _context.SaveChangesAsync();

                // Start product list


                string contentEmail = "<div>" +
                    "<p>Name: " + queryUser.UserName + "</p>" +
                    "<p>Address: " + queryUser.user_Address1 + "</p>" +
                    "<p>Phone : " + queryUser.PhoneNumber + "</p>" +
                    "<table>" +
                    "<tr>" +
                    "<th>Id:</th>" +
                    "<th>ProductName:</th>" +
                    "<th>Quantity:</th>" +
                    "<th>Price:</th>" +
                    "</tr>" +
                    productListreate +
                    "</table>" +
                    "<p>Discount: " + DiscountPrice() + "</p>" +
                    "<p>Shipping: " + ShippingPrice() + "</p>" +
                    "<p>Total: " + totalPrice + "</p>";
                // End product list


                // Start Email for customer
                SendByMail(checkoutModels.Email,
                    contentEmail,
                    "Order Success!");
                // End Email for customer

                return Redirect("/thanks");
            }
            catch
            {
                return Redirect("/thanks");
            }
        }

        public void SendByMail(string subject, string boddy, string mailto)
        {
            var smtpacountJson = new ConfigurationBuilder().AddJsonFile("appsettings.json").
                Build().GetSection("MailSettings")["Mail"];
            var smtppasswordJson = new ConfigurationBuilder().AddJsonFile("appsettings.json").
                Build().GetSection("MailSettings")["Password"];

            MailUtils.MailUtils.SendMailGoogleSmtp(
                smtpacountJson.ToString(),
                mailto,
                subject,
                boddy,
                smtpacountJson.ToString(),
                smtppasswordJson.ToString()

            ).Wait();
        }

        public int ShippingPrice()
        {
            //Calculator price

            return 1;
        }

        public int DiscountPrice()
        {
            //Calculator price
            var price = HttpContext.Session.GetString(KeySession.SessionCoupon);
            int discount = 0;
            return discount = (price is null) ? 0 : Int32.Parse(HttpContext.Session.GetString(KeySession.SessionCoupon)); ;
        }

        // GET: CheckoutController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CheckoutController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CheckoutController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CheckoutController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
