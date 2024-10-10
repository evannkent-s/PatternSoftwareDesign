using ProjectPSDLab.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.WebControls;
using ProjectPSDLab.Models;

namespace ProjectPSDLab.Controllers
{
    public class CartController
    {
        CartHandler cartHandler = new CartHandler();

        public void PopulateCartGridView(GridView gridView, MsUser user)
        {
            List<MsCart> carts = cartHandler.FetchCarts(user);
            gridView.DataSource = carts;
            gridView.DataBind();
        }

        public void ClearUserCart(GridView gridView, MsUser user)
        {
            cartHandler.ClearCart(user);
            PopulateCartGridView(gridView, user);
        }

        public void AddToCart(GridView gridView, MsUser user, int supplementID, string quantityStr)
        {
            if (!int.TryParse(quantityStr, out int quantity) || quantity <= 0)
            {
                return; 
            }

            cartHandler.UpdateOrAddCart(user, supplementID, quantity);
            PopulateCartGridView(gridView, user);
        }

        public void Checkout(GridView gridView, MsUser user)
        {
            if (cartHandler.CheckoutCart(user))
            {
                ClearUserCart(gridView, user); 
            }
        }
    }

}