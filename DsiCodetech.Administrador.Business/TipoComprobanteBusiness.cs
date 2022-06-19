using DsiCodetech.Administrador.Domain;
using DsiCodetech.Administrador.Repository;
using DsiCodetech.Administrador.Repository.Infraestructure;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business
{
    public class TipoComprobanteBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Tipo_Comprobante_Repository repository;

        public TipoComprobanteBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new Tipo_Comprobante_Repository(unitOfWork);
        }
        /// <summary>
        /// Este metodo se encarga de consultar todos los tipos de comprobantes
        /// </summary>
        /// <returns>una coleccion de tipos de comprobantes</returns>
        public List<TipoComprobanteDM> GetAllTipoComprobante()
        {
            List<TipoComprobanteDM> comprobantes = null;

            comprobantes = repository.GetAll().Select(p => new TipoComprobanteDM
            {
                Id = p.id,
                Descripcion = p.descripcion,
                Fecha_Inicio = p.fecha_inicio == null ? DateTime.Now.ToShortDateString() : p.fecha_inicio.Value.ToShortDateString(),
                Fecha_Fin = p.fecha_fin == null ? DateTime.Now.ToShortDateString() : p.fecha_fin.Value.ToShortDateString(),
                
                
            }).OrderBy(p=>p.Id).ToList();
            return comprobantes;
        }




    }
}
