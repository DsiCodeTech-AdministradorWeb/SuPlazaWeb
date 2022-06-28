using DsiCodetech.Administrador.Business.Interface;
using DsiCodetech.Administrador.Domain;
using DsiCodetech.Administrador.Repository;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business
{
    public class PaisBusiness: IPaisBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaisRepository repository;
        public PaisBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new PaisRepository(unitOfWork);
        }

        /// <summary>
        /// Este metodo se encarga de consultar todos los paises almacenados en la persistencia
        /// </summary>
        /// <returns>una lista de paises</returns>
        public List<PaisDM> GetPaises() 
        {
            List<PaisDM> paises = null;
            return paises = repository.GetAll().Select(p => new PaisDM
            {
                Id =p.id,
                Agrupacion = p.agrupacion,
                Descripcion =p.descripcion

            }).ToList();
        }

        

    }
}
