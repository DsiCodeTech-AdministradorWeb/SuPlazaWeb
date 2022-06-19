using DsiCodetech.Administrador.Domain;
using System.Collections.Generic;

namespace DsiCodetech.Administrador.Business.Interface
{
    public interface ITipoComprobanteBusiness
    {
        /// <summary>
        /// Este metodo se encarga de consultar todos los tipos de comprobantes
        /// </summary>
        /// <returns>una coleccion de tipos de comprobantes</returns>
        List<TipoComprobanteDM> GetAllTipoComprobante();
        /// <summary>
        /// Este metodo se encarga de consultar por identificador un tipo de comprobante
        /// </summary>
        /// <param name="id">el identificador del comprobante</param>
        /// <returns>la entidad  tipocomprobante</returns>
        TipoComprobanteDM GetTipoComprobanteById(string id);
    }
}
