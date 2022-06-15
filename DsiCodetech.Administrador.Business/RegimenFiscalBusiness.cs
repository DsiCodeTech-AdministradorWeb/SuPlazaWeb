using DsiCodetech.Administrador.Domain;
using DsiCodetech.Administrador.Repository;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business
{
    public class RegimenFiscalBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Regimen_Fiscal_Repository repository;
        public RegimenFiscalBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        /// <summary>
        /// Este metodo se encarga de consultar todos los regimenes fiscales
        /// </summary>
        /// <returns>una lista de regimen fiscal</returns>
        public List<RegimenFiscalDM> GetAllRegimenFiscal() {
            return repository.GetAll().Select(p => new RegimenFiscalDM
            {
                Id = p.id,
                Descripcion = p.descripcion,
                Fecha_Inicio = p.fecha_inicio.Value,
                Fecha_Fin = p.fecha_fin.Value,
                Persona_Fisica = p.persona_fisica,
                Persona_Moral = p.persona_moral
            }).ToList();
        }
    }
}
