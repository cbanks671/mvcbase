using AutoMapper;
using PagedList;
using MvcBase.Model.Models;
using MvcBase.Web.Core.AutoMapperConverters;
using MvcBase.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            Mapper.CreateMap<ApplicationUser, MvcBase.Web.ViewModels.UserProfileFormModel>();
            Mapper.CreateMap<ApplicationUser, MvcBase.Web.ViewModels.UserProfileListViewModel>();
            Mapper.CreateMap<Company, CompanyListViewModel>();
            Mapper.CreateMap<Company, CompanyViewModel>();
            Mapper.CreateMap<Company, CompanyFormViewModel>();
            Mapper.CreateMap<Property, PropertyFormViewModel>();
            Mapper.CreateMap<Property, PropertyListViewModel>();
        }
    }
}