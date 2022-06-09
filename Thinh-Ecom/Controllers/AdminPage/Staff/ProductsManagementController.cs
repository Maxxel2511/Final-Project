using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using Thinh_Ecom.Data;
using Thinh_Ecom.Entities;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Thinh_Ecom.Models;
using System.Threading.Tasks;

namespace Thinh_Ecom.Controllers.AdminPage.Staff
{
    [Authorize(Roles = "Admin, Staff")]
    public class ProductsManagementController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public readonly ApplicationDbContext _context;
        public ProductsManagementController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        // GET: ProductsManagementController
        [Route("productsmanagement")]
        public ActionResult Index()
        {
            var queryProduct = from a in _context.Products select a;
            queryProduct = queryProduct.Where(a => a.IsDelete != true);

            return View(queryProduct);
        }

        // GET: ProductsManagementController/Details/5
        [Route("productsmanagement/details/{id:guid}")]
        [HttpGet]
        public ActionResult Details(string id)
        {
            //Print information of product
            var queryProduct = _context.Products.Find(id);

            ViewBag.img = queryProduct.pd_Img1;
            return View(queryProduct);
        }

        // GET: ProductsManagementController/Create
        [Route("productsmanagement/create")]
        [HttpGet("{errorProdudctName}")]
        public ActionResult Create(string errorProdudctName = "")
        {
            // Query List Product Name 

            var queryProduct = _context.Products.Select(p => p.pd_Name).ToArray();
            ViewBag.ProduceName = queryProduct;
            ViewBag.ProduceNameCount = queryProduct.Count();

            //Query Categories 
            var categoriesQuery = _context.Categories;

            List<SelectListItem> categoriesList = new List<SelectListItem>();
            foreach (var categories in categoriesQuery)
            {
                var itemCategories = new SelectListItem { Value = categories.cg_Id, Text = categories.cg_Name };
                categoriesList.Add(itemCategories);
            }
            ViewBag.idea_CategoriesId = categoriesList;

            // Print product
            ViewBag.ErrorProdudctName = errorProdudctName;

            return View();
        }

        // POST: ProductsManagementController/Create
        [Route("productsmanagement/create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductModels productModels)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(productModels.pd_Img1.FileName);
                    string extension = Path.GetExtension(productModels.pd_Img1.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);

                    var checkExistProduct = _context.Products.FirstOrDefault(a => a.pd_Name == productModels.pd_Name);


                    if(checkExistProduct != null)
                    {
                        return RedirectToAction("Create", new { errorProdudctName = "Product is existed in database"});
                    }
                    var productInfo = new Products()
                    {
                        pd_Id = Guid.NewGuid().ToString(),
                        pd_Name = productModels.pd_Name,
                        pd_Description = productModels.pd_Description,
                        pd_Img1 = "./Image/" + fileName,
                        pd_Price = productModels.pd_Price,
                        pd_ShortDescription = productModels.pd_ShortDescription,
                        CategoriesFK = productModels.CategoriesFK,
                        IsDelete = false
                    };

                    // Insert image File
                    await using( var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await productModels.pd_Img1.CopyToAsync(fileStream);
                    }
                    _context.Products.Add(productInfo);
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsManagementController/Edit/5
        [Route("productsmanagement/edit/{id:guid}")]
        [HttpGet]
        public ActionResult Edit(string id)
        {
            //Print information of product
            var queryProduct = _context.Products.Find(id);
            ViewBag.img = queryProduct.pd_Img1;
            //Query Current Categories
            var queryCurrentCategories = _context.Categories.FirstOrDefault(a => a.cg_Id == queryProduct.CategoriesFK);
            ViewBag.CurrentCategories = queryCurrentCategories;
            //List Categories
            var queryCategoriesList = _context.Categories.Where(a => a.cg_Id != queryCurrentCategories.cg_Id);
            ViewBag.CategoriesList = queryCategoriesList;
            
            return View(queryProduct);
        }

        // POST: ProductsManagementController/Edit/5
        [Route("productsmanagement/edit/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Products products)
        {
            try
            {
                //Edit info of product
                var queryProduct = _context.Products.Find(products.pd_Id);
                queryProduct.pd_Name = products.pd_Name;
                queryProduct.pd_Description = products.pd_Description;
                queryProduct.pd_Img1 = products.pd_Img1;
                queryProduct.pd_Price = products.pd_Price;
                queryProduct.pd_ReducePrice = products.pd_ReducePrice;
                queryProduct.pd_ShortDescription = products.pd_ShortDescription;
                queryProduct.CategoriesFK = products.CategoriesFK;

                _context.Products.Update(queryProduct);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsManagementController/Delete/5
        [Route("productsmanagement/delete/{id:guid}")]
        [HttpGet]
        public ActionResult Delete(string id)
        {
            var queryProduct = _context.Products.Find(id);
            ViewBag.img = queryProduct.pd_Img1;
            return View(queryProduct);
        }

        // POST: ProductsManagementController/Delete/5
        [Route("productsmanagement/delete/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Products products)
        {
            try
            {
                var queryProduct = _context.Products.Find(products.pd_Id);
                queryProduct.IsDelete = true;
                _context.Products.Update(queryProduct);

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
