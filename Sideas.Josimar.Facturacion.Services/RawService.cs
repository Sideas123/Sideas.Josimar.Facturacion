using Microsoft.Extensions.Logging;
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
    public class RawService : IRawService

    {
        private BillingContext _billingContext;
        private readonly ILogger _logger;

        public RawService(BillingContext billingContext, ILoggerFactory logger)
        {
            _billingContext = billingContext;
            _logger = logger.CreateLogger<RawService>();
        }

        public void Save(string payload, string entityName)
        {
            try
            {
               
                if (payload == string.Empty)
                {
                    throw new ArgumentNullException("El payload es obligatorio");
                }
                var Raw = new RawData();
                Raw.EntityName = entityName;
                Raw.Payload = payload;
                Raw.ImportTimestamp_UTC = DateTime.UtcNow;
                _billingContext.RawDatas.Add(Raw);
                _billingContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new InvalidDataException(ex.Message);
            }
           

        }
    }
}
