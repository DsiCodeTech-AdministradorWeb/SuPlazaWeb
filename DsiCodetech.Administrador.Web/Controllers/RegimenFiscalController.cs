using DsiCodetech.Administrador.Business.Interface;
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
    public class RegimenFiscalController : Controller
    {
        private readonly IRegimenFiscalBusiness regimenFiscalBusiness;
        public RegimenFiscalController(IRegimenFiscalBusiness _regimenFiscalBusiness)
        {
            regimenFiscalBusiness = _regimenFiscalBusiness;

            
        }


        //[HttpGet]
        //[Route(Name ="regimenfiscal")]
        public JsonResult GetRegimenFiscal()
        {
            return Json(regimenFiscalBusiness.GetAllRegimenFiscal(),JsonRequestBehavior.AllowGet);
        }
    }
}
