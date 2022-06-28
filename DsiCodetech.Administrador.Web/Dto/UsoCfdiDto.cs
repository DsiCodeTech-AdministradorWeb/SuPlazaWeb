using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text.Json.Serialization;

namespace DsiCodetech.Administrador.Web.Dto
{
    public class UsoCfdiDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }

        [JsonPropertyName("persona_fisica")]
        public string Persona_Fisica { get; set; }

        [JsonPropertyName("persona_moral")]
        public string Persona_Moral { get; set; }

        [JsonPropertyName("regimen_fiscal_receptor")]
        public string Regimen_Fiscal_Receptor { get; set; }

        [JsonPropertyName("fecha_inicio")]
        public string Fecha_Inicio { get; set; }

        [JsonPropertyName("fecha_fin")]
        public string Fecha_Fin { get; set; }
    }
}