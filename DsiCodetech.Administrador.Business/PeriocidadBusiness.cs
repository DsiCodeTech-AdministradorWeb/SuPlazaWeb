using DsiCodetech.Administrador.Repository;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business
{
    public class PeriocidadBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Periodicidad_Repository repository;
        public PeriocidadBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new Periodicidad_Repository(unitOfWork);
        }
    }
}
