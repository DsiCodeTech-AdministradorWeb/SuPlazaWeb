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
    public class ClaveProductoServiciosBusiness: IClaveProductoServiciosBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Clave_Producto_Serv_Repository repository;
        public ClaveProductoServiciosBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new Clave_Producto_Serv_Repository(unitOfWork);
        }

        /// <summary>
        /// este metodo se encarga de consultar todas las claves de productosservicioDM
        /// </summary>
        /// <returns>una coleccion de clavesProductoServicio</returns>
        public List<ClaveProductoServicioDM> GetAllClaveProductoServicio()
        {
            List<ClaveProductoServicioDM> clavesProductoModel = null;

            clavesProductoModel = repository.GetAll().Select(p => new ClaveProductoServicioDM
            {
                Id = p.id,
                Descripcion = p.descripcion,
                Ieps_trasladado = p.ieps_trasladado,
                Franja_fronteriza = p.franja_fronteriza,
                Palabras_similares = p.palabras_similares,
                Fecha_inicio  = p.fecha_inicio == null ? DateTime.Now.ToShortDateString() : p.fecha_inicio.Value.ToShortDateString(),
                Fecha_fin = p.fecha_fin == null ? DateTime.Now.ToShortDateString() : p.fecha_fin.Value.ToShortDateString(),
                Trasladado =p.trasladado,

            }).OrderBy(p=>p.Id).ToList();
            return clavesProductoModel;
        }


    }
}
