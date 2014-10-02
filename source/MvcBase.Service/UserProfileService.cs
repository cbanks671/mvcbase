﻿using MvcBase.Data.Repository;
using MvcBase.Data.Infrastructure;
using MvcBase.Model.Models;
using System;
using System.Collections.Generic;

namespace MvcBase.Service
{
    public interface IUserProfileService
    {
        UserProfile GetProfile(int id);
        UserProfile GetUser(string userid);
        IEnumerable<UserProfile> GetUsers(int companyId);
        UserProfile GetUserByEmail(string email);
        
        void CreateUserProfile(string userId);
        void UpdateUserProfile(UserProfile user);
        void SaveUserProfile();
    }
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository userProfileRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserProfileService(IUserProfileRepository userProfileRepository, IUnitOfWork unitOfWork)
        {
            this.userProfileRepository = userProfileRepository;
            this.unitOfWork = unitOfWork;
        }

        public UserProfile GetProfile(int id)
        {
            var userprofile = userProfileRepository.Get(u => u.UserProfileId == id);
            return userprofile;
        }
        public UserProfile GetUser(string userid)
        {
            var userprofile = userProfileRepository.Get(u => u.UserId == userid);
            return userprofile;
        }

        public IEnumerable<UserProfile> GetUsers(int companyId)
        {
            var userprofile = userProfileRepository.GetMany(u => u.User.CompanyId == companyId);
            return userprofile;
        }

        public UserProfile GetUserByEmail(string email)
        {
            var userProfile = userProfileRepository.Get(u => u.Email == email);
            return userProfile;
        }

        public void CreateUserProfile(string userId)
        {

            UserProfile newUserProfile = new UserProfile();
            newUserProfile.UserId = userId;
            userProfileRepository.Add(newUserProfile);
            SaveUserProfile();
        }
        public void UpdateUserProfile(UserProfile user)
        {
            userProfileRepository.Update(user);
            SaveUserProfile();
        }
        public void SaveUserProfile()
        {
            unitOfWork.Commit();
        }
    }
}
