using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MvcBase.Model.Models;
using MvcBase.Service;
using Microsoft.AspNet.Identity;
using MvcBase.Web.ViewModels;

namespace MvcBase.Web.UI.Areas.Manage.Controllers
{
    public class PropertyController : Controller
    {
        private UserManager<ApplicationUser> UserManager;
        private IPropertyService propertyService;

        public PropertyController(IPropertyService propertyService,
                                    UserManager<ApplicationUser> userManager)
        {
            this.propertyService = propertyService;
            this.UserManager = userManager;
        }

        // GET: Property
        public ActionResult Index()
        {
            string userName = HttpContext.User.Identity.Name;
            var user = UserManager.FindByName(userName);

            var properties = propertyService.GetProperties(user.CompanyId);
            var propertyList = Mapper.Map<IEnumerable<Property>, IEnumerable<PropertyListViewModel>>(properties);
            return View(propertyList);
        }

        // GET: Admin/Property/Create
        public ActionResult Create()
        {
            var createProperty = new PropertyFormViewModel();

            string userName = HttpContext.User.Identity.Name;
            var user = UserManager.FindByName(userName);
            createProperty.CompanyId = user.CompanyId;

            return View(createProperty);
        }

        // POST: Admin/Customer/Create
        [HttpPost]
        public ActionResult Create(PropertyFormViewModel createProperty)
        {
            var property = Mapper.Map<PropertyFormViewModel, Property>(createProperty);

            if (ModelState.IsValid)
            {
                propertyService.CreateProperty(property);
                TempData.Add("flash", new FlashSuccessViewModel("Your property details have been created successfully."));
                return RedirectToAction("Details", new { id = property.Id });
            }
            else
            {
                TempData.Add("flash", new FlashDangerViewModel("There was an error saving property"));
            }
            return View(createProperty);
        }

        // GET: Admin/Property/Detail/5
        public ActionResult Details(int id)
        {
            var property = propertyService.GetProperty(id);
            var propertyDetail = Mapper.Map<Property, PropertyFormViewModel>(property);

            if (property == null)
            {
                return HttpNotFound();
            }

            return View(propertyDetail);
        }
    }
}