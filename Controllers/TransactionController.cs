using ProjectPSDLab.Handlers;
using ProjectPSDLab.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI.WebControls;

namespace ProjectPSDLab.Controllers
{
    public class TransactionController
    {
        Handlers.TransactionHandler transHandler = new Handlers.TransactionHandler();

        public void PopulateTransactions(GridView gridView, MsUser user)
        {
            List<TransactionHeader> headers = transHandler.GetTHByUser(user);
            gridView.DataSource = headers;
            gridView.DataBind();
        }

        public List<TransactionHeader> FetchTransactionHeaders(MsUser user)
        {
            return transHandler.GetTHByUser(user);
        }

        public void DisplayTransactionDetails(int transactionID, Label idLabel, Label userLabel, Label dateLabel, Label statusLabel, GridView gridView)
        {
            TransactionHeader header = transHandler.GetTHById(transactionID);
            List<TransactionDetail> details = transHandler.GetTDByHeader(header);

            idLabel.Text = "ID: " + header.TransactionID;
            userLabel.Text = "User: " + header.MsUser.Username;
            dateLabel.Text = "Date: " + header.TransactionDate.ToString("d");
            statusLabel.Text = "Status: " + header.Status;

            gridView.DataSource = details;
            gridView.DataBind();
        }

        // Processes a transaction and updates the GridView
        public void ProcessTransaction(GridView gridView, MsUser user, int transactionID)
        {
            transHandler.MarkTransaction(transactionID);
            PopulateTransactions(gridView, user);
        }
    }

}