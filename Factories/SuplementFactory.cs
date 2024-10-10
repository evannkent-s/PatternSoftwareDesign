using ProjectPSDLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSDLab.Factories
{
    public class SuplementFactory
    {
        public static MsSuplement Create(int id, string name, DateTime Expired, int price, int typeid)
        {
            MsSuplement ms = new MsSuplement();
            ms.SuplementID = id;
            ms.SuplementName = name;
            ms.SuplementExpired = Expired;
            ms.SuplementPrice = price;
            ms.SuplementTypeID = typeid;

            return ms;
        }
    }
}