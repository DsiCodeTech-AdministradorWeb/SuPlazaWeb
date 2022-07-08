using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DsiCodetech.Administrador.Domain;

namespace DsiCodetech.Administrador.Business.Interface
{
    public interface IDireccionBusiness
    {
        List<EntidadDM> GetAllEntidades();

        List<MunicipioDM> GetAllMunicipios(short id);
        /// <summary>
        /// Este metodo se encarga de consultar la direccion de un cliente por identificador
        /// </summary>
        /// <param name="id_cliente">el identificador del cliente</param>
        /// <returns>retorna una entidad del tipo direccionDM</returns>
        DireccionDM GetDireccionByClienteId(Guid id_cliente);
    }
}
