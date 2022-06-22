using DsiCodetech.Administrador.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business.Interface
{
    public interface IPeriocidadBusiness
    {
        /// <summary>
        /// Este metodo se encarga de consultar todas las periocidades
        /// </summary>
        /// <returns>una coleccion de periocidadesDM</returns>
        List<PeriocidadDM> GetAllPeriocidades();
    }
}
