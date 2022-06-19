using DsiCodetech.Administrador.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business.Interface
{
    public interface IExportacionBusiness
    {
        /// <summary>
        /// Este metodo se encarga de consultar todas las entidades del tipo exportacion
        /// </summary>
        /// <returns>retorna una coleccion del tipo exportacion</returns>
        List<ExportacionDM> GetAllExportacion();

        /// <summary>
        /// Este metodo se encarga de consultar la entidad exportacion  por Identificador
        /// </summary>
        /// <param name="id">identificador</param>
        /// <returns>una entidad que representa la exportacion</returns>
        ExportacionDM GetExportacionlById(string id);
    }
}
