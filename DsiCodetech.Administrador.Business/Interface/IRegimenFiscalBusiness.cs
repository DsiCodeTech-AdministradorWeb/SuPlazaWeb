using DsiCodetech.Administrador.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business.Interface
{
    public interface IRegimenFiscalBusiness
    {
        /// <summary>
        /// Este metodo se encarga de consultar todos los regimenes fiscales
        /// </summary>
        /// <returns>una lista de regimen fiscal</returns>
        List<RegimenFiscalDM> GetAllRegimenFiscal();
    }
}
