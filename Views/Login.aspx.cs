using ProjectPSDLab.Controllers;
using ProjectPSDLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ProjectPSDLab.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginBTN_Click(object sender, EventArgs e)
        {
            string name = UsernameTB.Text;
            string password = PasswordTB.Text;
       
            UserController userController = new UserController();

            MsUser user = userController.Login(Labels ,name, password);

            if (user != null)
            {
                if (rememberme.Checked)
                {
                    HttpCookie cookie = new HttpCookie("user-id");
                    cookie.Value = user.UserID.ToString();
                    Response.Cookies.Add(cookie);
                }
                Session["User"] = user;

                
                Response.Redirect("~/Views/HomePage.aspx");
                
            }
        }

        protected void RegisterBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Register.aspx");
        }
    }
}