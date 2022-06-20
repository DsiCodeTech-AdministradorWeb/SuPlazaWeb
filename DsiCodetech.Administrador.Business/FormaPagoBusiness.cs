using DsiCodetech.Administrador.Repository;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business
{
    public class FormaPagoBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Forma_Pago_Repository repository;
        public FormaPagoBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new Forma_Pago_Repository(unitOfWork);
        }

    }
}
