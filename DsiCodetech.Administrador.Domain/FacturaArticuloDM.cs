using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Domain
{
    public class FacturaArticuloDM
    {
        public Guid IdFacturaArticulo { get; set; }
        public string IdFactura { get; set; }
        public string CodigoBarras { get; set; }
        public string Descripcion { get; set; }
        public Guid IdUnidad { get; set; }
        public double Cantidad { get; set; }
        public double Iva { get; set; }
        public double PrecioVenta { get; set; }
    }
}
