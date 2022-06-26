using DsiCodetech.Administrador.Business.Interface;
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
using System.Web.Http.Results;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace DsiCodetech.Administrador.Web.Controllers
{
    

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/regimenfiscal")]
    public class RegimenFiscalController : ApiController
    {
        private readonly IRegimenFiscalBusiness regimenFiscalBusiness;
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");

        public RegimenFiscalController(IRegimenFiscalBusiness _regimenFiscalBusiness)
        {
            regimenFiscalBusiness = _regimenFiscalBusiness;

            
        }

        [HttpGet]
        [Route("api/regimenfiscal/GetRegimenFiscal")]
        public IHttpActionResult GetRegimenFiscal()
        {
            try
            {
                var regimenFiscal = regimenFiscalBusiness.GetAllRegimenFiscal();
                var regimenes=AutoMapper.Mapper.Map<List<RegimenFiscalDto>>(regimenFiscal);
                return Ok(regimenes);
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
