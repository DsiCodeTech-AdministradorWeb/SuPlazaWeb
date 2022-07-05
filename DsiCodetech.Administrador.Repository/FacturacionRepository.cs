using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using LinqKit;

using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using DsiCodetech.Administrador.Repository.Infraestructure;
using DsiCodetech.Administrador.Repository.PosAdmin;

namespace DsiCodetech.Administrador.Repository
{
    public class FacturacionRepository : BaseRepository<factura>, IPagingAndSortingRepository<factura>
    {
        public FacturacionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public int Count(Expression<Func<factura, bool>> whereCondition)
        {
            return dbSet.AsExpandable().Where(whereCondition).Count();
        }

        public IEnumerable<factura> GetPaging(Expression<Func<factura, string>> orderBy, int page_number, int page_size)
        {
            return dbSet.Include("cliente").Include("estatus").OrderBy(orderBy).Skip((page_number - 1) * page_size).Take(page_size).AsEnumerable();
        }

        public IEnumerable<factura> GetPaging(Expression<Func<factura, bool>> where, Expression<Func<factura, string>> orderBy, int page_number, int page_size)
        {
            return dbSet.Include("cliente").Include("estatus").AsExpandable().Where(where).OrderBy(orderBy).Skip((page_number - 1) * page_size).Take(page_size).AsEnumerable();
        }

        public IEnumerable<factura> GetPagingDescending(Expression<Func<factura, string>> orderBy, int page_number, int page_size)
        {
            return dbSet.Include("cliente").Include("estatus").OrderByDescending(orderBy).Skip((page_number - 1) * page_size).Take(page_size).AsEnumerable();
        }

        public IEnumerable<factura> GetPagingDescending(Expression<Func<factura, bool>> where, Expression<Func<factura, string>> orderBy, int page_number, int page_size)
        {
            return dbSet.Include("cliente").Include("estatus").AsExpandable().Where(where).OrderByDescending(orderBy).Skip((page_number - 1) * page_size).Take(page_size).AsEnumerable();
        }
    }
}
