using DsiCodetech.Administrador.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business.Interface
{
    public interface IMonedaBusiness
    {
        /// <summary>
        /// Este metodo se encarga de consultar las monedas
        /// </summary>
        /// <returns>una coleccion de monedas domain model</returns>
        List<MonedaDM> GetMonedas();
    }
}
