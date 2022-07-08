using DsiCodetech.Administrador.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business.Interface
{
    public interface IFacturaArticuloBusiness
    {
        /// <summary>
        /// Este metodo se encarga de consultar todas las entidades del tipo factura_articulo  correspondiente a una factura
        /// </summary>
        /// <param name="idFactura">el identificador de la factura</param>
        /// <returns>la lista de las entidades facturaDM</returns>
        List<FacturaArticuloDM> GetFacturaArticuloByIdFactura(string idFactura);
    }
}
