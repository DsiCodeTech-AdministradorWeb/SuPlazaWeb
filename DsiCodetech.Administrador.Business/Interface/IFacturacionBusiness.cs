using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DsiCodetech.Administrador.Domain;
using DsiCodetech.Administrador.Domain.Filter.Model;
using DsiCodetech.Administrador.Domain.Filter.Query;
using DsiCodetech.Administrador.Domain.Filter.Page;

namespace DsiCodetech.Administrador.Business.Interface
{
    public interface IFacturacionBusiness
    {
        FacturaDM GetFacturaByIdClient(Guid id);

        PageResponse<FacturaFilterDM> GetFacturaPaging(FacturaQuery query);
        
        
        /// <summary>
        /// Este metodo se encarga de consultar una factura por el identificador de venta
        /// </summary>
        /// <param name="id_venta">el identificador de la venta</param>
        /// <returns>una entidad del tipo FacturaDM</returns>
        FacturaDM getFacturaByIdFactura(int id_factura);
    }
}
