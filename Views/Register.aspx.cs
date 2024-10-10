using ProjectPSDLab.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSDLab.Views
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        UserController userController = new UserController();

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            String username = TxtUsername.Text;
            String email = TxtEmail.Text;
            String gender = DdlGender.SelectedValue;
            String password = TxtPassword.Text;
            String confirmPassword = TxtConfirmPassword.Text;
            String dobText = TxtDOB.Text;

            
            if (string.IsNullOrWhiteSpace(dobText))
            {
                LblError.Text = "Date of Birth is required.";
                LblError.Visible = true;
                return;
            }
            DateTime dob = Convert.ToDateTime(TxtDOB.Text);
            
            

            bool isRegistered = userController.Register(LblError, username, email, gender, password, confirmPassword, dob);

            if (isRegistered)
            {
               
                Response.Redirect("Login.aspx");
            }
            else
            {
                LblError.Visible = true;
            }
        }
    }
}