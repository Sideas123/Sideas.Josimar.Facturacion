using Microsoft.EntityFrameworkCore;
using Sideas.Josimar.Facturacion.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sideas.Josimar.Facturacion.Infrastructure
{
    public class BillingContext : DbContext
    {
        public BillingContext(DbContextOptions <BillingContext> options)
         : base(options)
        {
        }

        public DbSet<RawData> RawDatas { get; set; }
        public DbSet<TransactionLog> TransactionLogs { get; set; }

    }
}
