using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

using DsiCodetech.Administrador.Domain.Filter.Page;

namespace DsiCodetech.Administrador.Domain.Filter.Query
{
    public class ClienteQuery
    {
        [JsonPropertyName("rfc")]
        public string Rfc { get; set; }

        [JsonPropertyName("razon_social")]
        public string RazonSocial { get; set; }

        [JsonPropertyName("regimen_fiscal")]
        public string RegimenFiscal { get; set; }

        [JsonPropertyName("id_entidad")]
        public string IdEntidad { get; set; }

        [JsonPropertyName("id_municipio")]
        public string IdMunicipio { get; set; }

        public PageRequest page { get; set; }
    }
}
