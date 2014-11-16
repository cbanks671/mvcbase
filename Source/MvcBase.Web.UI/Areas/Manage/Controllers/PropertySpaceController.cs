using AutoMapper;
using Microsoft.AspNet.Identity;
using MvcBase.Model.Models;
using MvcBase.Service;
using MvcBase.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBase.Web.UI.Areas.Manage.Controllers
{
    public class PropertySpaceController : Controller
    {
        private UserManager<ApplicationUser> UserManager;
        private IPropertySpaceService propertySpaceService;
        private IPropertyService propertyService;
        private IPropertyTypeService propertyTypeService;

        public PropertySpaceController(IPropertySpaceService propertySpaceService,
                                    IPropertyService propertyService,
                                    IPropertyTypeService propertyTypeService,
                                    UserManager<ApplicationUser> userManager)
        {
            this.propertySpaceService = propertySpaceService;
            this.propertyService = propertyService;
            this.propertyTypeService = propertyTypeService;
            this.UserManager = userManager;
        }

        // GET: Manage/PropertySpace
        public ActionResult Index(int id)
        {
            var propertySpaces = propertySpaceService.GetPropertySpaces(id);
            var propertySpaceList = Mapper.Map<IEnumerable<PropertySpace>, IEnumerable<PropertySpaceListViewModel>>(propertySpaces);

            ViewBag.PropertyId = id;
            return View(propertySpaceList);
        }

        // GET: Admin/Property/Create
        public ActionResult Create(int id)
        {
            if (id == 0)
            {
                TempData.Add("flash", new FlashDangerViewModel("A valid property listing type was not selected"));
                return RedirectToAction("Index", "Property", null);
            }

            var property = propertyService.GetProperty(id);
            if (property == null)
            {
                TempData.Add("flash", new FlashDangerViewModel("A valid property was not selected"));
                return RedirectToAction("Index", "Property", null);
            }
            
            var createPropertySpace = new PropertySpaceFormViewModel();
            createPropertySpace.PropertyId = id;

            return View(createPropertySpace);
        }

        // POST: Admin/Customer/Create
        [HttpPost]
        public ActionResult Create(PropertySpaceFormViewModel createPropertySpace)
        {
            var propertySpace = Mapper.Map<PropertySpaceFormViewModel, PropertySpace>(createPropertySpace);

            if (ModelState.IsValid)
            {
                propertySpaceService.CreatePropertySpace(propertySpace);
                TempData.Add("flash", new FlashSuccessViewModel("Your property space has been created successfully."));
                return RedirectToAction("Edit", new { id = propertySpace.Id });
            }
            else
            {
                TempData.Add("flash", new FlashDangerViewModel("There was an error saving property space"));
            }
            return View(createPropertySpace);
        }

        // GET: Admin/Property/Detail/5
        public ActionResult Edit(int id)
        {
            var propertySpace = propertySpaceService.GetPropertySpace(id);
            var propertySpaceEdit = Mapper.Map<PropertySpace, PropertySpaceFormViewModel>(propertySpace);

            if (propertySpace == null)
            {
                return HttpNotFound();
            }

            return View("Create", propertySpaceEdit);
        }
    }
}