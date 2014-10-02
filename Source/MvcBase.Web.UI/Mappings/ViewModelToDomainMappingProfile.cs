using AutoMapper;
using MvcBase.Model.Models;
using MvcBase.Web.UI.Areas.Admin.ViewModel;
using MvcBase.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBase.Mappings
{

    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<MvcBase.Web.ViewModels.UserProfileFormModel, UserProfile>();
            Mapper.CreateMap<CompanyListViewModel, Company>();
            Mapper.CreateMap<CompanyViewModel, Company>();
            Mapper.CreateMap<CompanyFormViewModel, Company>();
            Mapper.CreateMap<MvcBase.Web.UI.Areas.Admin.ViewModel.UserProfileListViewModel, UserProfile>();
        }
    }
}