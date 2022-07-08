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
        private readonly DireccionRepository direccionRepository;
        public DireccionBusiness(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.entidadRepository = new(unitOfWork);
            this.municipioRepository = new(unitOfWork);
            this.direccionRepository = new(unitOfWork);
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

        /// <summary>
        /// Este metodo se encarga de consultar la direccion de un cliente por identificador
        /// </summary>
        /// <param name="id_cliente">el identificador del cliente</param>
        /// <returns>retorna una entidad del tipo direccionDM</returns>
        public DireccionDM GetDireccionByClienteId(Guid id_cliente)
        {
            var direccion= this.direccionRepository.SingleOrDefault(p => p.id_cliente == id_cliente);
            return new DireccionDM{ 
              Calle = direccion.calle,
              CodigoPostal= direccion.codigo_postal,
              Colonia = direccion.colonia,
              IdCliente = direccion.id_cliente,
              IdDireccion = direccion.id_direccion,
              IdEntidad= direccion.id_entidad,
              IdMunicipio= direccion.id_municipio,
              MunicipioDM =new MunicipioDM { 
                  IdEntidad = direccion.id_entidad, 
                  IdMunicipio = direccion.id_municipio,
                  Nombre = direccion.municipio.nombre
              },
              EntidadDM = new EntidadDM { 
                  IdEntidad= direccion.id_entidad,
                  Nombre= direccion.entidad.nombre
              },
              NoExterior=direccion.no_exterior,
              NoInterior=direccion.no_interior
              
            };
        }



    }
}
