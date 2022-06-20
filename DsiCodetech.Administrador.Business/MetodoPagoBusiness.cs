﻿using DsiCodetech.Administrador.Domain;
using DsiCodetech.Administrador.Repository;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business
{
    public class MetodoPagoBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Metodo_Pago_Repository repository;

        public MetodoPagoBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new Metodo_Pago_Repository(unitOfWork);
        }
        /// <summary>
        /// Este metodo se encarga de consultar todos  metodos de pago
        /// </summary>
        /// <returns>regresa una coleccion de metodos de pago</returns>
        public List<MetodoPagoDM> GetAllMetodoPago()
        {
            List<MetodoPagoDM> metodosPago = null;

            metodosPago = repository.GetAll().Select(p => new MetodoPagoDM
            {
                Id = p.id,
                Descripcion = p.descripcion,
                Fecha_Inicio = p.fecha_inicio == null ? DateTime.Now.ToShortDateString() : p.fecha_inicio.Value.ToShortDateString(),
                Fecha_Fin = p.fecha_fin == null ? DateTime.Now.ToShortDateString() : p.fecha_fin.Value.ToShortDateString(),
                
            }).ToList();
            return metodosPago;
        }
    }
}