using DsiCodetech.Administrador.Repository;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business
{
    public class UsoCfdiBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Uso_Cfdi_Repository repository;
        public UsoCfdiBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new Uso_Cfdi_Repository(unitOfWork);
        }


        public List<RegimenFiscalDM> GetAllRegimenFiscal()
        {
            List<RegimenFiscalDM> regimenes = null;

            regimenes = repository.GetAll().Select(p => new RegimenFiscalDM
            {
                Id = p.id,
                Descripcion = p.descripcion,
                Fecha_Inicio = p.fecha_inicio == null ? DateTime.Now.ToShortDateString() : p.fecha_inicio.Value.ToShortDateString(),
                Fecha_Fin = p.fecha_fin == null ? DateTime.Now.ToShortDateString() : p.fecha_fin.Value.ToShortDateString(),
                Persona_Fisica = p.persona_fisica,
                Persona_Moral = p.persona_moral
            }).ToList();
            return regimenes;
        }
    }
}
