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

namespace DsiCodetech.Administrador.Web.Controllers
{
    
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RegimenFiscalController : ApiController
    {
        private readonly IRegimenFiscalBusiness regimenFiscalBusiness;
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");

        public RegimenFiscalController(IRegimenFiscalBusiness _regimenFiscalBusiness)
        {
            regimenFiscalBusiness = _regimenFiscalBusiness;

            
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route(Name = "/regimenfiscal")]
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
