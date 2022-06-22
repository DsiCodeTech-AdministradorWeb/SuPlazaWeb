using DsiCodetech.Administrador.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business.Interface
{
    public interface IMesBusiness
    {
        /// <summary>
        /// /Este metodo se encraga de consultar el mes
        /// </summary>
        /// <returns> Lista de tipo mes </returns>
        List<MesDM> GetMes();
    }
}
