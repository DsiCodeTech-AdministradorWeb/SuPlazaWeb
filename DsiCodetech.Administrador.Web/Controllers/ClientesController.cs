﻿using DsiCodetech.Administrador.Business;
using DsiCodetech.Administrador.Business.Interface;
using DsiCodetech.Administrador.Domain;
using DsiCodetech.Administrador.Web.Dto;
using DsiCodetech.Administrador.Web.Resources;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DsiCodetech.Administrador.Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClientesController : ApiController
    {
        private readonly IClienteBusiness clientesBusiness;
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");
        public ClientesController(IClienteBusiness _clientesBusiness)
        {
            clientesBusiness = _clientesBusiness;
        }

        [HttpGet]
        public IHttpActionResult GetClientes()
        {
            try
            {
                var clientes = clientesBusiness.GetAllClientes();
                var clientesDto = AutoMapper.Mapper.Map<List<ClientesDto>>(clientes);
                return Ok(clientesDto);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error en la peticion dentro de: Clientes, en la Acción : GetClientes");
                loggerdb.Error(ex);
                return BadRequest(Utilerias.BAD_REQUEST);
            }
        }

        [HttpGet]
        public IHttpActionResult GetClientePorId(string id_cliente)
        {
            try
            {
                var cliente = clientesBusiness.GetClienteById(id_cliente);
                var clienteDto = AutoMapper.Mapper.Map<ClientesDto>(cliente);
                return Ok(clienteDto);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error en la peticion dentro de: Clientes, en la Acción : GetClientePoId");
                loggerdb.Error(ex);
                return BadRequest(Utilerias.BAD_REQUEST);
            }
        }


        [HttpPost]
        public IHttpActionResult Agregar(ClientesDto customer)
        {
            try
            {
                var cliente = AutoMapper.Mapper.Map<ClienteDM>(customer);
                var result= clientesBusiness.Insert(cliente);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error en la peticion dentro de: Clientes, en la Acción : GetClientePoId");
                loggerdb.Error(ex);
                return BadRequest(Utilerias.BAD_REQUEST);
            }
        }



    }
}