using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DsiCodetech.Administrador.Business.Interface;

using DsiCodetech.Administrador.Domain;
using DsiCodetech.Administrador.Domain.Exception;

using DsiCodetech.Administrador.Repository;
using DsiCodetech.Administrador.Repository.PosAdmin;
using DsiCodetech.Administrador.Repository.Infraestructure.Contract;

namespace DsiCodetech.Administrador.Business
{
    public class VentaBusiness : IVentaBusiness
    {
        private readonly VentaRepository ventaRepository;

        public VentaBusiness(IUnitOfWork unitOfWork)
        {
            this.ventaRepository = new(unitOfWork);
        }

        public VentaDM GetVentaIfNotExistInvoice(long folio, int id_pos)
        {
            venta venta = this.ventaRepository
                .SingleOrDefaultInclude(v => v.folio.Equals(folio) && v.id_pos.Equals(id_pos), "factura_venta");

            if (venta == null)
                throw new BusinessException("El folio que desea facturar no es existente, verifique que el folio sea correcto.");

            if (venta.factura_venta != null)
                throw new BusinessException(String.Format("El folio {0} ya fue facturado.", folio));

            return new VentaDM
            {
                Id = venta.id_pos,
                IdVenta = venta.id_venta,
                FechaVenta = venta.fecha_venta,
                Folio = venta.folio,
                NumeroRegistros = venta.num_registros,
                PagoCheque = venta.pago_cheque,
                PagoEfectivo = venta.pago_efectivo,
                PagoVales = venta.pago_vales,
                PagoTc = venta.pago_tc,
                TotalVendido = venta.total_vendido,
                Supervisor = venta.supervisor,
                Vendedor = venta.vendedor
            };
        }
    }
}
