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

namespace MvcBase.Web.UI.Areas.Setting.Controllers
{
    //[Authorize(Roles = "admin")]
    public class CompanyController : Controller
    {
        private ICompanyService companyService;
        private UserManager<ApplicationUser> UserManager;

        public CompanyController(ICompanyService companyService,
                                    UserManager<ApplicationUser> userManager)
        {
            this.companyService = companyService;
            this.UserManager = userManager;
        }

        // GET: Admin/Customer
        public ActionResult Index()
        {
            // TODO: GET COMPANIES BY FOR USER
            var companies = companyService.GetCompanies();
            var companyList = Mapper.Map<IEnumerable<Company>, IEnumerable<CompanyListViewModel>>(companies);
            return View(companyList);
        }

        // GET: Admin/Customer/Details/5
        public ActionResult Details()
        {
            string userName = HttpContext.User.Identity.Name;
            var user = UserManager.FindByName(userName);

            var company = companyService.GetCompany(user.CompanyId);
            var companyDetails = Mapper.Map<Company, CompanyViewModel>(company);
            return View(companyDetails);
        }

        // GET: Admin/Customer/Create
        public ActionResult Create()
        {
            var createCompany = new CompanyFormViewModel();
            return View(createCompany);
        }

        // POST: Admin/Customer/Create
        [HttpPost]
        public ActionResult Create(CompanyFormViewModel createCompany)
        {
            Company company = Mapper.Map<CompanyFormViewModel, Company>(createCompany);

            if (ModelState.IsValid)
            {
                companyService.CreateCompany(company);
                TempData.Add("flash", new FlashSuccessViewModel("Your company details have been created successfully."));
                return RedirectToAction("Details", new { id = company.Id });
            }
            else
            {
                TempData.Add("flash", new FlashDangerViewModel("There was an error saving your company details"));  
            }
            return View(createCompany);
        }

        // GET: Admin/Customer/Edit/5
        public ActionResult Edit()
        {
            string userName = HttpContext.User.Identity.Name;
            var user = UserManager.FindByName(userName);

            var company = companyService.GetCompany(user.CompanyId);
            CompanyFormViewModel editCompany = Mapper.Map<Company, CompanyFormViewModel>(company);
            if (company == null)
            {
                return HttpNotFound();
            }

            return View(editCompany);
        }

        // POST: Admin/Customer/Edit/
        [HttpPost]
        public ActionResult Edit(CompanyFormViewModel editCompany)
        {
            Company company = Mapper.Map<CompanyFormViewModel, Company>(editCompany);

            if (ModelState.IsValid)
            {
                companyService.UpdateCompany(company);
                TempData.Add("flash", new FlashSuccessViewModel("Your company details have been saved successfully."));
                return RedirectToAction("Details", new { id = company.Id });
            }
            else
            {
                TempData.Add("flash", new FlashDangerViewModel("There was an error saving your company details"));
            }
            return View(editCompany);
        }

        //// GET: Admin/Customer/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Admin/Customer/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
