using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sideas.Josimar.Facturacion.Services.Interfaces
{
  public interface IRawService
    {
        public void Save(string payload, string entityName);
    }
}
