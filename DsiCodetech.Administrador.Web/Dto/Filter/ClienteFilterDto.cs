using System;



using Newtonsoft.Json;

namespace DsiCodetech.Administrador.Web.Dto.Filter
{
    public class ClienteFilterDto
    {
        [JsonProperty(propertyName: "id")]
        public Guid IdCliente { get; set; }

        [JsonProperty(propertyName: "rfc")]
        public string Rfc { get; set; }

        [JsonProperty(propertyName: "razon_social")]
        public string RazonSocial { get; set; }

        [JsonProperty(propertyName: "regimen_fiscal")]
        public string RegimenFiscal { get; set; }

        [JsonProperty(propertyName: "contacto")]
        public string Contacto { get; set; }

        [JsonProperty(propertyName: "e_mail")]
        public string Email { get; set; }

        [JsonProperty(propertyName: "e_mail2")]
        public string Email2 { get; set; }
    }
}