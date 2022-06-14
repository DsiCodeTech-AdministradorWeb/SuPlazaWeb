﻿using DsiCodetech.Administrador.Repository.Infraestructure;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Repository
{
    public class Regimen_Fiscal_Repository: BaseRepository<regimen_fiscal>
    {
        public Regimen_Fiscal_Repository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}