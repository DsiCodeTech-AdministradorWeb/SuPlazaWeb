using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Domain
{
    public class DireccionDM
    {
        public System.Guid IdDireccion { get; set; }
        public System.Guid IdCliente { get; set; }
        public short IdMunicipio { get; set; }
        public short IdEntidad { get; set; }
        public string CodigoPostal { get; set; }
        public string Colonia { get; set; }
        public string Calle { get; set; }
        public string NoInterior { get; set; }
        public string NoExterior { get; set; }
    }
}
