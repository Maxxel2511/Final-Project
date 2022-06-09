using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Thinh_Ecom.Data;
using Thinh_Ecom.Entities;

namespace Thinh_Ecom.Controllers.AdminPage.Staff
{
    [Authorize(Roles = "Admin, Staff")]
    public class CouponsManagementController : Controller
    {
        public readonly ApplicationDbContext _context;
        public CouponsManagementController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CouponsManagementController
        [Route("couponsmanagement")]
        [HttpGet]
        public ActionResult Index()
        {
            var queryCoupon = _context.Coupons;
            return View(queryCoupon);
        }

        // GET: CouponsManagementController/Details/5
        [Route("couponsmanagement/details/{id:guid}")]
        [HttpGet]
        public ActionResult Details(string id)
        {
            var queryCoupon = _context.Coupons.Find(id);
            return View(queryCoupon);
        }

        // GET: CouponsManagementController/Create
        [Route("couponsmanagement/create")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CouponsManagementController/Create
        [Route("couponsmanagement/create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Coupons coupon)
        {
            try
            {
                var couponInfo = new Coupons()
                {
                    couponId = Guid.NewGuid().ToString(),
                    couponCode = coupon.couponCode,
                    couponPrice = coupon.couponPrice
                };
                _context.Coupons.Add(couponInfo);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CouponsManagementController/Edit/5
        [Route("couponsmanagement/edit/{id:guid}")]
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var queryCoupon = _context.Coupons.Find(id);
            return View(queryCoupon);
        }

        // POST: CouponsManagementController/Edit/5
        [Route("couponsmanagement/edit/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Coupons coupons)
        {
            try
            {
                var queryCoupon = _context.Coupons.Find(id);
                queryCoupon.couponCode = coupons.couponCode;
                queryCoupon.couponPrice = coupons.couponPrice;

                _context.Coupons.Update(queryCoupon);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CouponsManagementController/Delete/5
        [Route("couponsmanagement/delete/{id:guid}")]
        [HttpGet]
        public ActionResult Delete(string id)
        {
            var queryCoupon = _context.Coupons.Find(id);
            return View(queryCoupon);
        }

        // POST: CouponsManagementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Coupons coupons)
        {
            try
            {
                var queryCoupon = _context.Coupons.Find(id);
                _context.Coupons.Remove(queryCoupon);
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
