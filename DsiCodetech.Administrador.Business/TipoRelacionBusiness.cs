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
    public class TipoRelacionBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Tipo_Relacion_Repository repository;
        public TipoRelacionBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new Tipo_Relacion_Repository(unitOfWork);
        }

        public List<TipoRelacionDM> GetAllRegimenFiscal()
        {
            List<TipoRelacionDM> tipoRelaciones = null;

            tipoRelaciones = repository.GetAll().Select(p => new TipoRelacionDM
            {
                Id = p.id,
                Descripcion = p.descripcion,
                Fecha_Inicio = p.fecha_inicio == null ? DateTime.Now.ToShortDateString() : p.fecha_inicio.Value.ToShortDateString(),
                Fecha_Fin = p.fecha_fin == null ? DateTime.Now.ToShortDateString() : p.fecha_fin.Value.ToShortDateString(),
               
            }).OrderBy(p=>p.Id).ToList();
            return tipoRelaciones;
        }
    }
}
