using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Domain
{
    public class RegimenFiscalDM
    {
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public string Persona_Fisica { get; set; }
        public string Persona_Moral { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
    }
}
