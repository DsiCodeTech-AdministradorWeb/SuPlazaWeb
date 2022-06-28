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
    public class PaisRepository: BaseRepository<pais>
    {
        public PaisRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
