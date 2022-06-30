using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using DsiCodetech.Administrador.Repository;
using DsiCodetech.Administrador.Business.Interface;
using DsiCodetech.Administrador.Domain;

namespace DsiCodetech.Administrador.Business
{
    public class DireccionBusiness : IDireccionBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly EntidadRepository entidadRepository;
        private readonly MunicipioRepository municipioRepository;

        public DireccionBusiness(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.entidadRepository = new(unitOfWork);
            this.municipioRepository = new(unitOfWork);
        }

        public List<EntidadDM> GetAllEntidades()
        {
            return this.entidadRepository.GetAll().Select(e => new EntidadDM
            {
                IdEntidad = e.id_entidad,
                Nombre = e.nombre
            }).ToList();
        }

        public List<MunicipioDM> GetAllMunicipios(short id)
        {
            return this.municipioRepository.GetAll(m => m.id_entidad.Equals(id)).Select(m => new MunicipioDM
            {
                IdEntidad = m.id_entidad,
                IdMunicipio = m.id_municipio,
                Nombre = m.nombre
            }).ToList();
        }
    }
}
