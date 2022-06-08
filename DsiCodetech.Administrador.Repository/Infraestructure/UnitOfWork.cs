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
        //private readonly IncubadoraDataBaseEntities _dbContext;
        
        public UnitOfWork()
        {
          //  _dbContext = new IncubadoraDataBaseEntities();
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
