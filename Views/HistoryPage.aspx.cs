using ProjectPSDLab.Handlers;
using ProjectPSDLab.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSDLab.Views
{
    public partial class HistoryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Session["User"] == null)
                {
                    Response.Redirect("~/Views/Login.aspx");
                }
                else
                {
                    LoadTransactionHistory();
                }
            }
        }

        private void LoadTransactionHistory()
        {
            
            MsUser currentUser = Session["User"] as MsUser;
            if (currentUser != null)
            {
                List<TransactionHeader> transactions = new TransactionHandler().GetTHByUser(currentUser);
                GridViewTransactions.DataSource = transactions;
                GridViewTransactions.DataBind();
            }
            else
            {
                
                Response.Redirect("LoginPage.aspx");
            }
        }

        protected void GridViewTransactions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                int transactionId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"TransactionDetails.aspx?TransactionId={transactionId}"); // Redirect to a detailed view page
            }
        }
    }
}