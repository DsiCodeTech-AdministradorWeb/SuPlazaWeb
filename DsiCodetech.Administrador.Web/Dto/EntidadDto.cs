using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace DsiCodetech.Administrador.Web.Dto
{
    public class EntidadDto
    {
        [JsonProperty(PropertyName = "id")]
        public short IdEntidad { get; set; }

        [JsonProperty(PropertyName = "nombre")]
        public string Nombre { get; set; }
    }
}