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
    public class ExportacionBusiness: IExportacionBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Expotarcion_Repository repository;
        public ExportacionBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new Expotarcion_Repository(unitOfWork);
        }

        /// <summary>
        /// Este metodo se encarga de consultar todas las entidades del tipo exportacion
        /// </summary>
        /// <returns>retorna una coleccion del tipo exportacion</returns>
        public List<ExportacionDM> GetAllExportacion()
        {
            List<ExportacionDM> exportaciones = null;

            exportaciones = repository.GetAll().Select(p => new ExportacionDM
            {
                Id = p.id,
                Descripcion = p.descripcion,
                Fecha_Inicio = p.fecha_inicio == null ? DateTime.Now.ToShortDateString() : p.fecha_inicio.Value.ToShortDateString(),
                Fecha_Fin = p.fecha_fin == null ? DateTime.Now.ToShortDateString() : p.fecha_fin.Value.ToShortDateString(),
               
            }).ToList();
            return exportaciones;
        }

        /// <summary>
        /// Este metodo se encarga de consultar la entidad exportacion  por Identificador
        /// </summary>
        /// <param name="id">identificador</param>
        /// <returns>una entidad que representa la exportacion</returns>
        public ExportacionDM GetExportacionlById(string id)
        {

            var exportacion = repository.SingleOrDefault(p => p.id == id);
            ExportacionDM exportacionModel = new ExportacionDM
            {
                Id = exportacion.id,
                Descripcion = exportacion.descripcion,
                Fecha_Inicio = exportacion.fecha_inicio == null ? DateTime.Now.ToShortDateString() : exportacion.fecha_inicio.Value.ToShortDateString(),
                Fecha_Fin = exportacion.fecha_fin == null ? DateTime.Now.ToShortDateString() : exportacion.fecha_fin.Value.ToShortDateString(),

            };
            return exportacionModel;
        }
    }
}
