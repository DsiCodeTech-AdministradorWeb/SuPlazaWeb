using DsiCodetech.Administrador.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business.Interface
{
    public interface ITipoRelacionBusiness
    {
        /// <summary>
        /// Este metodo se encarga de consultar todos los tipos de relaciones como entidad
        /// </summary>
        /// <returns>lista de entidades del tipo tiporelaciondm</returns>
        List<TipoRelacionDM> GetAllTipoRelaciones();

        /// <summary>
        /// este metodo se encarga de consultar  el tipo de relacion por identificador
        /// </summary>
        /// <param name="id">el identificador</param>
        /// <returns>retorna una entidad del tipo tiporelacionDM</returns>
        TipoRelacionDM GetTipoRelacionById(string id);
    }
}
