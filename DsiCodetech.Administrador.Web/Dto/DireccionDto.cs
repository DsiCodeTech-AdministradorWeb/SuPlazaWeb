using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace DsiCodetech.Administrador.Web.Dto
{
    public class DireccionDto
    {
        [JsonProperty(propertyName: "id_direccion")]
        public System.Guid IdDireccion { get; set; }

        [JsonProperty(propertyName: "id_cliente")]
        public System.Guid IdCliente { get; set; }

        [JsonProperty(propertyName: "id_municipio")]
        public short IdMunicipio { get; set; }

        [JsonProperty(propertyName: "id_entidad")]
        public short IdEntidad { get; set; }

        [JsonProperty(propertyName: "codigo_postal")]
        public string CodigoPostal { get; set; }

        [JsonProperty(propertyName: "colonia")]
        public string Colonia { get; set; }

        [JsonProperty(propertyName: "calle")]
        public string Calle { get; set; }

        [JsonProperty(propertyName: "no_interior")]
        public string NoInterior { get; set; }

        [JsonProperty(propertyName: "no_exterior")]
        public string NoExterior { get; set; }
    }
}