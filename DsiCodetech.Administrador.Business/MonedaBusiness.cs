using DsiCodetech.Administrador.Repository;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business
{
    public class MonedaBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Moneda_Repository repository;
        public MonedaBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new Moneda_Repository(unitOfWork);
        }
    }
}
