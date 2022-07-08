using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DsiCodetech.Administrador.Domain;


namespace DsiCodetech.Administrador.Business.Interface
{
    public interface IVentaBusiness
    {
       /// <summary>
       /// 
       /// </summary>
       /// <param name="folio"></param>
       /// <param name="id_pos"></param>
       /// <returns></returns>
        VentaDM GetVentaIfNotExistInvoice(long folio, int id_pos);
    }
}
