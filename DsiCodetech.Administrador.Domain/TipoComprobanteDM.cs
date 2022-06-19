using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Domain
{
    public class TipoComprobanteDM
    {
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public string Decimales { get; set; }
        public string Porcentaje { get; set; }
        public string Fecha_Inicio { get; set; }
        public string Fecha_Fin { get; set; }
    }
}
