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
        private IPropertyTypeService propertyTypeService;

        public PropertyController(IPropertyService propertyService,
                                    IPropertyTypeService propertyTypeService,
                                    UserManager<ApplicationUser> userManager)
        {
            this.propertyService = propertyService;
            this.propertyTypeService = propertyTypeService;
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
        public ActionResult ListType()
        {
            return View();
        }

        // GET: Admin/Property/Create
        public ActionResult Create(int? id)
        {
            if (id == 0 || id == null)
            {
                TempData.Add("flash", new FlashDangerViewModel("A valid property listing type was not selected"));
                return RedirectToAction("ListType", "Property", null);
            }

            if (!Enum.IsDefined(typeof(PropertyListType), id))
            {
                TempData.Add("flash", new FlashDangerViewModel("A valid property listing type was not selected"));
                return RedirectToAction("ListType", "Property", null);
            }

            var createProperty = new PropertyFormViewModel();

            string userName = HttpContext.User.Identity.Name;
            var user = UserManager.FindByName(userName);
            createProperty.CompanyId = user.CompanyId;
            createProperty.PropertyListType = (PropertyListType)id;

            createProperty.PropertyTypeList = new List<SelectListItem>();
            IEnumerable<PropertyType> propertyType = propertyTypeService.GetPropertyTypes();
            createProperty.PropertyTypeList = from pt in propertyType
                                               select new SelectListItem
                                               {
                                                   Text = pt.Name.ToString(),
                                                   Value = pt.Id.ToString()
                                               };

            ViewBag.PropertyListType = (PropertyListType)id;

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
                return RedirectToAction("Edit", new { id = property.Id });
            }
            else
            {
                TempData.Add("flash", new FlashDangerViewModel("There was an error saving property"));
            }
            return View(createProperty);
        }

        // GET: Admin/Property/Detail/5
        public ActionResult Edit(int id)
        {
            var property = propertyService.GetProperty(id);
            var propertyDetail = Mapper.Map<Property, PropertyFormViewModel>(property);

            if (property == null)
            {
                return HttpNotFound();
            }

            propertyDetail.PropertyTypeList = new List<SelectListItem>();
            IEnumerable<PropertyType> propertyType = propertyTypeService.GetPropertyTypes();
            propertyDetail.PropertyTypeList = from pt in propertyType
                                              select new SelectListItem
                                              {
                                                  Text = pt.Name.ToString(),
                                                  Value = pt.Id.ToString()
                                              };

            return View("Create", propertyDetail);
        }

        // POST: Admin/Customer/Create
        [HttpPost]
        public ActionResult Edit(PropertyFormViewModel editProperty)
        {
            var property = Mapper.Map<PropertyFormViewModel, Property>(editProperty);

            if (ModelState.IsValid)
            {
                propertyService.UpdateProperty(property);
                TempData.Add("flash", new FlashSuccessViewModel("Your property details have been saved successfully."));
                return RedirectToAction("Edit", new { id = property.Id });
            }
            else
            {
                TempData.Add("flash", new FlashDangerViewModel("There was an error saving property"));
            }
            return View(editProperty);
        }
    }
}