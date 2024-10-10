using ProjectPSDLab.Handlers;
using ProjectPSDLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace ProjectPSDLab.Controllers
{

    public class UserController
    {
        UserHandler uHandler = new UserHandler();

        public MsUser Login(Label Warning,String name, String password)
        {
            
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {
                Warning.Text =  "Please fill all the fields! ";
            }

            MsUser user = uHandler.FindUserByNameAndPassword(name, password);
            if (user == null)
            {
                Warning.Text = "Invalid user credentials!";
            }

            return user;
        }

        public bool Register(Label Warning, String name, string email, string gender, string password, string confirmPassword, DateTime dob)
        {
            Warning.Text = "";
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword) || dob.Equals(DateTime.MinValue))
            {
                Warning.Text = "Please fill in all the fields!";
            }

            if (!IsValidName(name))
            {
                Warning.Text = "Username must be between 5 and 15 characters and only contain letters and spaces!";
            }

            if (!IsValidEmail(email))
            {
                Warning.Text = "Please input a valid email! (ends with .com)";
            }

            if (!password.Equals(confirmPassword))
            {
                Warning.Text = "Passwords do not match!";
            }

            if (!IsValidPassword(password))
            {
                Warning.Text = "Password must be alphanumeric only!";
            }

            if (Warning.Text == "")
            {
                uHandler.AddUser(name, email, gender, dob, password);
                return true;
            }
            return false;
        }

        public MsUser GetUserByID(int id)
        {
            return uHandler.FindUserById(id);
        }

        public void BindData(GridView gv)
        {
            gv.DataSource = uHandler.GetAllCustomers();
            gv.DataBind();
        }

        public void UpdateProfile(Label Warning, MsUser user, string name, string email, string gender, DateTime dob)
        {
            Warning.Text = "";
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
            {
                Warning.Text += "Please fill in all the fields!";
            }

            if (!IsValidName(name))
            {
                Warning.Text += "Invalid username!";
            }

            if (!IsValidEmail(email))
            {
                Warning.Text += "Invalid email!";
            }

            if (Warning.Text == "")
            {
                uHandler.UpdateUser(user, name, email, gender, dob);
            }
        }

        public void UpdatePassword(Label Warning, MsUser user, string oldPassword, string newPassword)
        {
            Warning.Text = "";
            if (string.IsNullOrWhiteSpace(oldPassword) || string.IsNullOrWhiteSpace(newPassword))
            {
                Warning.Text += "Please fill in all the fields!";
            }

            if (!IsValidPassword(newPassword))
            {
                Warning.Text += "Invalid password format!";
            }

            if (uHandler.FindUserByNameAndPassword(user.Username, oldPassword) == null)
            {
                Warning.Text += "Incorrect old password!";
            }

            if (Warning.Text == "")
            {
                uHandler.UpdateUserPassword(user, newPassword);
            }
        }

        private bool IsValidName(string name)
        {
            return name.Length > 5 || name.Length < 15 && Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
        }

        private bool IsValidEmail(string email)
        {
            return email.EndsWith(".com");
        }

        private bool IsValidPassword(string password)
        {
            return Regex.IsMatch(password, @"^[a-zA-Z0-9]+$");
        }
    }

}