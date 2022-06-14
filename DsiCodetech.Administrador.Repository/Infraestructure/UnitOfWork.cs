using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Repository.Infraestructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly pos_adminEntities _dbContext;
        
        public UnitOfWork()
        {
           _dbContext = new pos_adminEntities();
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
