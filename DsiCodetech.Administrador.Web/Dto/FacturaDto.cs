using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

using DSICodeTech.FacturacionElectronica40.Model;

namespace DsiCodetech.Administrador.Web.Dto
{
    public class FacturaDto
    {
        [JsonProperty(propertyName: "id")]
        public string Id { get; set; }

        [JsonProperty(propertyName: "metodo_pago")]
        public string MetodoPago { get; set; }

        [JsonProperty(propertyName: "forma_pago")]
        public string FormaPago { get; set; }

        [JsonProperty(propertyName: "uso_cfdi")]
        public string UsoCfdi { get; set; }

        [JsonProperty(propertyName: "tipo_comprobante")]
        public string TipoComprobante { get; set; }

        [JsonProperty(propertyName: "exportacion")]
        public string Exportacion { get; set; }

        [JsonProperty(propertyName: "emisor")]
        public EmpresaDto Emisor { get; set; }

        [JsonProperty(propertyName: "receptor")]
        public ClienteDto Receptor { get; set; }

        [JsonProperty(propertyName: "info_global")]
        public ComprobanteInformacionGlobal ComprobanteInformacionGlobal { get; set; }

        [JsonProperty(propertyName: "cfdi_relacionados")]
        public ComprobanteCfdiRelacionados ComprobanteCfdiRelacionados { get; set; }

        [JsonProperty(propertyName: "impuestos")]
        public ComprobanteImpuestos ComprobanteImpuestos { get; set; }

        [JsonProperty(propertyName: "conceptos")]
        public ConceptoDto Conceptos { get; set; }
    }

    public class ConceptoDto {

        [JsonProperty(propertyName: "ticket")]
        public string Ticket { get; set; }

        [JsonProperty(propertyName: "id_pos")]
        public int IdPos { get; set; }

        [JsonProperty(propertyName: "impuestos")]
        public ComprobanteConceptoImpuestos Impuestos { get; set; }
    }
}