using CPD.Models.Customer;
using CPD.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CPD.MVC.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {

        // GET: Customer
        public ActionResult Index()
    {
        var userId = Guid.Parse(User.Identity.GetUserId());
        var service = new CustomerService(userId);
            var model = service.GetCustomer();


        return View(model);
    }
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(CreateCustomer model)
    {
        if (!ModelState.IsValid) return View(model);

        var service = CreateCustomerService();

        if (service.CreateCustomer(model))
        {
            TempData["SaveResult"] = "Your note was created.";

            return RedirectToAction("Index");
        };
        ModelState.AddModelError("", "Note could not be created.");
        return View(model);
    }
    public ActionResult Details(int id)
    {
        var svc = CreateCustomerService();
        var model = svc.GetCustomerById(id);

        return View(model);
    }
    public ActionResult Edit(int id)
    {
        var service = CreateCustomerService();
        var detail = service.GetCustomerById(id);
        var model =
            new EditCustomer
            {
                CustomerID = detail.CustomerID,
                Name = detail.Name,
                Address = detail.Address,
                Telephone = detail.Telephone,
                Email = detail.Email,
                Notes = detail.Notes,
                OwnerId = detail.OwnerId
            };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, EditCustomer model)
    {
        if (!ModelState.IsValid) return View(model);

        if (model.CustomerID != id)
        {
            ModelState.AddModelError("", "Id Mismatch");
            return View(model);
        }

        var service = CreateCustomerService();

        if (service.UpdateCustomer(model))
        {
            TempData["SaveResult"] = "Your note was updated.";
            return RedirectToAction("Index");
        }

        ModelState.AddModelError("", "Your note could not be updated.");
        return View(model);
    }

    [ActionName("Delete")]
    public ActionResult Delete(int id)
    {
        var svc = CreateCustomerService();
        var model = svc.GetCustomerById(id);

        return View(model);
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeletePost(int id)
    {
        var service = CreateCustomerService();

        service.DeleteCustomer(id);

        TempData["SaveResult"] = "Your note was deleted";

        return RedirectToAction("Index");
    }


    private CustomerService CreateCustomerService()
    {
        var userId = Guid.Parse(User.Identity.GetUserId());
        var service = new CustomerService(userId);
        return service;
    }

}
}
