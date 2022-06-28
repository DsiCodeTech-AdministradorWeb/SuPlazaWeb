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
    public class UsoCfdiBusiness: IUsoCfdiBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UsoCfdiRepository repository;
        public UsoCfdiBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new UsoCfdiRepository(unitOfWork);
        }

        /// <summary>
        /// Este metodo se encarga de consultar todos los UsoCfdi en la base de datos
        /// </summary>
        /// <returns>una coleccion de UsoCfdi</returns>
        public List<UsoCfdiDM> GetAllUsoCfdi()
        {
            List<UsoCfdiDM> UsoCfdimodel = null;

            UsoCfdimodel = repository.GetAll().Select(p => new UsoCfdiDM
            {
                Id = p.id,
                Descripcion = p.descripcion,
                Fecha_Inicio = p.fecha_inicio == null ? DateTime.Now.ToShortDateString() : p.fecha_inicio.Value.ToShortDateString(),
                Fecha_Fin = p.fecha_fin == null ? DateTime.Now.ToShortDateString() : p.fecha_fin.Value.ToShortDateString(),
                Persona_Fisica = p.persona_fisica,
                Persona_Moral = p.persona_moral,
                Regimen_Fiscal_Receptor =p.regimen_fiscal_receptor
            }).OrderBy(p=>p.Id).ToList();
            return UsoCfdimodel;
        }
    }
}
