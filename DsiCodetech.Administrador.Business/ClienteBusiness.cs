using DsiCodetech.Administrador.Repository;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business
{
    public class ClienteBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ClienteRepository repository;
        public ClienteBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;

        }
    }
}
