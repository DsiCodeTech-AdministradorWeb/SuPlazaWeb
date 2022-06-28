using DsiCodetech.Administrador.Business.Interface;
using DsiCodetech.Administrador.Domain;
using DsiCodetech.Administrador.Repository;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DsiCodetech.Administrador.Business
{
    public class FormaPagoBusiness : IFormaPagoBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Forma_Pago_Repository repository;
        public FormaPagoBusiness(IUnitOfWork _unitOfWork)
        {
            //unidad de trabajo
            unitOfWork = _unitOfWork;
            //entidad de conexion con la base de datos.
            repository = new Forma_Pago_Repository(unitOfWork);
        }
        /// <summary>
        /// este metodo se encarga de consultar todas las formas de pago
        /// </summary>
        /// <returns>regresa una coleccion de todas las formas de pago</returns>
        public List<FormaPagoDM> GetAllFormasDePago()
        {
            List<FormaPagoDM> formasDePago = null;
            ///consulta base de datos  que regresan una lista de entidades del tipo formaPagoDM
            formasDePago = repository.GetAll().Select(p => new FormaPagoDM
            {
                Id = p.id,
                Descripcion = p.descripcion,
                Fecha_Inicio = p.fecha_inicio == null ? DateTime.Now.ToShortDateString() : p.fecha_inicio.Value.ToShortDateString(),
                Fecha_Fin = p.fecha_fin == null ? DateTime.Now.ToShortDateString() : p.fecha_fin.Value.ToShortDateString(),
                Bancarizado = p.bancarizado,
                Cuenta_Beneficiario = p.cuenta_beneficiario,
                Cuenta_Ordenante = p.cuenta_ordenante,
                Num_Operacion =p.num_operacion,
                Rfc_Beneficiario = p.rfc_beneficiario,
                Rfc_Ordenante = p.rfc_ordenante,
                Tipo_Pago = p.tipo_pago
            }).ToList();
            return formasDePago;
        }

    }
}
