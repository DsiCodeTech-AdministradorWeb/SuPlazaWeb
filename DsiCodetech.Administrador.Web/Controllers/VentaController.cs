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

namespace DsiCodetech.Administrador.Web.Controllers
{

    [SuPlazaExceptionFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/ventas")]
    public class VentaController : ApiController
    {
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");
        private readonly IVentaBusiness ventaBusiness;

        public VentaController(IVentaBusiness _ventaBusiness)
        {
            this.ventaBusiness = _ventaBusiness;
        }

        [Route("getVentaByFolio")]
        [HttpGet]
        [ResponseType(typeof(VentaDto))]
        public IHttpActionResult GetClientePorId(long folio, int id_pos)
        {
            try
            {
                return Ok(AutoMapper.Mapper.Map<VentaDto>(this.ventaBusiness.GetVentaIfNotExistInvoice(folio, id_pos)));
            }
            catch (Exception ex)
            {
                loggerdb.Error(ex);
                throw;
            }
        }
    }
}