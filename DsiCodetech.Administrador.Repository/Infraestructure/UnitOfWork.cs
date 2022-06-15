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
        private readonly Db_cfdi_facturas_entidades _dbContext;
        
        public UnitOfWork()
        {
           _dbContext = new Db_cfdi_facturas_entidades();
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
