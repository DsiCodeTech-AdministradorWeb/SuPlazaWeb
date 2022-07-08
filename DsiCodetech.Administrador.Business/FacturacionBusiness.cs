using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using DsiCodetech.Administrador.Business.Interface;

using DsiCodetech.Administrador.Domain;
using DsiCodetech.Administrador.Domain.Extensions;
using DsiCodetech.Administrador.Domain.Exception;
using DsiCodetech.Administrador.Domain.Filter.Model;
using DsiCodetech.Administrador.Domain.Filter.Page;
using DsiCodetech.Administrador.Domain.Filter.Query;

using DsiCodetech.Administrador.Repository;
using DsiCodetech.Administrador.Repository.PosAdmin;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;

using DSICodeTech.FacturacionElectronica40.Model;
using DSICodeTech.FacturacionElectronica40.Invoice;

using DsiCodetech.Administrador.Business.Resources;

namespace DsiCodetech.Administrador.Business
{
    public class FacturacionBusiness : IFacturacionBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IClienteBusiness clienteBusiness;
        private readonly IEmpresaBusiness empresaBusiness;
        private readonly IVentaBusiness ventaBusiness;
        private readonly FacturacionRepository facturacionRepository;
        private readonly VentaRepository ventaRepository;
        public FacturacionBusiness(IUnitOfWork _unitOfWork, VentaRepository _ventaRepository, IClienteBusiness _clienteBusiness, IEmpresaBusiness _empresaBusiness, IVentaBusiness _ventaBusiness)
        {
            this.unitOfWork = _unitOfWork;
            this.facturacionRepository = new(this.unitOfWork);
            this.ventaRepository = _ventaRepository;

            this.clienteBusiness = _clienteBusiness;
            this.empresaBusiness = _empresaBusiness;
            this.ventaBusiness = _ventaBusiness;
        }

        public FacturaDM GetFacturaByIdClient(Guid id)
        {
            ClienteDM receptor = this.clienteBusiness.GetClienteById(id);
            EmpresaDM emisor = this.empresaBusiness.GetEmpresa();
            return new FacturaDM
            {
                Emisor = emisor,
                Receptor = receptor,
                ComprobanteInformacionGlobal = new ComprobanteInformacionGlobal(),
                TipoComprobante = "E",
                UsoCfdi = "G01",
                Exportacion = "01",
                FormaPago = "01",
                MetodoPago = "PUE"
            };
        }

        public PageResponse<FacturaFilterDM> GetFacturaPaging(FacturaQuery query)
        {
            var whereFunc = PredicateBuilder.False<factura>();
            Expression<Func<factura, string>> orderByFunc = null;
            IEnumerable<factura> result = null;
            bool isWhere = false;
            int count = 0;

            switch (query.page.sort.Name)
            {
                case "rfc":
                    orderByFunc = factura => factura.cliente.rfc;
                    break;
                case "razon_social":
                    orderByFunc = factura => factura.cliente.razon_social;
                    break;
                default:
                    orderByFunc = factura => factura.fecha_remision.ToString();
                    break;
            }

            if (!String.IsNullOrEmpty(query.Rfc))
                whereFunc = whereFunc.Or(f => f.cliente.rfc.StartsWith(query.Rfc));

            if (!String.IsNullOrEmpty(query.RazonSocial))
                whereFunc = whereFunc.Or(f => f.cliente.razon_social.StartsWith(query.RazonSocial));

            if (!String.IsNullOrEmpty(query.UsoCfdi))
                whereFunc = whereFunc.Or(f => f.uso_cfdi.Equals(query.UsoCfdi));

            if (!String.IsNullOrEmpty(query.MetodoPago))
                whereFunc = whereFunc.Or(f => f.metodo_pago.Equals(query.MetodoPago));

            if (!String.IsNullOrEmpty(query.FormaPago))
                whereFunc = whereFunc.Or(f => f.forma_pago.Equals(query.FormaPago));

            if (!String.IsNullOrEmpty(query.Rfc) || !String.IsNullOrEmpty(query.RazonSocial) || !String.IsNullOrEmpty(query.UsoCfdi) || !String.IsNullOrEmpty(query.MetodoPago) || !String.IsNullOrEmpty(query.FormaPago))
                isWhere = true;

            switch (query.page.sort.Direction)
            {
                case Domain.Filter.Sort.Direction.Ascending:
                    result = isWhere ?
                        this.facturacionRepository.GetPaging(whereFunc, orderByFunc, query.page.pageNumber, query.page.pageSize) :
                        this.facturacionRepository.GetPaging(orderByFunc, query.page.pageNumber, query.page.pageSize);
                    break;
                case Domain.Filter.Sort.Direction.Descending:
                    result = isWhere ?
                        this.facturacionRepository.GetPagingDescending(whereFunc, orderByFunc, query.page.pageNumber, query.page.pageSize) :
                        this.facturacionRepository.GetPagingDescending(orderByFunc, query.page.pageNumber, query.page.pageSize);
                    break;
            }

            if (result.Any())
            {
                List<FacturaFilterDM> facturas = result.Select(item => new FacturaFilterDM
                {
                    Id = item.id_factura,
                    Rfc = item.cliente.rfc,
                    RazonSocial = item.cliente.razon_social,
                    FechaRemision = item.fecha_remision,
                    FormaPago = item.forma_pago == null ? "" : item.forma_pago,
                    MetodoPago = item.metodo_pago == null ? "" : item.metodo_pago,
                    UsoCfdi = item.uso_cfdi == null ? "" : item.uso_cfdi,
                    Uuid = item.uuid_sat == null ? "" : item.uuid_sat.ToString(),
                    Status = item.estatus == null ? "Pendiente" : item.estatus.descripcion
                }).ToList();
                count = isWhere ? this.facturacionRepository.Count(whereFunc) : this.facturacionRepository.Count();
                return new PageResponse<FacturaFilterDM>(facturas, count, query.page.pageNumber, query.page.pageSize);
            }
            return new PageResponse<FacturaFilterDM>(new List<FacturaFilterDM>(), count, query.page.pageNumber, query.page.pageSize);
        }

