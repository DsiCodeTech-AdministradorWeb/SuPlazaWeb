using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace DsiCodetech.Administrador.Web.Dto
{
    public class VentaDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "id_venta")]
        public Guid IdVenta { get; set; }

        [JsonProperty(PropertyName = "vendedor")]
        public string Vendedor { get; set; }

        [JsonProperty(PropertyName = "folio")]
        public long Folio { get; set; }

        [JsonProperty(PropertyName = "fecha_venta")]
        public DateTime FechaVenta { get; set; }

        [JsonProperty(PropertyName = "total_vendido")]
        public decimal TotalVendido { get; set; }

        [JsonProperty(PropertyName = "pago_efectivo")]
        public decimal PagoEfectivo { get; set; }

        [JsonProperty(PropertyName = "pago_cheque")]
        public decimal PagoCheque { get; set; }

        [JsonProperty(PropertyName = "pago_vales")]
        public decimal PagoVales { get; set; }

        [JsonProperty(PropertyName = "pago_tc")]
        public decimal PagoTc { get; set; }

        [JsonProperty(PropertyName = "supervisor")]
        public string Supervisor { get; set; }

        [JsonProperty(PropertyName = "upload")]
        public bool Upload { get; set; }

        [JsonProperty(PropertyName = "num_registros")]
        public short NumeroRegistros { get; set; }
    }
}