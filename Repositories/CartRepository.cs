using ProjectPSDLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace ProjectPSDLab.Repositories
{
    public class CartRepository
    {
        LocalDatabaseEntities2 db = DatabaseSingleton.GetInstance();

        public List<MsCart> FindCartsByUserId(int userId)
        {
            return db.MsCarts.Where(c => c.UserID == userId).ToList();
        }

        public void AddCart(MsCart cart)
        {
            db.MsCarts.Add(cart);
            db.SaveChanges();
        }

        public void DeleteCart(MsCart cart)
        {
            db.MsCarts.Remove(cart);
            db.SaveChanges();
        }

        public void UpdateCartQuantity(int cartId, int quantity)
        {
            MsCart cart = db.MsCarts.Find(cartId);
            if (cart != null)
            {
                cart.Quantity = quantity;
                db.SaveChanges();
            }
        }

        public int GetLastCartId()
        {
            return db.MsCarts.Select(c => c.CartID).LastOrDefault();
        }
    }

}