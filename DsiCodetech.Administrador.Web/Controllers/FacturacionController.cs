using DsiCodetech.Administrador.Business.Interface;
using DsiCodetech.Administrador.Web.Dto;
using DsiCodetech.Administrador.Web.Resources;
using NLog;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

using System.Web.Http.Description;

using DsiCodetech.Administrador.Web.Handler.ExceptionHandler;

namespace DsiCodetech.Administrador.Web.Controllers
{
    [SuPlazaExceptionFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix(prefix: "api/facturacion")]
    public class FacturacionController : ApiController
    {
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");

        private readonly ITipoComprobanteBusiness tipoComprobanteBusiness;
        private readonly IExportacionBusiness exportacionBusiness;
        private readonly IPeriocidadBusiness periocidadBusiness;
        private readonly IFormaPagoBusiness pagoBusiness;
        private readonly IMetodoPagoBusiness metodoPagoBusiness;
        private readonly IRegimenFiscalBusiness regimenFiscalBusiness;
        private readonly IUsoCfdiBusiness usoCfdiBusiness;
        private readonly IMesBusiness mesBusiness;

        public FacturacionController(IExportacionBusiness _exportacionBusiness, IFormaPagoBusiness _pagoBusiness, IMesBusiness _mesBusiness,
            IPeriocidadBusiness _periocidadBusiness, IRegimenFiscalBusiness _regimenFiscalBusiness, IUsoCfdiBusiness _usoCfdiBusiness,
            IMetodoPagoBusiness _metodoPagoBusiness, ITipoComprobanteBusiness _tipoComprobanteBusiness)
        {
            exportacionBusiness = _exportacionBusiness;
            pagoBusiness = _pagoBusiness;
            mesBusiness = _mesBusiness;
            periocidadBusiness = _periocidadBusiness;
            regimenFiscalBusiness = _regimenFiscalBusiness;
            usoCfdiBusiness = _usoCfdiBusiness;
            metodoPagoBusiness = _metodoPagoBusiness;
            tipoComprobanteBusiness = _tipoComprobanteBusiness;
        }

        #region Cátalogo de facturas

        [ResponseType(typeof(List<ExportacionDto>))]
        [Route(template: "exportaciones")]
        [HttpGet]
        public IHttpActionResult GetExportacion()
        {
            try
            {
                return Ok(AutoMapper.Mapper.Map<List<ExportacionDto>>(exportacionBusiness.GetAllExportacion()));
            }
            catch (Exception ex)
            {
                loggerdb.Error(ex);
                throw;
            }
        }

        [ResponseType(typeof(List<TipoComprobanteDto>))]
        [Route(template: "tipocomprobante")]
        [HttpGet]
        public IHttpActionResult GetTipoComprobante()
        {
            try
            {
                return Ok(AutoMapper.Mapper.Map<List<TipoComprobanteDto>>(tipoComprobanteBusiness.GetAllTipoComprobante()));
            }
            catch (Exception ex)
            {
                loggerdb.Error(ex);
                throw;
            }
        }

        [ResponseType(typeof(List<UsoCfdiDto>))]
        [Route("usocfdi")]
        [HttpGet]
        public IHttpActionResult GetUsoCfdi()
        {
            try
            {
                return Ok(AutoMapper.Mapper.Map<List<UsoCfdiDto>>(usoCfdiBusiness.GetAllUsoCfdi()));
            }
            catch (Exception ex)
            {
                loggerdb.Error(ex);
                throw;

            }
        }

        [ResponseType(typeof(List<FormaPagoDto>))]
        [Route("formaspagos")]
        [HttpGet]
        public IHttpActionResult GetFormasDePago()
        {
            try
            {
                return Ok(AutoMapper.Mapper.Map<List<FormaPagoDto>>(pagoBusiness.GetAllFormasDePago()));
            }
            catch (Exception ex)
            {
                loggerdb.Error(ex);
                throw;
            }
        }

        [ResponseType(typeof(List<MetodoPagoDto>))]
        [Route("metodopagos")]
        [HttpGet]
        public IHttpActionResult GetMetodoPago()
        {
            try
            {
                return Ok(AutoMapper.Mapper.Map<List<MetodoPagoDto>>(metodoPagoBusiness.GetAllMetodoPago()));
            }
            catch (Exception ex)
            {
                loggerdb.Error(ex);
                throw;
            }
        }

        [ResponseType(typeof(List<RegimenFiscalDto>))]
        [Route("regimenfiscales")]
        [HttpGet]
        public IHttpActionResult GetRegimenFiscal()
        {
            try
            {
                return Ok(AutoMapper.Mapper.Map<List<RegimenFiscalDto>>(regimenFiscalBusiness.GetAllRegimenFiscal()));
            }
            catch (Exception ex)
            {
                loggerdb.Error(ex);
                throw;
            }
        }

        [ResponseType(typeof(List<MesDto>))]
        [Route("meses")]
        [HttpGet]
        public IHttpActionResult GetMes()
        {
            try
            {
                return Ok(AutoMapper.Mapper.Map<List<MesDto>>(mesBusiness.GetMes()));
            }
            catch (Exception ex)
            {
                loggerdb.Error(ex);
                throw;
            }
        }

        [ResponseType(typeof(List<PeriodicidadDto>))]
        [Route("periodicidades")]
        [HttpGet]
        public IHttpActionResult GetPeriodicidad()
        {
            try
            {
                return Ok(AutoMapper.Mapper.Map<List<PeriodicidadDto>>(periocidadBusiness.GetAllPeriocidades()));
            }
            catch (Exception ex)
            {
                loggerdb.Error(ex);
                throw;
            }
        }
        #endregion


        #region Facturación



        #endregion

    }
}
