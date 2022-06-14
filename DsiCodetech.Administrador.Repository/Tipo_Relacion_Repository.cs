using DsiCodetech.Administrador.Repository.Infraestructure;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Repository
{
    public class Tipo_Relacion_Repository: BaseRepository<tipo_relacion>
    {
        public Tipo_Relacion_Repository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
