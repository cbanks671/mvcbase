using AutoMapper;
using MvcBase.Model.Models;
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
            Mapper.CreateMap<CompanyListViewModel, Company>();
            Mapper.CreateMap<CompanyViewModel, Company>();
            Mapper.CreateMap<CompanyFormViewModel, Company>();
            Mapper.CreateMap<PropertyFormViewModel, Property>();
            Mapper.CreateMap<PropertyListViewModel, Property>();
            Mapper.CreateMap<PropertySpaceFormViewModel, PropertySpace>();
            Mapper.CreateMap<PropertySpaceListViewModel, PropertySpace>();
        }
    }
}