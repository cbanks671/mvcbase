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
            Mapper.CreateMap<UserProfileFormModel, UserProfile>();
        }
    }
}