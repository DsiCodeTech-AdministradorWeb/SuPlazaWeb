using DsiCodetech.Administrador.Repository.Infraestructure;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Repository
{
    public class Metodo_Pago_Repository : BaseRepository<metodo_pago>
    {
        public Metodo_Pago_Repository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
