using CPD.Models.Product;
using CPD.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CPD.MVC.Controllers
{
    public class ProductController : Controller
    {
        [Authorize]
        // GET: Customer
        public ActionResult Index()
        {
      //      var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService();
            var model = service.GetProduct();


            return View(model);
        }
        public ActionResult Create()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProjectService(userId); //create a project service
            var projects = service.GetProject();
            ViewBag.ProjectID = new SelectList(projects, "ProjectID", "Name");
            
            // assign the return value of service.GetAllProjects to ViewBag.ProjectId
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateProduct model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProductService();

            if (service.CreateProduct(model))
            {
                TempData["SaveResult"] = "Your product was created.";

                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "product could not be created.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateProductService();
            var detail = service.GetProductById(id);
            var model =
                new EditProduct
                {
                    ProductID = detail.ProductID,
                    Name = detail.Name,
                    Price = detail.Price,
                    Description = detail.Description,
                    Quantity = detail.Quantity,
                   
                    //OwnerId = detail.OwnerId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditProduct model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProductID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateProductService();

            if (service.UpdateProduct(model))
            {
                TempData["SaveResult"] = "Your product was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your product could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateProductService();

            service.DeleteProduct(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }


        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService();
            return service;
        }

    }
}
