using NLog;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

using System.Web.Http.Description;

using DsiCodetech.Administrador.Web.Dto;
using DsiCodetech.Administrador.Web.Dto.Filter;

using DsiCodetech.Administrador.Business.Interface;

using DsiCodetech.Administrador.Domain;
using DsiCodetech.Administrador.Domain.Filter.Page;
using DsiCodetech.Administrador.Domain.Filter.Query;

using DsiCodetech.Administrador.Web.Handler.ExceptionHandler;

namespace DsiCodetech.Administrador.Web.Controllers
{
    [SuPlazaExceptionFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix(prefix: "api/facturacion")]
    public class FacturacionController : ApiController
    {
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");

        private readonly ITipoRelacionBusiness tipoRelacionBusiness;
        private readonly ITipoComprobanteBusiness tipoComprobanteBusiness;
        private readonly IExportacionBusiness exportacionBusiness;
        private readonly IPeriocidadBusiness periocidadBusiness;
        private readonly IFormaPagoBusiness pagoBusiness;
        private readonly IMetodoPagoBusiness metodoPagoBusiness;
        private readonly IRegimenFiscalBusiness regimenFiscalBusiness;
        private readonly IUsoCfdiBusiness usoCfdiBusiness;
        private readonly IMesBusiness mesBusiness;

        private readonly IFacturacionBusiness facturacionBusiness;

        public FacturacionController(IExportacionBusiness _exportacionBusiness, IFormaPagoBusiness _pagoBusiness, IMesBusiness _mesBusiness,
            IPeriocidadBusiness _periocidadBusiness, IRegimenFiscalBusiness _regimenFiscalBusiness, IUsoCfdiBusiness _usoCfdiBusiness,
            IMetodoPagoBusiness _metodoPagoBusiness, ITipoComprobanteBusiness _tipoComprobanteBusiness, ITipoRelacionBusiness _tipoRelacionBusiness,
            IFacturacionBusiness _facturacionBusiness)
        {
            exportacionBusiness = _exportacionBusiness;
            pagoBusiness = _pagoBusiness;
            mesBusiness = _mesBusiness;
            periocidadBusiness = _periocidadBusiness;
            regimenFiscalBusiness = _regimenFiscalBusiness;
            usoCfdiBusiness = _usoCfdiBusiness;
            metodoPagoBusiness = _metodoPagoBusiness;
            tipoComprobanteBusiness = _tipoComprobanteBusiness;
            tipoRelacionBusiness = _tipoRelacionBusiness;

            facturacionBusiness = _facturacionBusiness;
        }

        #region Cátalogo de facturas

        [ResponseType(typeof(List<TipoRelacionDto>))]
        [Route(template: "tiporelacion")]
        [HttpGet]
        public IHttpActionResult GetTipoRelacion()
        {
            try
            {
                return Ok(AutoMapper.Mapper.Map<List<TipoRelacionDto>>(tipoRelacionBusiness.GetAllTipoRelaciones()));
            }
            catch (Exception ex)
            {
                loggerdb.Error(ex);
                throw;
            }
        }

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

        [ResponseType(typeof(FacturaDto))]
        [Route("GetFacturaByIdClient/{id}")]
        [HttpGet]
        public IHttpActionResult GetFacturaByIdClient(Guid id)
        {
            try
            {
                return Ok(AutoMapper.Mapper.Map<FacturaDto>(this.facturacionBusiness.GetFacturaByIdClient(id)));
            }
            catch (Exception ex)
            {
                loggerdb.Error(ex);
                throw;
            }
        }

        [ResponseType(typeof(PageResponse<FacturaFilterDto>))]
        [Route("facturas")]
        [HttpGet]
        public IHttpActionResult GetFacturaFromQuery([FromUri] FacturaQuery query, int page_size, int page_number, string sort)
        {
            try
            {
                query.page = new(page_size, page_number, sort);
                return Ok(AutoMapper.Mapper.Map<PageResponse<FacturaFilterDto>>(this.facturacionBusiness.GetFacturaPaging(query)));
            }
            catch (Exception ex)
            {
                loggerdb.Error(ex);
                throw;
            }
        }

        [ResponseType(typeof(FacturaDto))]
        [Route("agregar/{id_cliente}")]
        [HttpPost]
        public IHttpActionResult AddFactura([FromBody] FacturaDto request, Guid id_cliente) /* Id de la factura */
        {
            try
            {
                return Ok(this.facturacionBusiness.Insert(AutoMapper.Mapper.Map<FacturaDM>(request), id_cliente));
            }
            catch (Exception ex)
            {
                loggerdb.Error(ex);
                throw;
            }
        }

        #endregion

    }
}
