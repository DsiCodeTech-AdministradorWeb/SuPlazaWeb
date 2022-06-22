using DsiCodetech.Administrador.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business.Interface
{
    public interface IUsoCfdiBusiness
    {
        /// <summary>
        /// Este metodo se encarga de consultar todos los UsoCfdi en la base de datos
        /// </summary>
        /// <returns>una coleccion de UsoCfdi</returns>
        List<UsoCfdiDM> GetAllUsoCfdi();
    }
}
