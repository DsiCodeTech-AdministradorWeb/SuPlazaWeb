using DsiCodetech.Administrador.Business.Interface;
using DsiCodetech.Administrador.Domain;
using DsiCodetech.Administrador.Web.Dto;
using DsiCodetech.Administrador.Web.Resources;
using NLog;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace DsiCodetech.Administrador.Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/clientes")]
    public class ClientesController : ApiController
    {
        private readonly IClienteBusiness clientesBusiness;
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");
        public ClientesController(IClienteBusiness _clientesBusiness)
        {
            clientesBusiness = _clientesBusiness;
        }

        [Route("api/clientes/GetClientes")]
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

        [Route("api/clientes/GetClientePorId/{id_cliente}")]
        [HttpGet]
        [ResponseType(typeof(ClientesDto))]
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

        [Route("api/clientes/Agregar")]
        [HttpPost]
        public IHttpActionResult Agregar([FromBody] ClientesDto customer)
        {
            try
            {
                var cliente = AutoMapper.Mapper.Map<ClienteDM>(customer);
                var result= clientesBusiness.Insert(cliente);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error en la peticion dentro de: Clientes, en la Acción : Agregar");
                loggerdb.Error(ex);
                return BadRequest(Utilerias.BAD_REQUEST);
            }
        }



    }
}
