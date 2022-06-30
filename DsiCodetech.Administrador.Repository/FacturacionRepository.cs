using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using DsiCodetech.Administrador.Repository.Infraestructure;
using DsiCodetech.Administrador.Repository.PosAdmin;
using System.Linq.Expressions;

namespace DsiCodetech.Administrador.Repository
{
    public class FacturacionRepository : BaseRepository<factura>, IPagingAndSortingRepository<factura>
    {
        public FacturacionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<factura> GetPaging(Expression<Func<factura, string>> orderBy, int page_number, int page_size)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<factura> GetPaging(Expression<Func<factura, bool>> where, Expression<Func<factura, string>> orderBy, int page_number, int page_size)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<factura> GetPagingDescending(Expression<Func<factura, string>> orderBy, int page_number, int page_size)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<factura> GetPagingDescending(Expression<Func<factura, bool>> where, Expression<Func<factura, string>> orderBy, int page_number, int page_size)
        {
            return null;
        }
    }
}
