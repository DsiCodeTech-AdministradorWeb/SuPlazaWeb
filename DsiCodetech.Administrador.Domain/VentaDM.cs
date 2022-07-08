using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Domain
{
    public  class VentaDM
    {
        public int IdPos { get; set; }
        public System.Guid IdVenta { get; set; }
        public string Vendedor { get; set; }
        public long Folio { get; set; }
        public System.DateTime FechaVenta { get; set; }
        public decimal TotalVendido { get; set; }
        public decimal PagoEfectivo { get; set; }
        public decimal PagoCheque { get; set; }
        public decimal PagoVales { get; set; }
        public decimal PagoTc { get; set; }
        public string Supervisor { get; set; }
        public bool Upload { get; set; }
        public short NumRegistros { get; set; }
    }
}
