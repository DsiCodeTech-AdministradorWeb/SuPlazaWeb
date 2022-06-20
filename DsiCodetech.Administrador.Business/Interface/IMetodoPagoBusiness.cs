using DsiCodetech.Administrador.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business.Interface
{
    public interface IMetodoPagoBusiness
    {
        /// <summary>
        /// Este metodo se encarga de consultar todos  metodos de pago
        /// </summary>
        /// <returns>regresa una coleccion de metodos de pago</returns>
        List<MetodoPagoDM> GetAllMetodoPago();
        /// <summary>
        /// Este metodo se encarga de consultar los metodos de pago por identificador
        /// </summary>
        /// <param name="id">el identificador de la entidad</param>
        /// <returns>la entidad</returns>
        MetodoPagoDM GetMetodoPagoById(string id);
    }
}
