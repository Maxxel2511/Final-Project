using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Thinh_Ecom.Data;
using System.Linq;
using System.Security.Claims;
using Thinh_Ecom.Models;
using Microsoft.AspNetCore.Authorization;
using Thinh_Ecom.Function;
using System.Collections.Generic;

namespace Thinh_Ecom.Controllers.ClientPage
{
    [Authorize]
    public class HistoryOfPaymentController : Controller
    {
        private readonly ApplicationDbContext _context;
        List<string> ProductNameList;

        public HistoryOfPaymentController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: HistoryOfPaymentController
        [Route("paymenthistory")]
        public ActionResult Index()
        {
            // Get Data Of User
            bool checkLogin = (User?.Identity.IsAuthenticated).GetValueOrDefault();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // Count Cart
            ViewBag.CountCart = CalculatorStatic.CountProductInCart(_context, checkLogin, userId);

            // Active Color Payment
            ViewBag.ActiveClassPaymentHistory = "current-list-item";

            // Query Data Bill and User Table

            var queryBill = from a in _context.Bills
                            join b in _context.Users on a.bill_UserId equals b.Id
                            select new { a, b };

            queryBill = queryBill.Where(a => a.b.Id == userId);





            var DataForHistoryModel = queryBill.Select(x => new HistoryPaymentModels()
            {
                PaymentId = x.a.bill_Id,
                Date = x.a.bill_DatetimeOrder,
                Status_Confirm = x.a.bill_Confirmation,
                Name_Product = x.a.bill_ProductNamelist.Replace('|',','),
                Type_Payment = x.a.bill_PaymentMethod,
                Check_Receive = true,
                Price = x.a.bill_PaidTotal,
                Discount = x.a.bill_Discount,
                Shipping = x.a.bill_Shipping


            });

            return View(DataForHistoryModel);
        }

        public string ReplaceProductName(string productName, string productAmount)
        {
            var arrProductName = productName.Split("|");

            var arrproductAmount = productAmount.Split("|");

            string productResult = "";
            for (int i = 0; i < arrProductName.Length - 1; i++)
            {
                productResult = arrProductName[i] + arrproductAmount[i] +" ,";
            }

            return productResult;
        }

    }


}
