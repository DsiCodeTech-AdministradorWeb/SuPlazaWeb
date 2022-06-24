﻿using DsiCodetech.Administrador.Business.Interface;
using DsiCodetech.Administrador.Domain;
using DsiCodetech.Administrador.Repository;
using DsiCodetech.Administrador.Repository.Infraestructure;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsiCodetech.Administrador.Business
{
    public class ClienteBusiness : IClienteBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ClienteRepository repository;

        public ClienteBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            repository = new ClienteRepository(unitOfWork);
        }

        /// <summary>
        /// Este metodo se encarga de consultar todas las entidades del tipo clientes
        /// </summary>
        /// <returns>regresa una coleccion de clientes</returns>
        public List<ClienteDM> GetAllClientes()
        {
            List<ClienteDM> clientes = null;

            clientes = repository.GetAll().Select(p => new ClienteDM
            {
                IdCliente = p.id_cliente,
                Rfc = p.rfc,
                RazonSocial = p.razon_social,
                RegimenFiscal = p.regimen_fiscal

            }).OrderBy(p=>p.IdCliente).ToList();
            return clientes;
        }
        /// <summary>
        /// Este metodo se encarga de consultar un cliente por Identificador
        /// </summary>
        /// <param name="id">identificador de la entidad</param>
        /// <returns>la entidad del tipo clienteDM</returns>
        public ClienteDM GetClienteById(string id)
        {

            var clienteModel = repository.SingleOrDefault(p => p.id_cliente.Equals(id));
            ClienteDM metodoPagoModel = new ClienteDM
            {
                IdCliente = clienteModel.id_cliente,
                Rfc = clienteModel.rfc,
                RazonSocial = clienteModel.razon_social,
                RegimenFiscal = clienteModel.regimen_fiscal
            };
            return metodoPagoModel;
        }
        /// <summary>
        /// Este metodo se encarga de insertar una entidad cliente
        /// </summary>
        /// <param name="cliente">la entidad cliente</param>
        /// <returns>regresa un valor boolean</returns>
        public bool Insert(ClienteDM cliente)
        {
            bool respuesta = false;
            var model = new cliente
            {
                razon_social= cliente.RazonSocial,
                regimen_fiscal = cliente.RegimenFiscal,
                rfc = cliente.Rfc
            };
            repository.Insert(model);
            respuesta = true;
            return respuesta;
        }

    }
}
