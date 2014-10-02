using AutoMapper;
using PagedList;
using MvcBase.Model.Models;
using MvcBase.Web.Core.AutoMapperConverters;
using MvcBase.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcBase.Web.UI.Areas.Admin.ViewModel;

namespace MvcBase.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<UserProfile, MvcBase.Web.ViewModels.UserProfileFormModel>();
            Mapper.CreateMap<Company, CompanyListViewModel>();
            Mapper.CreateMap<Company, CompanyViewModel>();
            Mapper.CreateMap<Company, CompanyFormViewModel>();
            Mapper.CreateMap<UserProfile, MvcBase.Web.UI.Areas.Admin.ViewModel.UserProfileListViewModel>();
            Mapper.CreateMap<UserProfile, MvcBase.Web.UI.Areas.Admin.ViewModel.UserProfileFormModel>();
        }
    }
}