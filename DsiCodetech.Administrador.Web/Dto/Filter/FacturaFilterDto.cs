using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace DsiCodetech.Administrador.Web.Dto.Filter
{
    public class FacturaFilterDto
    {
        [JsonProperty(propertyName: "id")]
        public string Id { get; set; }

        [JsonProperty(propertyName: "rfc")]
        public string Rfc { get; set; }

        [JsonProperty(propertyName: "razon_social")]
        public string RazonSocial { get; set; }

        [JsonProperty(propertyName: "uuid")]
        public string Uuid { get; set; }

        [JsonProperty(propertyName: "status")]
        public string Status { get; set; }

        [JsonProperty(propertyName: "metodo_pago")]
        public string MetodoPago { get; set; }

        [JsonProperty(propertyName: "forma_pago")]
        public string FormaPago { get; set; }

        [JsonProperty(propertyName: "uso_cfdi")]
        public string UsoCfdi { get; set; }

        [JsonProperty(propertyName: "fecha_remision")]
        public DateTime FechaRemision { get; set; }
    }
}