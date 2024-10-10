using ProjectPSDLab.Factories;
using ProjectPSDLab.Models;
using ProjectPSDLab.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace ProjectPSDLab.Handlers
{
    public class CartHandler
    {
        CartRepository cartRepo = new CartRepository();

        public List<MsCart> FetchCarts(MsUser user)
        {
            return cartRepo.FindCartsByUserId(user.UserID);
        }

        public void ClearCart(MsUser user)
        {
            var carts = cartRepo.FindCartsByUserId(user.UserID);
            foreach (MsCart cart in carts)
            {
                cartRepo.DeleteCart(cart);
            }
        }

        public void UpdateOrAddCart(MsUser user, int supplementID, int quantity)
        {
            var existingCarts = cartRepo.FindCartsByUserId(user.UserID);
            MsCart existingCart = existingCarts.FirstOrDefault(c => c.SuplementID == supplementID);

            if (existingCart != null)
            {
                int newQuantity = existingCart.Quantity + quantity;
                cartRepo.UpdateCartQuantity(existingCart.CartID, newQuantity);
            }
            else
            {
                var newCart = CartFactory.Create(cartRepo.GetLastCartId() + 1, user.UserID, supplementID, quantity);
                cartRepo.AddCart(newCart);
            }
        }

        public bool CheckoutCart(MsUser user)
        {
            var carts = cartRepo.FindCartsByUserId(user.UserID);
            if (carts.Any())
            {
                TransactionHandler transactionHandler = new TransactionHandler();
                TransactionHeader header = transactionHandler.CreateNewTH(user);

                foreach (MsCart cartItem in carts)
                {
                    transactionHandler.AddTransactionDetail(header.TransactionID, cartItem);
                }
                ClearCart(user);  
                return true;
            }
            return false;
        }
    }


}