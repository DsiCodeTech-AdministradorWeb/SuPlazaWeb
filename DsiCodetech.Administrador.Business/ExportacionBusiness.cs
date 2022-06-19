using DsiCodetech.Administrador.Repository;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business
{
    public class ExportacionBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Expotarcion_Repository repository;
        public ExportacionBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new Expotarcion_Repository(unitOfWork);
        }



    }
}
