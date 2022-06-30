using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using DsiCodetech.Administrador.Domain.Filter.Sort;

namespace DsiCodetech.Administrador.Domain.Filter.Page
{
    public class PageRequest
    {
        [JsonProperty(PropertyName = "page_number")]
        public int pageNumber { get; set; }

        [JsonProperty(PropertyName = "page_size")]
        public int pageSize { get; set; }

        [JsonProperty(PropertyName = "sort")]
        public Sorting sort { get; set; }
    }
}
