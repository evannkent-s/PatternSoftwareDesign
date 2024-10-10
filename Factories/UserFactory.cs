using ProjectPSDLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSDLab.Factories
{
    public class UserFactory
    {
        public static MsUser Create(int UserID, String UserName, String UserEmail, DateTime UserDOB, String UserGender, String UserRole, String Password)
        {
            MsUser user = new MsUser();

            user.UserID = UserID;
            user.Username = UserName;
            user.Email = UserEmail;
            user.UserDOB = UserDOB;
            user.UserGender = UserGender;
            user.UserRole = UserRole;
            user.UserPassword = Password;


            return user;
        }
    }
}