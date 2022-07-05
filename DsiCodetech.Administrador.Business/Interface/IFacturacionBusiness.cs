using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DsiCodetech.Administrador.Domain;
using DsiCodetech.Administrador.Domain.Filter.Model;
using DsiCodetech.Administrador.Domain.Filter.Query;
using DsiCodetech.Administrador.Domain.Filter.Page;

namespace DsiCodetech.Administrador.Business.Interface
{
    public interface IFacturacionBusiness
    {
        FacturaDM GetFacturaByIdClient(Guid id);

        PageResponse<FacturaFilterDM> GetFacturaPaging(FacturaQuery query);
    }
}
