using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using DsiCodetech.Administrador.Domain.Filter.Page;

namespace DsiCodetech.Administrador.Domain.Filter.Query
{
    public class ClienteQuery
    {
        [JsonProperty(PropertyName = "rfc")]
        public string Rfc { get; set; }

        [JsonProperty(PropertyName = "razon_social")]
        public string RazonSocial { get; set; }

        [JsonProperty(PropertyName = "regimen_fiscal")]
        public string RegimenFiscal { get; set; }

        public PageRequest page { get; set; }
    }
}
