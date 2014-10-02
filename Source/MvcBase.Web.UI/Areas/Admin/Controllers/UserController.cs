using AutoMapper;
using Microsoft.AspNet.Identity;
using MvcBase.Model.Models;
using MvcBase.Service;
using MvcBase.Web.UI.Areas.Admin.Models;
using MvcBase.Web.UI.Areas.Admin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcBase.Web.UI.Areas.Admin.Controllers
{
    //[Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private IUserService userService;
        private ICompanyService companyService;
        private IUserProfileService userProfileService;
        private UserManager<ApplicationUser> userManager;

        public UserController(IUserService userService, 
                                 ICompanyService companyService,
                                 IUserProfileService userProfileService, 
                                 ISecurityTokenService securityTokenService,
                                 UserManager<ApplicationUser> userManager)
        {
            this.userService = userService;
            this.companyService = companyService;
            this.userProfileService = userProfileService;
            this.userManager = userManager;
        }

        // GET: Admin/User
        public ActionResult Index(int customerId)
        {
            //var user = await userManager.FindByIdAsync(User.Identity.GetUserId());
            //var users = userService.GetUsers(user.CompanyId);

            ViewBag.CompanyId = customerId;
            var users = userProfileService.GetUsers(customerId);
            var userList = Mapper.Map<IEnumerable<UserProfile>, IEnumerable<UserProfileListViewModel>>(users);
            return View(userList);
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
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var company = companyService.GetCompany(model.CompanyId);
                var user = new ApplicationUser() { UserName = model.UserName, Company = company };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var userId = user.Id;
                    var userName = user.UserName;
                    userProfileService.CreateUserProfile(userId);

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
        public ViewResult UserProfile(string id)
        {
            var user = userProfileService.GetUser(User.Identity.GetUserId());
            UserProfileFormModel editUser = Mapper.Map<UserProfile, UserProfileFormModel>(user);
            ApplicationUser applicationUser = userService.GetUser(editUser.UserId);
            editUser.CustomerId = applicationUser.CompanyId;

            return View(editUser);
        }

        [HttpPost]
        public ActionResult UserProfile(UserProfileFormModel editedProfile)
        {
            UserProfile user = Mapper.Map<UserProfileFormModel, UserProfile>(editedProfile);
            ApplicationUser applicationUser = userService.GetUser(editedProfile.UserId);
            applicationUser.FirstName = editedProfile.FirstName;
            applicationUser.LastName = editedProfile.LastName;
            applicationUser.Email = editedProfile.Email;
            if (ModelState.IsValid)
            {
                userService.UpdateUser(applicationUser);
                userProfileService.UpdateUserProfile(user);

                TempData.Add("flash", new FlashSuccessViewModel("Your Profile has been saved successfully."));

                return RedirectToAction("UserProfile", new { id = editedProfile.UserId });
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