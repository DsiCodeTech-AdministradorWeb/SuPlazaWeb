using DsiCodetech.Administrador.Repository;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business
{
    public class UsoCfdiBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Uso_Cfdi_Repository repository;
        public UsoCfdiBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new Uso_Cfdi_Repository(unitOfWork);
        }



    }
}
