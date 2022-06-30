using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace DsiCodetech.Administrador.Web.Dto
{
    public class MunicipioDto
    {
        [JsonProperty(propertyName: "id_entidad")]
        public short IdEntidad { get; set; }

        [JsonProperty(propertyName: "id")]
        public short IdMunicipio { get; set; }

        [JsonProperty(propertyName: "nombre")]
        public string Nombre { get; set; }
    }
}