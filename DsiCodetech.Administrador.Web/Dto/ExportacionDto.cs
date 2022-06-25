using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text.Json.Serialization;

namespace DsiCodetech.Administrador.Web.Dto
{
    public class ExportacionDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }

        [JsonPropertyName("fecha_inicio")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Fecha_Inicio { get; set; }

        [JsonPropertyName("fecha_fin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Fecha_Fin { get; set; }
    }
}