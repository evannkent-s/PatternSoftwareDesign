using ProjectPSDLab.Controllers;
using ProjectPSDLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSDLab.Views
{
    public partial class Profile : System.Web.UI.Page
    {
        UserController userController = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    LoadProfile();
                }
                else
                {
                    Response.Redirect("~/Views/Login.aspx"); 
                }
            }
        }

        private void LoadProfile()
        {
            if (Session["User"] == null) return;
            MsUser user = Session["User"] as MsUser;

            TxtUsername.Text = user.Username;
            TxtEmail.Text = user.Email;
            DdlGender.SelectedValue = user.UserGender;
            TxtDOB.SelectedDate = user.UserDOB;
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            UserController userController = new UserController();
            MsUser user = Session["User"] as MsUser;

            String Username = TxtUsername.Text;
            String Email = TxtEmail.Text;
            String Gender = DdlGender.SelectedValue;
            DateTime dob = TxtDOB.SelectedDate;

            userController.UpdateProfile(LblError, user, Username, Email, Gender, dob);

            LblError.Text = "Profile updated successfully!";
            LblError.ForeColor = System.Drawing.Color.Green;
        }

    }
}