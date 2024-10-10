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
    public class TransactionHandler
    {
        TransactionRepository transRepo = new TransactionRepository();

        private int GetNextTransactionId()
        {
            var transactionHeaders = transRepo.GetAllTransactionHeaders();
            return transactionHeaders.Any() ? transactionHeaders.Last().TransactionID + 1 : 1;
        }

        public TransactionHeader CreateNewTH(MsUser user)
        {
            TransactionHeader newHeader = TransactionFactory.CreateTH(GetNextTransactionId(), user.UserID, DateTime.Now, "unhandled");
            transRepo.InsertTransactionHeader(newHeader);
            return newHeader;
        }

        public void AddTransactionDetail(int transactionHeaderId, MsCart cartItem)
        {
            TransactionDetail newDetail = TransactionFactory.CreateTD(transactionHeaderId, cartItem.SuplementID, cartItem.Quantity);
            transRepo.InsertTransactionDetail(newDetail);
        }

        public List<TransactionHeader> GetTHByUser(MsUser user)
        {
            var allHeaders = transRepo.GetAllTransactionHeaders();
            return user.UserRole == "admin" ? allHeaders : allHeaders.Where(header => header.UserID == user.UserID).ToList();
        }

        public TransactionHeader GetTHById(int transactionHeaderId)
        {
            return transRepo.GetAllTransactionHeaders().FirstOrDefault(header => header.TransactionID == transactionHeaderId);
        }

        public List<TransactionDetail> GetTDByHeader(TransactionHeader transactionHeader)
        {
            return transRepo.GetAllTransactionDetails().Where(detail => detail.TransactionID == transactionHeader.TransactionID).ToList();
        }

        public void MarkTransaction(int HeaderId)
        {
            transRepo.ChangeTransactionStatus(HeaderId, "handled");
        }
    }

}