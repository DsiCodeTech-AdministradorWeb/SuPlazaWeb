using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text.Json.Serialization;

namespace DsiCodetech.Administrador.Web.Dto
{
    public class FormaPagoDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }

        [JsonPropertyName("bancarizado")]
        public string Bancarizado { get; set; }

        [JsonPropertyName("num_operacion")]
        public string Num_Operacion { get; set; }

        [JsonPropertyName("rfc_ordentante")]
        public string Rfc_Ordenante { get; set; }

        [JsonPropertyName("cuenta_ordenante")]
        public string Cuenta_Ordenante { get; set; }

        [JsonPropertyName("rfc_beneficiario")]
        public string Rfc_Beneficiario { get; set; }

        [JsonPropertyName("cuenta_beneficiario")]
        public string Cuenta_Beneficiario { get; set; }

        [JsonPropertyName("tipo_pago")]
        public string Tipo_Pago { get; set; }

        [JsonPropertyName("fecha_inicio")]
        public string Fecha_Inicio { get; set; }

        [JsonPropertyName("fecha_fin")]
        public string Fecha_Fin { get; set; }
    }
}