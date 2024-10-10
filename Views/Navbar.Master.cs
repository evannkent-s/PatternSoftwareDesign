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
    public partial class Navbar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null && Request.Cookies["user-id"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            else if (Session["user"] == null)
            {
                UserController userController = new UserController();
                int userID = int.Parse(Request.Cookies["user-id"].Value);
                Session["user"] = userController.GetUserByID(userID);
            }

            MsUser user = Session["User"] as MsUser;
        }

        protected void OrderBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/OrderPage.aspx");
        }

        protected void Historybtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HistoryPage.aspx");
        }

        protected void ProfileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Profile.aspx");
        }

        protected void LogOutBtn_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Session.Remove("User");
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Views/Login.aspx");
        }
    }
}