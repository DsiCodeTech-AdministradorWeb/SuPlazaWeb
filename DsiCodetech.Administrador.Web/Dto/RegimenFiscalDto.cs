using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DsiCodetech.Administrador.Web.Dto
{
    public class RegimenFiscalDto
    {
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public string Persona_Fisica { get; set; }
        public string Persona_Moral { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
    }
}