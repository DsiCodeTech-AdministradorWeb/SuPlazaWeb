using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DsiCodetech.Administrador.Repository.Infraestructure.Contract
{
    public interface IPagingAndSortingRepository<T>
    {
        IEnumerable<T> GetPaging(Expression<Func<T, string>> orderBy, int page_number, int page_size);

        IEnumerable<T> GetPaging(Expression<Func<T, bool>> where, Expression<Func<T, string>> orderBy, int page_number, int page_size);

        IEnumerable<T> GetPagingDescending(Expression<Func<T, string>> orderBy, int page_number, int page_size);

        IEnumerable<T> GetPagingDescending(Expression<Func<T, bool>> where, Expression<Func<T, string>> orderBy, int page_number, int page_size);

    }
}
