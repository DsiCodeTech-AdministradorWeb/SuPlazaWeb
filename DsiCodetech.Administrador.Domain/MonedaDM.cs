using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Domain
{
    public class MonedaDM
    {
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public string Decimales { get; set; }
        public string Porcentaje { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
    }
}
