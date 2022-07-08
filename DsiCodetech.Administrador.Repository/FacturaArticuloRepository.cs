using DsiCodetech.Administrador.Repository.Infraestructure;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using DsiCodetech.Administrador.Repository.PosAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Repository
{
    public class FacturaArticuloRepository : BaseRepository<factura_articulo>
    {
        public FacturaArticuloRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
