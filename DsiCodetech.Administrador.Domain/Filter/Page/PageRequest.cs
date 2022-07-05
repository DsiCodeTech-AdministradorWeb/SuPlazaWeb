﻿using System;
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

        public PageRequest() { }


        public PageRequest(int PageSize, int PageNumber, string Sort)
        {
            this.pageSize = PageSize;
            this.pageNumber = PageNumber;
            this.sort = new Sorting(Sort.Split(',')[0], Sort.Split(',')[1] == "asc" ? Direction.Ascending : Direction.Descending);
        }
    }
}
