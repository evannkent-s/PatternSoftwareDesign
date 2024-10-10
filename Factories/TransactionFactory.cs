using ProjectPSDLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSDLab.Factories
{
    public class TransactionFactory
    {
        public static TransactionHeader CreateTH(int transid, int userid, DateTime date, String status)
        {
            TransactionHeader th = new TransactionHeader();
            th.TransactionID = transid;
            th.UserID = userid;
            th.TransactionDate = date;
            th.Status = status;

            return th;
        }

        public static TransactionDetail CreateTD(int transid, int supId, int quantity)
        {
            TransactionDetail td = new TransactionDetail();
            td.TransactionID = transid;
            td.SuplementID = supId;
            td.Quantity = quantity;

            return td;
        }
    }
}