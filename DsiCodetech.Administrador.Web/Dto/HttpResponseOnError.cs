using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace DsiCodetech.Administrador.Web.Dto
{
    public class HttpResponseOnError
    {
        [JsonProperty(propertyName: "id")]
        public string Id { get; set; }

        [JsonProperty(propertyName: "message")]
        public string Description { get; set; }
    }
}