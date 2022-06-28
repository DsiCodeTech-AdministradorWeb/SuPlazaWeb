using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DsiCodetech.Administrador.Repository.PosAdmin;

namespace DsiCodetech.Administrador.Repository.Infraestructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dc_PosAdminEntities _dbContext;
        
        public UnitOfWork()
        {
           _dbContext = new Dc_PosAdminEntities();
        }

        public DbContext Db
        {
            get { return _dbContext; }
        }

        public void Dispose()
        {
        }
    }
}
