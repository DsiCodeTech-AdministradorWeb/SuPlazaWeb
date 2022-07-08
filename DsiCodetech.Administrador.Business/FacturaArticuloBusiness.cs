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
    public  class FacturaArticuloBusiness: IFacturaArticuloBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly FacturaArticuloRepository repository;
        public FacturaArticuloBusiness(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            this.repository = new(unitOfWork);
        }

        /// <summary>
        /// Este metodo se encarga de consultar todas las entidades del tipo factura_articulo  correspondiente a una factura
        /// </summary>
        /// <param name="idFactura">el identificador de la factura</param>
        /// <returns>la lista de las entidades facturaDM</returns>
        public List<FacturaArticuloDM> GetFacturaArticuloByIdFactura(string idFactura)
        {
            List<FacturaArticuloDM> facturaArticulos = repository.
                GetAll(p => p.id_factura.Equals(idFactura)).
                Select(p => new FacturaArticuloDM
                {
                    IdFacturaArticulo = p.id_factura_articulo,
                    IdFactura =p.id_factura.ToString(),
                    CodigoBarras = p.cod_barras,
                    Descripcion =p.descripcion,
                    IdUnidad = p.id_unidad,
                    Cantidad = (double)p.cantidad,
                    Iva =(double)p.iva,
                    PrecioVenta =(double)p.precio_vta

                }).ToList();
            return facturaArticulos;
        }
    }
}
