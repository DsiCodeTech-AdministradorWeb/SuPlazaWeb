using DsiCodetech.Administrador.Repository.Infraestructure;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Repository
{
    public class Clave_Producto_Serv_Repository: BaseRepository<clave_producto_serv>
    {
        public Clave_Producto_Serv_Repository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
