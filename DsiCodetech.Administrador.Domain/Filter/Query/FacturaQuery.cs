using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using DsiCodetech.Administrador.Domain.Filter.Page;

namespace DsiCodetech.Administrador.Domain.Filter.Query
{
    public class FacturaQuery
    {
        public string Rfc { get; set; }

        public string RazonSocial { get; set; }

        public string UsoCfdi { get; set; }

        public string FormaPago { get; set; }

        public string MetodoPago { get; set; }

        public PageRequest page { get; set; }
    }
}
