using ProjectPSDLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSDLab.Factories
{
    public class CartFactory
    {
        public static MsCart Create(int cartid, int userid, int supplyid, int qty)
        {
            MsCart cart = new MsCart();
            cart.CartID = cartid;
            cart.UserID = userid;
            cart.SuplementID = supplyid;
            cart.Quantity = qty;

            return cart;
        }
    }
}