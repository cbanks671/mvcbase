using AutoMapper;
using Microsoft.AspNet.Identity;
using MvcBase.Model.Models;
using MvcBase.Service;
using MvcBase.Web.UI.Models;
using MvcBase.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcBase.Web.UI.Areas.Setting.Controllers
{
    //[Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private IUserService userService;
        private ICompanyService companyService;
        private UserManager<ApplicationUser> userManager;

        public UserController(IUserService userService, 
                                 ICompanyService companyService,
                                 ISecurityTokenService securityTokenService,
                                 UserManager<ApplicationUser> userManager)
        {
            this.userService = userService;
            this.companyService = companyService;
            this.userManager = userManager;
        }

        // GET: Admin/User
        public ActionResult Index()
        {
            var user = userManager.FindById(User.Identity.GetUserId());
            var users = userService.GetUsers(user.CompanyId);

            ViewBag.CompanyId = user.CompanyId;
            //var users = userProfileService.GetUsers(customerId);
            var userList = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<UserProfileListViewModel>>(users);
            return View(userList);
            //return View();
        }

        public ActionResult Create(int customerId)
        {
            RegisterViewModel model = new RegisterViewModel();
            var customer = companyService.GetCompany(customerId);

            if (customer != null)
            {
                model.CompanyId = customer.Id;
                return View(model);
            }
            else
            {
                TempData.Add("flash", new FlashDangerViewModel("There was an error trying to get company record."));
                RedirectToAction("index", new { customerId = customerId });
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var company = companyService.GetCompany(model.CompanyId);
                var user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    ContactNo = model.ContactNo,
                    Company = company
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var userId = user.Id;
                    var userName = user.UserName;
                    //userProfileService.CreateUserProfile(userId);

                    return RedirectToAction("UserProfile", new { id = userId });
                }
                else
                {
                    AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        public ViewResult Edit(string id)
        {
            var user = userManager.FindById(id);
            UserProfileFormModel editUser = Mapper.Map<ApplicationUser, UserProfileFormModel>(user);

            return View(editUser);
        }

        [HttpPost]
        public ActionResult Edit(UserProfileFormModel editedProfile)
        {
            ApplicationUser applicationUser = userService.GetUser(editedProfile.Id);
            applicationUser.FirstName = editedProfile.FirstName;
            applicationUser.LastName = editedProfile.LastName;
            applicationUser.Email = editedProfile.Email;
            applicationUser.ContactNo = editedProfile.ContactNo;
            if (ModelState.IsValid)
            {
                userService.UpdateUser(applicationUser);

                TempData.Add("flash", new FlashSuccessViewModel("Your Profile has been saved successfully."));

                return RedirectToAction("UserProfile", new { id = editedProfile.Id });
            }
            return View(editedProfile);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

    }
}