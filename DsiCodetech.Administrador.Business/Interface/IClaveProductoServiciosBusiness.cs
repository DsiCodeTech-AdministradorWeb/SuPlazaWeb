using DsiCodetech.Administrador.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business.Interface
{
    public interface IClaveProductoServiciosBusiness
    {
        /// <summary>
        /// este metodo se encarga de consultar todas las claves de productosservicioDM
        /// </summary>
        /// <returns>una coleccion de clavesProductoServicio</returns>
        List<ClaveProductoServicioDM> GetAllClaveProductoServicio();
    }
}
