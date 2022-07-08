using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Domain
{
    public  class FacturaVentaDM
    {
        public int IdPos { get; set; }
        public System.Guid IdVenta { get; set; }
        public long IdFactura { get; set; }
        public System.DateTime FechaRegistro { get; set; }

        public FacturaDM FacturaDM { get; set; }
        public VentaDM VentaDM { get; set; }
    }
}
