using Microsoft.EntityFrameworkCore;
using Sideas.Josimar.Facturacion.Entities;
using Sideas.Josimar.Facturacion.Infrastructure;
using Sideas.Josimar.Facturacion.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sideas.Josimar.Facturacion.Services
{
    public class TransactionLogService : ITransactionLogService
    {
        private BillingContext _billingContext;

        public TransactionLogService(BillingContext billingContext)
        {
            _billingContext = billingContext;
        }

        public void AddLog(string referenceId)
        {
            var TransactionLog = new TransactionLog();
            TransactionLog.StartDate = DateTime.UtcNow;
            TransactionLog.ReferenceId= referenceId;    

            _billingContext.TransactionLogs.Add(TransactionLog);
            _billingContext.SaveChanges();
        }

        public void UpdateLog(string referenceId, bool success)
        {
            var transactionLog = _billingContext.TransactionLogs.Where(x => x.ReferenceId == referenceId).SingleOrDefault();

            if (transactionLog == null)
            {
                throw new ArgumentNullException("TransactionLog not found, referenceId: " + referenceId);
            }

            transactionLog.Success = success;
            transactionLog.EndDate = DateTime.UtcNow;
            _billingContext.Update(transactionLog);
            _billingContext.SaveChanges();
        }
    }
}
