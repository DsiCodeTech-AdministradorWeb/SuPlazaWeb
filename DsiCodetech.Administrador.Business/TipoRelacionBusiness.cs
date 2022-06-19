using DsiCodetech.Administrador.Repository;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business
{
    public class TipoRelacionBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Tipo_Relacion_Repository repository;
        public TipoRelacionBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new Tipo_Relacion_Repository(unitOfWork);
        }
    }
}
