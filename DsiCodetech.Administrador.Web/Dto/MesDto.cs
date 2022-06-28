using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text.Json.Serialization;

namespace DsiCodetech.Administrador.Web.Dto
{
    public class MesDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }

        [JsonPropertyName("fecha_inicio")]
        public string Fecha_Inicio { get; set; }

        [JsonPropertyName("fecha_fin")]
        public string Fecha_Fin { get; set; }
    }
}