using DsiCodetech.Administrador.Repository.Infraestructure;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Repository
{
    public class Uso_Cfdi_Repository: BaseRepository<uso_cfdi>
    {
        public Uso_Cfdi_Repository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
