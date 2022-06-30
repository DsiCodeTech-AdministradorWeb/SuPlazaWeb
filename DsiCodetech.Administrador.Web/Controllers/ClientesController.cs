using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

using NLog;

using DsiCodetech.Administrador.Business.Interface;
using DsiCodetech.Administrador.Domain;
using DsiCodetech.Administrador.Web.Dto;
using DsiCodetech.Administrador.Web.Dto.Filter;
using DsiCodetech.Administrador.Web.Handler.ExceptionHandler;
using DsiCodetech.Administrador.Web.Resources;

using DsiCodetech.Administrador.Domain.Filter.Page;
using DsiCodetech.Administrador.Domain.Filter.Query;
using DsiCodetech.Administrador.Domain.Filter.Sort;

namespace DsiCodetech.Administrador.Web.Controllers
{
    [SuPlazaExceptionFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/clientes")]
    public class ClientesController : ApiController
    {
        private readonly IClienteBusiness clientesBusiness;
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");

        public ClientesController(IClienteBusiness _clientesBusiness)
        {
            clientesBusiness = _clientesBusiness;
        }


        [Route("getClientById/{id_cliente}")]
        [HttpGet]
        [ResponseType(typeof(ClienteDto))]
        public IHttpActionResult GetClientePorId(string id_cliente)
        {
            try
            {
                return Ok(AutoMapper.Mapper.Map<ClienteDto>(clientesBusiness.GetClienteById(id_cliente)));
            }
            catch (Exception ex)
            {
                loggerdb.Error(ex);
                throw;
            }
        }

        [Route("agregar")]
        [HttpPost]
        public IHttpActionResult AddClient([FromBody] ClienteDto customer)
        {
            try
            {
                return Ok(clientesBusiness.Insert(AutoMapper.Mapper.Map<ClienteDM>(customer)));
            }
            catch (Exception ex)
            {
                loggerdb.Error(ex);
                throw;
            }
        }

        [Route("actualizar/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateClient([FromBody] ClienteDto customer, Guid id)
        {
            try
            {
                var cliente = AutoMapper.Mapper.Map<ClienteDM>(customer);
                var result = clientesBusiness.UpdateCliente(cliente, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                loggerdb.Error(ex);
                throw;
            }
        }

        [ResponseType(typeof(PageResponse<ClienteFilterDto>))]
        [Route("prueba")]
        [HttpGet]
        public IHttpActionResult GetClientesFromQuery([FromUri] ClienteQuery query, int page_size, int page_number, string name)
        {
            try
            {
                query.page = new();
                query.page.pageSize = page_size;
                query.page.pageNumber = page_number;

                query.page.sort = new();
                query.page.sort.Name = "rfc";
                query.page.sort.Direction = Direction.Ascending;
                return Ok(AutoMapper.Mapper.Map<PageResponse<ClienteFilterDto>>(clientesBusiness.GetClientePaging(query)));
            }
            catch (Exception ex)
            {
                loggerdb.Error(ex);
                throw;
            }

        }


    }
}
