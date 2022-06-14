using DsiCodetech.Administrador.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business.Interface
{
    public interface IPaisBusiness
    {
        /// <summary>
        /// Este metodo se encarga de consultar todos los paises almacenados en la persistencia
        /// </summary>
        /// <returns>una lista de paises</returns>
        List<PaisDM> GetPaises();
    }
}
