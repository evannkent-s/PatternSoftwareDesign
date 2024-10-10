using ProjectPSDLab.Handlers;
using ProjectPSDLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ProjectPSDLab.Controllers
{
    public class SuplementController
    {
        SuplementHandler SupHandler = new SuplementHandler();

        public void PopulateGridView(GridView gridView)
        {
            gridView.DataSource = SupHandler.GetSuplements();
            gridView.DataBind();
        }

        public void PopulateDropDownList(DropDownList dropDownList)
        {
            dropDownList.DataSource = SupHandler.GetAllSuplementTypeNames();
            dropDownList.DataBind();
        }

        public bool AddSupplement(Label error, string name, string priceStr, string typeName, DateTime expiry)
        {
            error.Text = "";
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(priceStr) || string.IsNullOrEmpty(typeName) || expiry == DateTime.MinValue)
            {
                error.Text += "> Please fill in all the fields! </br>";
            }

            if (!name.Contains("Supplement"))
            {
                error.Text += "> Name must contain 'Supplement'! </br>";
            }

            if (!int.TryParse(priceStr, out int price) || price < 3000)
            {
                error.Text += price < 3000 ? "> Price must be at least 3000! </br>" : "> Please input a valid price! </br>";
            }

            if (expiry <= DateTime.Now)
            {
                error.Text += "> Expiry Date must be in the future! </br>";
            }

            if (error.Text.Length == 0)
            {
                SupHandler.AddSupplement(name, expiry, price, typeName);
                return true;
            }
            return false;
        }

        public void DeleteSupplement(int id)
        {
            SupHandler.DeleteSuplement(id);
        }

        public MsSuplement FetchSupplement(int id)
        {
            return SupHandler.FindSuplementById(id);
        }

        public bool UpdateSupplement(Label error, int id, string name, string priceStr, string typeName, DateTime expiry)
        {
            error.Text = "";
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(priceStr) || string.IsNullOrEmpty(typeName) || expiry == DateTime.MinValue)
            {
                error.Text += "> Please fill in all the fields! </br>";
            }

            if (!name.Contains("Supplement"))
            {
                error.Text += "> Name must contain 'Supplement'! </br>";
            }

            if (!int.TryParse(priceStr, out int price) || price < 3000)
            {
                error.Text += price < 3000 ? "> Price must be at least 3000! </br>" : "> Please input a valid price! </br>";
            }

            if (expiry <= DateTime.Now)
            {
                error.Text += "> Expiry Date must be in the future! </br>";
            }

            if (error.Text.Length == 0)
            {
                SupHandler.UpdateExistingSupplement(id, name, expiry, price, typeName);
                return true;
            }
            return false;
        }
    }

}