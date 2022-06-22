using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DsiCodetech.Administrador.Web.Dto
{
    public class FormaPagoDto
    {
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public string Bancarizado { get; set; }
        public string Num_Operacion { get; set; }
        public string Rfc_Ordenante { get; set; }
        public string Cuenta_Ordenante { get; set; }
        public string Rfc_Beneficiario { get; set; }
        public string Cuenta_Beneficiario { get; set; }
        public string Tipo_Pago { get; set; }
        public string Fecha_Inicio { get; set; }
        public string Fecha_Fin { get; set; }
    }
}