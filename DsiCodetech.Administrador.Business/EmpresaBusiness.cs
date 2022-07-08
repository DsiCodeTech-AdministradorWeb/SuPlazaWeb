using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DsiCodetech.Administrador.Business.Interface;

using DsiCodetech.Administrador.Repository;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;

using DsiCodetech.Administrador.Domain;
using DsiCodetech.Administrador.Domain.Exception;

namespace DsiCodetech.Administrador.Business
{
    public class EmpresaBusiness : IEmpresaBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly EmpresaRepository empresaRepository;

        public EmpresaBusiness(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            this.empresaRepository = new(this.unitOfWork);
        }

        public EmpresaDM GetEmpresa()
        {
            var item = this.empresaRepository.GetAll().SingleOrDefault();

            if (item is null)
                throw new BusinessException("No se encuentra una empresa registrada.");

            return new EmpresaDM
            {
                Rfc = item.rfc,
                RazonSocial = item.razon_social,
                Representante = item.representante,
                CodigoPostal = item.codigo_postal
            };
        }
    }
}
