using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Domain.Filter.Model
{
    public class FacturaFilterDM
    {
        public long Id { get; set; }

        public string Rfc { get; set; }

        public string RazonSocial { get; set; }

        public string Uuid { get; set; }

        public string Status { get; set; }

        public string MetodoPago { get; set; }

        public string FormaPago { get; set; }

        public string UsoCfdi { get; set; }

        public DateTime FechaRemision { get; set; }
    }
}