        /// <summary>
        /// Este metodo se encarga de consultar una factura por el identificador de venta
        /// </summary>
        /// <param name="id_venta">el identificador de la venta</param>
        /// <returns>una entidad del tipo FacturaDM</returns>
        public FacturaDM getFacturaByIdVenta(Guid id_venta)
        {
            var result = ventaRepository.
                SingleOrDefaultForIncludes(p => p.id_venta.Equals(id_venta),
                EntitiesResources.Factura_Venta, EntitiesResources.Factura, EntitiesResources.Factura_Articulo,
                EntitiesResources.Cliente);
            return null;
        }

        public FacturaDM Insert(FacturaDM factura, Guid id_client)
        {
            bool hasError = false;
            ClienteDM cliente = this.clienteBusiness.GetClienteById(id_client); /*  */
            EmpresaDM empresa = this.empresaBusiness.GetEmpresa();

            if (cliente.Direccion is null)
                throw new BusinessException("El campo código postal es obligatorio para la nueva facturación CFDI 4.0");


            if (factura.Conceptos is null || !factura.Conceptos.Any())
                throw new BusinessException("No hay conceptos asociados que facturar, agregue al menos un concepto.");


            Comprobante comprobante = new();
            comprobante.Version = "4.0";
            comprobante.Moneda = "MXN";
            comprobante.FormaPago = factura.FormaPago;
            comprobante.MetodoPago = factura.MetodoPago;
            comprobante.TipoDeComprobante = factura.TipoComprobante;
            comprobante.Exportacion = factura.Exportacion;
            comprobante.LugarExpedicion = empresa.CodigoPostal;
            comprobante.Fecha = DateTime.Now.ToString("AAAA-MM-DDThh:mm:ss");

            /* Emisor */
            comprobante.Emisor = new()
            {
                Rfc = empresa.Rfc,
                Nombre = empresa.RazonSocial,
                RegimenFiscal = empresa.Representante
            };

            /* Receptor */
            comprobante.Receptor = new()
            {
                Rfc = cliente.Rfc,
                Nombre = cliente.RazonSocial,
                DomicilioFiscalReceptor = cliente.Direccion.CodigoPostal,
                RegimenFiscalReceptor = cliente.RegimenFiscal,
                UsoCFDI = factura.UsoCfdi
            };

            if (factura.ComprobanteCfdiRelacionados != null || factura.ComprobanteCfdiRelacionados.Any())
                comprobante.CfdiRelacionados = factura.ComprobanteCfdiRelacionados.ToArray();

            foreach (var item in factura.Conceptos)
            {
                try
                {
                    int idx = 0;
                    VentaDM ventaDM = this.ventaBusiness.GetVentaIfNotExistInvoice(item.Ticket, item.IdPos);

                    comprobante.Folio = item.Ticket.ToString();


                    venta venta = this.ventaRepository.SingleOrDefaultInclude(v => v.id_pos.Equals(ventaDM.Id) && v.id_venta.Equals(ventaDM.IdVenta), "venta_articulo");

                    decimal subTotalGlobal = default;
                    decimal descuentoGlobal = default;

                    foreach (venta_articulo va in venta.venta_articulo)
                    {
                        decimal subTotal = (va.precio_vta / (1.0m + va.iva)) * va.cantidad;
                        decimal descuento = subTotal * va.porcent_desc;

                        subTotalGlobal += subTotal;
                        descuentoGlobal += descuento;

                        articulo articulo = new articulo();

                        comprobante.Conceptos[idx++] = new()
                        {
                            ClaveProdServ = articulo.cve_producto,
                            ClaveUnidad = articulo.unidad_medida.cve_sat,
                            Descripcion = articulo.descripcion,

                            Importe = subTotal,
                            Descuento = descuento,
                            ValorUnitario = subTotal / va.cantidad,

                            NoIdentificacion = va.no_articulo.ToString(),

                            Impuestos = new()
                            {
                                Traslados = new ComprobanteConceptoImpuestosTraslado[]
                                {
                                    new ComprobanteConceptoImpuestosTraslado { }
                                }
                            }

                        };

                    }

                    comprobante.Total = Round(ventaDM.TotalVendido);
                    comprobante.Descuento = Round(descuentoGlobal);
                    comprobante.SubTotal = Round(subTotalGlobal);

                }
                catch (Exception)
                {
                    hasError = true;
                    continue;
                }

                InvoiceService invoiceService = new InvoiceService();

                invoiceService.GenerateTaxReceipt(comprobante);
            }



            if (hasError)
                throw new BusinessException("");

            throw new NotImplementedException();
        }

        private decimal Round(decimal value)
        {
            return Math.Ceiling(decimal.Parse(value.ToString("F3")) * 100.0m) / 100.0m;
        }
    }
}
