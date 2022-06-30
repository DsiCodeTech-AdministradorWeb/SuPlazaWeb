using DsiCodetech.Administrador.Repository.Infraestructure;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using DsiCodetech.Administrador.Repository.PosAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DsiCodetech.Administrador.Repository
{
    public class ClienteRepository : BaseRepository<cliente>, IPagingAndSortingRepository<cliente>
    {
        public ClienteRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<cliente> GetPaging(Expression<Func<cliente, string>> orderBy, int page_number, int page_size)
        {
            return dbSet.OrderBy(orderBy).Skip((page_number - 1) * page_size).Take(page_size).AsEnumerable();
        }

        public IEnumerable<cliente> GetPaging(Expression<Func<cliente, bool>> where, Expression<Func<cliente, string>> orderBy, int page_number, int page_size)
        {
            return dbSet.Where(where).OrderBy(orderBy).Skip((page_number - 1) * page_size).Take(page_size).AsEnumerable();
        }

        public IEnumerable<cliente> GetPagingDescending(Expression<Func<cliente, string>> orderBy, int page_number, int page_size)
        {
            return dbSet.OrderByDescending(orderBy).Skip((page_number - 1) * page_size).Take(page_size).AsEnumerable();
        }

        public IEnumerable<cliente> GetPagingDescending(Expression<Func<cliente, bool>> where, Expression<Func<cliente, string>> orderBy, int page_number, int page_size)
        {
            return dbSet.Where(where).OrderByDescending(orderBy).Skip((page_number - 1) * page_size).Take(page_size).AsEnumerable();
        }
    }
}
