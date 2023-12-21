using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sideas.Josimar.Facturacion.Services.Interfaces
{
    public interface ITransactionLogService
    {
        public void AddLog(string referenceId);
        public void UpdateLog(string referenceId, bool success);
    }
}
