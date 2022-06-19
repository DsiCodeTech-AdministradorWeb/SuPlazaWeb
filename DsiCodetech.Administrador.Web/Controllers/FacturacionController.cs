using DsiCodetech.Administrador.Business.Interface;
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
    //[Route(Name ="facturacion")]
    public class FacturacionController : ApiController
    {
        private readonly IExportacionBusiness exportacionBusiness;
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");
        public FacturacionController(IExportacionBusiness _exportacionBusiness)
        {
            exportacionBusiness = _exportacionBusiness;
        }


        [System.Web.Http.HttpGet]
        //[System.Web.Http.Route(Name = "exportacion")]
        public IHttpActionResult GetExportacion()
        {
            try
            {
                var exportacion = exportacionBusiness.GetAllExportacion();
                //var regimenes = AutoMapper.Mapper.Map<List<RegimenFiscalDto>>(regimenFiscal);
                return Ok(exportacion);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error en la peticion dentro de: RegimenFiscal, en la Acción : GetRegimenFiscal");
                loggerdb.Error(ex);
                return BadRequest(Utilerias.BAD_REQUEST);

            }
        }


    }
}
