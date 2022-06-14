using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Domain
{
    public class ClaveProductoServicioDM
    {
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public string Trasladado { get; set; }
        public string Ieps_trasladado { get; set; }
        public short Franja_fronteriza { get; set; }
        public string Palabras_similares { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_fin { get; set; }
    }
}
