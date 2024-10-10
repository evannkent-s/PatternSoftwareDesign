using ProjectPSDLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSDLab.Repositories
{
    public class TransactionRepository
    {
        private LocalDatabaseEntities2 db = DatabaseSingleton.GetInstance();

        public List<TransactionHeader> GetAllTransactionHeaders()
        {
            return db.TransactionHeaders.ToList();
        }

        public List<TransactionDetail> GetAllTransactionDetails()
        {
            return db.TransactionDetails.ToList();
        }

        public void ChangeTransactionStatus(int transactionId, string newStatus)
        {
            TransactionHeader header = db.TransactionHeaders.Find(transactionId);
            if (header != null)
            {
                header.Status = newStatus;
                db.SaveChanges();
            }
        }

        public void InsertTransactionHeader(TransactionHeader header)
        {
            db.TransactionHeaders.Add(header);
            db.SaveChanges();
        }

        public void InsertTransactionDetail(TransactionDetail detail)
        {
            db.TransactionDetails.Add(detail);
            db.SaveChanges();
        }

        
    }
}