using DsiCodetech.Administrador.Domain;
using System.Collections.Generic;

namespace DsiCodetech.Administrador.Business.Interface
{
    public interface IRegimenFiscalBusiness
    {
        /// <summary>
        /// Este metodo se encarga de consultar todos los regimenes fiscales
        /// </summary>
        /// <returns>una lista de regimen fiscal</returns>
        List<RegimenFiscalDM> GetAllRegimenFiscal();
        /// <summary>
        /// Este metodo se encargad e hacer una consulta por Id
        /// </summary>
        /// <param name="id">el identificador de la entidad</param>
        /// <returns>regresa una sola entidad</returns>
        RegimenFiscalDM GetRegimenFiscalById(string id);
    }
}
