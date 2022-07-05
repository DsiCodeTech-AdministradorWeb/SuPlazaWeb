using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace DsiCodetech.Administrador.Web.Dto
{
    public class EmpresaDto
    {
        [JsonProperty(propertyName: "rfc")]
        public string Rfc { get; set; }

        [JsonProperty(propertyName: "razon_social")]
        public string RazonSocial { get; set; }

        [JsonProperty(propertyName: "regimen_fiscal")]
        public string Representante { get; set; }
    }
}