using DsiCodetech.Administrador.Business.Interface;
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
    public class RegimenFiscalBusiness : IRegimenFiscalBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Regimen_Fiscal_Repository repository;
        public RegimenFiscalBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new Regimen_Fiscal_Repository(unitOfWork);
        }
        /// <summary>
        /// Este metodo se encarga de consultar todos los regimenes fiscales
        /// </summary>
        /// <returns>una lista de regimen fiscal</returns>
        public List<RegimenFiscalDM> GetAllRegimenFiscal() {
            List<RegimenFiscalDM> regimenes = null;

            regimenes= repository.GetAll().Select(p => new RegimenFiscalDM
            {
                Id = p.id,
                Descripcion = p.descripcion,
                Fecha_Inicio = p.fecha_inicio ==null ?  DateTime.Now.ToShortDateString(): p.fecha_inicio.Value.ToShortDateString(),
                Fecha_Fin = p.fecha_fin ==null ? DateTime.Now.ToShortDateString() : p.fecha_fin.Value.ToShortDateString(),
                Persona_Fisica = p.persona_fisica,
                Persona_Moral = p.persona_moral
            }).ToList();
            return regimenes;
        }

        /// <summary>
        /// Este metodo se encargad e hacer una consulta por Id
        /// </summary>
        /// <param name="id">el identificador de la entidad</param>
        /// <returns>regresa una sola entidad</returns>
        public RegimenFiscalDM GetRegimenFiscalById(string id) {

            var regimen= repository.SingleOrDefault(p => p.id == id);
            RegimenFiscalDM regimenFiscal = new RegimenFiscalDM { 
                Id=regimen.id,
                Descripcion = regimen.descripcion,
                Fecha_Inicio = regimen.fecha_inicio.Value.ToShortDateString(),
                Fecha_Fin = regimen.fecha_fin.Value.ToShortDateString(),
                Persona_Fisica = regimen.persona_fisica,
                Persona_Moral = regimen.persona_moral
            };
            return regimenFiscal;
        }

    }
}
