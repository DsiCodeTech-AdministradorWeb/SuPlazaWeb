using DsiCodetech.Administrador.Repository.Infraestructure;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Repository
{
    public class Forma_Pago_Repository: BaseRepository<forma_pago>
    {
        public Forma_Pago_Repository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
