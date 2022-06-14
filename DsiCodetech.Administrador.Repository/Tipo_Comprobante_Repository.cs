using DsiCodetech.Administrador.Repository.Infraestructure;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Repository
{
    public class Tipo_Comprobante_Repository: BaseRepository<tipo_comprobante>
    {
        public Tipo_Comprobante_Repository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
