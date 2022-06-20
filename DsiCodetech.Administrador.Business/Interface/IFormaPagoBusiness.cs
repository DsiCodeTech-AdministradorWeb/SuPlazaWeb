using DsiCodetech.Administrador.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business.Interface
{
    public interface IFormaPagoBusiness
    {
        /// <summary>
        /// este metodo se encarga de consultar todas las formas de pago
        /// </summary>
        /// <returns>regresa una coleccion de todas las formas de pago</returns>
        List<FormaPagoDM> GetAllFormasDePago();
    }
}
