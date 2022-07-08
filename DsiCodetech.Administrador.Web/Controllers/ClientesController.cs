using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

using NLog;

using DsiCodetech.Administrador.Business.Interface;
using DsiCodetech.Administrador.Domain;
using DsiCodetech.Administrador.Web.Dto;
using DsiCodetech.Administrador.Web.Dto.Filter;
using DsiCodetech.Administrador.Web.Handler.ExceptionHandler;

using DsiCodetech.Administrador.Domain.Filter.Page;
using DsiCodetech.Administrador.Domain.Filter.Query;

namespace DsiCodetech.Administrador.Web.Controllers
{
    [SuPlazaExceptionFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/clientes")]
    public class ClientesController : ApiController
    {
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");

        private readonly IClienteBusiness clientesBusiness;

        public ClientesController(IClienteBusiness _clientesBusiness)
        {
            clientesBusiness = _clientesBusiness;
        }


        [Route("getClientById/{id_cliente}")]
        [HttpGet]
        [ResponseType(typeof(ClienteDto))]
        public IHttpActionResult GetClientePorId(Guid id_cliente)
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

        [ResponseType(typeof(PageResponse<ClienteFilterDto>))]
        [Route("clientes")]
        [HttpGet]
        public IHttpActionResult GetClientesFromQuery([FromUri] ClienteQuery query, int page_size, int page_number, string sort)
        {
            try
            {
                query.page = new(page_size, page_number, sort);
                return Ok(AutoMapper.Mapper.Map<PageResponse<ClienteFilterDto>>(clientesBusiness.GetClientePaging(query)));
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
                return Ok(clientesBusiness.UpdateCliente(AutoMapper.Mapper.Map<ClienteDM>(customer), id));
            }
            catch (Exception ex)
            {
                loggerdb.Error(ex);
                throw;
            }
        }
    }
}
