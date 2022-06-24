using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DsiCodetech.Administrador.Web.Dto
{
    public class ClientesDto
    {
        public Guid IdCliente { get; set; }
        public string Rfc { get; set; }
        public string RazonSocial { get; set; }
        public string RegimenFiscal { get; set; }
    }
}