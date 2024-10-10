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
    public partial class OrderPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSupplements();
            }
        }

        private void LoadSupplements()
        {
           
            
            List<MsSuplement> supplements = new SuplementHandler().GetSuplements(); 
            GridViewSupplements.DataSource = supplements;
            GridViewSupplements.DataBind();
        }

        protected void GridViewSupplements_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewSupplements.Rows[rowIndex];
                TextBox txtQuantity = row.FindControl("TxtQuantity") as TextBox;

                if (int.TryParse(txtQuantity.Text, out int quantity) && quantity > 0)
                {
                    int supplementId = Convert.ToInt32(e.CommandArgument);
                    new CartHandler().UpdateOrAddCart((MsUser)Session["User"], supplementId, quantity);
                    Response.Redirect("CartPage.aspx"); 
                }
                else
                {
                    LblError.Text = "Please enter a valid quantity (greater than 0).";
                }
            }
        }
    }
}