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
    public class TipoRelacionBusiness: ITipoRelacionBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Tipo_Relacion_Repository repository;
        public TipoRelacionBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new Tipo_Relacion_Repository(unitOfWork);
        }

        /// <summary>
        /// Este metodo se encarga de consultar todos los tipos de relaciones como entidad
        /// </summary>
        /// <returns>lista de entidades del tipo tiporelaciondm</returns>
        public List<TipoRelacionDM> GetAllTipoRelaciones()
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

        /// <summary>
        /// este metodo se encarga de consultar  el tipo de relacion por identificador
        /// </summary>
        /// <param name="id">el identificador</param>
        /// <returns>retorna una entidad del tipo tiporelacionDM</returns>
        public TipoRelacionDM GetTipoRelacionById(string id)
        {

            var relacion = repository.SingleOrDefault(p => p.id == id);
            TipoRelacionDM relacionModel = new TipoRelacionDM
            {
                Id = relacion.id,
                Descripcion = relacion.descripcion,
                Fecha_Inicio = relacion.fecha_inicio.Value.ToShortDateString(),
                Fecha_Fin = relacion.fecha_fin.Value.ToShortDateString(),
              
            };
            return relacionModel;
        }


    }
}
