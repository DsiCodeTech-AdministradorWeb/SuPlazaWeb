using DsiCodetech.Administrador.Business.Interface;
using DsiCodetech.Administrador.Web.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace DsiCodetech.Administrador.Web.Controllers
{
    public class RegimenFiscalController : ApiController
    {
        private readonly IRegimenFiscalBusiness regimenFiscalBusiness;
        public RegimenFiscalController(IRegimenFiscalBusiness _regimenFiscalBusiness)
        {
            regimenFiscalBusiness = _regimenFiscalBusiness;

            
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route(Name = "facturacion/regimenfiscal")]
        public IHttpActionResult GetRegimenFiscal()
        {
            try
            {
                var regimenFiscal = regimenFiscalBusiness.GetAllRegimenFiscal();
                return Ok(regimenFiscal);
            }
            catch (Exception ex)
            {
                return BadRequest(Utilerias.BAD_REQUEST);
                
            }
        }

        ////[HttpGet]
        ////[Route(Name ="regimenfiscal")]
        //public JsonResult GetRegimenFiscal()
        //{
        //    return Json(regimenFiscalBusiness.GetAllRegimenFiscal(),JsonRequestBehavior.AllowGet);
        //}
    }
}
