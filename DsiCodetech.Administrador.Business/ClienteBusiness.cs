using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using DsiCodetech.Administrador.Business.Interface;

using DsiCodetech.Administrador.Domain;
using DsiCodetech.Administrador.Domain.Filter.Query;
using DsiCodetech.Administrador.Domain.Filter.Page;
using DsiCodetech.Administrador.Domain.Extensions;
using DsiCodetech.Administrador.Domain.Exception;

using DsiCodetech.Administrador.Repository;
using DsiCodetech.Administrador.Repository.PosAdmin;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;

namespace DsiCodetech.Administrador.Business
{
    public class ClienteBusiness : IClienteBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ClienteRepository repository;
        private readonly DireccionRepository direccionRepository;

        public ClienteBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new ClienteRepository(unitOfWork);
            direccionRepository = new DireccionRepository(unitOfWork);
        }

        /// <summary>
        /// Este metodo se encarga de consultar un cliente por Identificador
        /// </summary>
        /// <param name="id">identificador de la entidad</param>
        /// <returns>la entidad del tipo clienteDM</returns>
        public ClienteDM GetClienteById(Guid id)
        {
            var clienteModel = repository.SingleOrDefaultInclude(c => c.id_cliente.Equals(id), "direccion");

            if (clienteModel == null)
                throw new BusinessException("El cliente que desea buscar no existe.");

            ClienteDM cliente = new ClienteDM
            {
                IdCliente = clienteModel.id_cliente,
                Rfc = clienteModel.rfc,
                RazonSocial = clienteModel.razon_social,
                RegimenFiscal = clienteModel.regimen_fiscal,
                Contacto = clienteModel.contacto,
                Email = clienteModel.e_mail,
                Email2 = clienteModel.e_mail2,
            };

            if (clienteModel.direccion.Any())
            {
                var model = clienteModel.direccion.FirstOrDefault();
                cliente.Direccion = new DireccionDM
                {
                    IdCliente = model.id_cliente,
                    IdDireccion = model.id_direccion,
                    IdEntidad = model.id_entidad,
                    IdMunicipio = model.id_municipio,
                    CodigoPostal = model.codigo_postal,
                    Colonia = model.colonia,
                    Calle = model.calle,
                    NoExterior = model.no_exterior,
                    NoInterior = model.no_interior
                };
            }
            return cliente;
        }

        public PageResponse<ClienteDM> GetClientePaging(ClienteQuery query)
        {
            var whereFunc = PredicateBuilder.False<cliente>();
            Expression<Func<cliente, string>> orderByFunc = null;
            IEnumerable<cliente> result = null;
            bool isWhere = false;
            int count = 0;

            switch (query.page.sort.Name)
            {
                case "rfc":
                    orderByFunc = cliente => cliente.rfc;
                    break;
                case "razon_social":
                    orderByFunc = cliente => cliente.razon_social;
                    break;
                case "regimen_fiscal":
                    orderByFunc = cliente => cliente.regimen_fiscal;
                    break;
                default:
                    orderByFunc = cliente => cliente.e_mail;
                    break;
            }

            if (!String.IsNullOrEmpty(query.Rfc))
                whereFunc = whereFunc.Or(c => c.rfc.StartsWith(query.Rfc));

            if (!String.IsNullOrEmpty(query.RazonSocial))
                whereFunc = whereFunc.Or(c => c.razon_social.StartsWith(query.RazonSocial));

            if (!String.IsNullOrEmpty(query.RegimenFiscal))
                whereFunc = whereFunc.Or(c => c.regimen_fiscal.StartsWith(query.RegimenFiscal));

            if (!String.IsNullOrEmpty(query.Rfc) || !String.IsNullOrEmpty(query.RazonSocial) || !String.IsNullOrEmpty(query.RegimenFiscal))
                isWhere = true;

            switch (query.page.sort.Direction)
            {
                case Domain.Filter.Sort.Direction.Ascending:
                    result = isWhere ?
                        repository.GetPaging(whereFunc, orderByFunc, query.page.pageNumber, query.page.pageSize) :
                        repository.GetPaging(orderByFunc, query.page.pageNumber, query.page.pageSize);
                    break;
                case Domain.Filter.Sort.Direction.Descending:
                    result = isWhere ?
                        repository.GetPagingDescending(whereFunc, orderByFunc, query.page.pageNumber, query.page.pageSize) :
                        repository.GetPagingDescending(orderByFunc, query.page.pageNumber, query.page.pageSize);
                    break;
            }

            if (result.Any())
            {
                List<ClienteDM> clientes = result
                    .Select(cliente => new ClienteDM
                    {
                        IdCliente = cliente.id_cliente,
                        RazonSocial = cliente.razon_social,
                        RegimenFiscal = cliente.regimen_fiscal,
                        Rfc = cliente.rfc,
                        Contacto = cliente.contacto,
                        Email = cliente.e_mail,
                        Email2 = cliente.e_mail2
                    }).ToList();

                count = isWhere ? repository.Count(whereFunc) :
                    repository.Count();

                return new PageResponse<ClienteDM>(clientes, count, query.page.pageNumber, query.page.pageSize);
            }
            return new PageResponse<ClienteDM>(new List<ClienteDM>(), count, query.page.pageNumber, query.page.pageSize); ;
        }

        /// <summary>
        /// Este metodo se encarga de insertar una entidad cliente
        /// </summary>
        /// <param name="cliente">la entidad cliente</param>
        /// <returns>regresa un valor boolean</returns>
        public ClienteDM Insert(ClienteDM cliente)
        {

            if (this.repository.SingleOrDefault(c => c.rfc.Equals(cliente.Rfc)) != null)
            {
                throw new BusinessException("El RFC que intenta agregar ya existe.");
            }

            Guid idClient = Guid.NewGuid();
            Guid idDireccion = Guid.NewGuid();

            cliente model = new cliente
            {
                id_cliente = idClient,
                rfc = cliente.Rfc,
                razon_social = cliente.RazonSocial,
                regimen_fiscal = cliente.RegimenFiscal,
                e_mail = cliente.Email,
                e_mail2 = cliente.Email2,
                contacto = cliente.Contacto
            };

            cliente tmp = repository.Insert(model);

            direccion direccion = new direccion
            {
                id_cliente = idClient,
                id_direccion = idDireccion,
                id_entidad = cliente.Direccion.IdEntidad,
                id_municipio = cliente.Direccion.IdMunicipio,
                codigo_postal = cliente.Direccion.CodigoPostal,
                calle = cliente.Direccion.Calle,
                colonia = cliente.Direccion.Colonia,
                no_exterior = cliente.Direccion.NoExterior,
                no_interior = cliente.Direccion.NoInterior
            };

            direccion tmpDir = this.direccionRepository.Insert(direccion);

            return new ClienteDM
            {
                IdCliente = tmp.id_cliente,
                Rfc = cliente.Rfc,
                RazonSocial = cliente.RazonSocial,
                RegimenFiscal = cliente.RegimenFiscal,
                Contacto = cliente.Contacto,
                Email = cliente.Email,
                Email2 = cliente.Email2,
                Direccion = new DireccionDM
                {
                    IdCliente = idClient,
                    IdDireccion = idDireccion,
                    IdEntidad = tmpDir.id_entidad,
                    IdMunicipio = tmpDir.id_municipio,
                    CodigoPostal = tmpDir.codigo_postal,
                    Calle = tmpDir.calle,
                    Colonia = tmpDir.colonia,
                    NoExterior = tmpDir.no_exterior,
                    NoInterior = tmpDir.no_interior
                }
            };
        }

        public ClienteDM UpdateCliente(ClienteDM cliente, Guid id)
        {
            direccion direccion = new direccion
            {
                id_cliente = id,
                id_entidad = cliente.Direccion.IdEntidad,
                id_municipio = cliente.Direccion.IdMunicipio,
                codigo_postal = cliente.Direccion.CodigoPostal,
                calle = cliente.Direccion.Calle,
                colonia = cliente.Direccion.Colonia,
                no_exterior = cliente.Direccion.NoExterior,
                no_interior = cliente.Direccion.NoInterior
            };

            direccion temp = this.direccionRepository.SingleOrDefault(c => c.id_cliente.Equals(id));

            if (temp != null)
            {
                direccion.id_direccion = temp.id_direccion;
                this.direccionRepository.Delete(d => d.id_cliente.Equals(id) && d.id_direccion.Equals(temp.id_direccion));
            }
            else
            {
                direccion.id_direccion = Guid.NewGuid();
            }

            this.direccionRepository.Insert(direccion);

            cliente clTemp = this.repository.SingleOrDefault(c => c.id_cliente.Equals(id));
            clTemp.rfc = cliente.Rfc;
            clTemp.razon_social = cliente.RazonSocial;
            clTemp.regimen_fiscal = cliente.RegimenFiscal;
            clTemp.contacto = cliente.Contacto;
            clTemp.e_mail = cliente.Email;
            clTemp.e_mail2 = cliente.Email2;

            this.repository.Update(clTemp);

            return cliente;
        }
    }
}
