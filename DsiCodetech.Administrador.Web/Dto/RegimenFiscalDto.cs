using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text.Json.Serialization;

namespace DsiCodetech.Administrador.Web.Dto
{
    public class RegimenFiscalDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }

        [JsonPropertyName("persona_fisica")]
        public string Persona_Fisica { get; set; }

        [JsonPropertyName("persona_moral")]
        public string Persona_Moral { get; set; }

        [JsonPropertyName("fecha_inicio")]
        public DateTime Fecha_Inicio { get; set; }

        [JsonPropertyName("fecha_fin")]
        public DateTime Fecha_Fin { get; set; }
    }
}