using DsiCodetech.Administrador.Repository.Infraestructure;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Repository
{
    public class Mes_Repository: BaseRepository<mes>
    {
        public Mes_Repository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
