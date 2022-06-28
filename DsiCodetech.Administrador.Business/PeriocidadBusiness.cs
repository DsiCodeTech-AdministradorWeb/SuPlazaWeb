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
    public class PeriocidadBusiness: IPeriocidadBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PeriodicidadRepository repository;
        public PeriocidadBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new PeriodicidadRepository(unitOfWork);
        }

        /// <summary>
        /// Este metodo se encarga de consultar todas las periocidades
        /// </summary>
        /// <returns>una coleccion de periocidadesDM</returns>
        public List<PeriocidadDM> GetAllPeriocidades()
        {
            List<PeriocidadDM> periocidadModel = null;

            periocidadModel = repository.GetAll().Select(p => new PeriocidadDM
            {
                Id = p.id,
                Descripcion = p.descripcion,
                Fecha_Inicio = p.fecha_inicio == null ? DateTime.Now.ToShortDateString() : p.fecha_inicio.Value.ToShortDateString(),
                Fecha_Fin = p.fecha_fin == null ? DateTime.Now.ToShortDateString() : p.fecha_fin.Value.ToShortDateString(),
               
            }).OrderBy(p=>p.Id).ToList();
            return periocidadModel;
        }
    }
}
