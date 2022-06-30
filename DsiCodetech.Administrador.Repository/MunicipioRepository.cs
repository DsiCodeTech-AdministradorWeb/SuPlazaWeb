using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using DsiCodetech.Administrador.Repository.Infraestructure;
using DsiCodetech.Administrador.Repository.PosAdmin;

namespace DsiCodetech.Administrador.Repository
{
    public class MunicipioRepository: BaseRepository<municipio>
    {
        public MunicipioRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
