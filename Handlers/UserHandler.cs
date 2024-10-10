using ProjectPSDLab.Factories;
using ProjectPSDLab.Models;
using ProjectPSDLab.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSDLab.Handlers
{
    public class UserHandler
    {
        UserRepository UserRepo = new UserRepository();

        public MsUser FindUserByNameAndPassword(string name, string password)
        {
            var users = UserRepo.GetUsers();
            return users.FirstOrDefault(user => user.Username == name && user.UserPassword == password);
        }

        private int GetNextUserId()
        {
            var users = UserRepo.GetUsers();
            return users.Any() ? users.Last().UserID + 1 : 1;
        }

        public void AddUser(string name, string email, string gender, DateTime dob, string password)
        {
            UserRepo.InsertUser(GetNextUserId(), name, email, dob, gender, "", password);
        }

        public MsUser FindUserById(int id)
        {
            var users = UserRepo.GetUsers();
            return users.FirstOrDefault(user => user.UserID == id);
        }

        public List<MsUser> GetAllCustomers()
        {
            return UserRepo.GetUsers().Where(user => user.UserRole == "Customer").ToList();
        }

        public void UpdateUser(MsUser user, string name, string email, string gender, DateTime dob)
        {
            UserRepo.UpdateUserByID(user.UserID, name, email, gender, dob);
        }

        public void UpdateUserPassword(MsUser user, string newPassword)
        {
            UserRepo.UpdatePassByID(user.UserID, newPassword);
        }
    }

}