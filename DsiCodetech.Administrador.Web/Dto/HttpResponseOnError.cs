using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text.Json.Serialization;

namespace DsiCodetech.Administrador.Web.Dto
{
    public class HttpResponseOnError
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("message")]
        public string Description { get; set; }
    }
}