using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Thinh_Ecom.Data;
using System.Linq;
using Thinh_Ecom.Models;

namespace Thinh_Ecom.Controllers.AdminPage.Staff
{
    public class PaymentManagementController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PaymentManagementController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: HistoryOfPaymentController
        [Route("paymentmanagement")]
        public ActionResult Index()
        {
            // Get Data Of User
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            // Query Data Bill and User Table

            var queryBill = from a in _context.Bills
                            join b in _context.Users on a.bill_UserId equals b.Id
                            select new { a, b };

            // // Start Proccess Product Name
             queryBill = queryBill.OrderByDescending(s => s.a.bill_DatetimeOrder);

            // // End Proccess Product Name

            var DataForHistoryModel = queryBill.Select(x => new PaymentManagement()
            {
                PaymentId = x.a.bill_Id,
                Date = x.a.bill_DatetimeOrder,
                Status_Confirm = x.a.bill_Confirmation,
                Name_Product = "Product Name",
                Type_Payment = x.a.bill_PaymentMethod,
                UserName = x.b.UserName,
                Check_Receive = true,
                Price = x.a.bill_PaidTotal

            });
            return View(DataForHistoryModel);
        }

        // GET: PaymentManagementController/Details/5
        [Route("paymentconfirm")]
        [HttpGet("{id}")]
        public ActionResult Confirmed(string id)
        {

            var queryPayment = _context.Bills.FirstOrDefault(a => a.bill_Id == id);
            queryPayment.bill_Confirmation = true;

            _context.Bills.Update(queryPayment);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        // GET: PaymentManagementController/Details/5
        [Route("paymentconfirm/Details")]

        public ActionResult Details(string id)
        {

            var queryPayment = _context.Bills.FirstOrDefault(a => a.bill_Id == id);
            //queryPayment.bill_Confirmation = true;

            //_context.Bills.Update(queryPayment);
            //_context.SaveChanges();

            var DataForHistoryModel =  new PaymentManagement()
            {
                PaymentId = queryPayment.bill_Id,
                Date = queryPayment.bill_DatetimeOrder,
                Status_Confirm = queryPayment.bill_Confirmation,
                //Name_Product = "Product Name",
                Type_Payment = queryPayment.bill_PaymentMethod,
                
                Check_Receive = true,
                Price = queryPayment.bill_PaidTotal

            };

            return View(DataForHistoryModel);
        }






    }
}
