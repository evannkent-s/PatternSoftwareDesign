using ProjectPSDLab.Factories;
using ProjectPSDLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSDLab.Repositories
{
    public class UserRepository
    {
        LocalDatabaseEntities2 db = DatabaseSingleton.GetInstance();

        public List<MsUser> GetUsers()
        {
            return (from x in db.MsUsers select x).ToList();
        }

        public List<MsUser> GetCustomers()
        {
            return (from x in db.MsUsers where x.UserRole.Equals("Customer") select x).ToList();
        }

        public void InsertUser(int id, String username, String email, DateTime DOB, String gender, String role, String password)
        {
            MsUser user = UserFactory.Create(id, username, email, DOB, gender, role, password);
            db.MsUsers.Add(user);
            db.SaveChanges();
        }

        public MsUser GetUser(String username, String password)
        {
            return (from x in db.MsUsers where x.Username.Equals(username) && x.UserPassword.Equals(password) select x).FirstOrDefault();
        }

        public void UpdatePassByID(int userID, string newPass)
        {
            MsUser User = db.MsUsers.Find(userID);
            User.UserPassword = newPass;
            db.SaveChanges();
        }

        public void UpdateUserByID(int userID, string name, string email, string gender, DateTime DOB)
        {
            MsUser User = db.MsUsers.Find(userID);
            User.Username = name;
            User.Email = email;
            User.UserGender = gender;
            User.UserDOB = DOB;
            db.SaveChanges();
        }

    }
}