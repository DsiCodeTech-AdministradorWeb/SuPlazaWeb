//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DsiCodetech.Administrador.Repository.PosAdmin
{
    using System;
    
    public partial class sp_pedido_captura_pendiente_Result
    {
        public string cod_barras { get; set; }
        public string articulo { get; set; }
        public string unidad { get; set; }
        public Nullable<decimal> cantidad_um { get; set; }
        public Nullable<decimal> stock_cja { get; set; }
        public Nullable<decimal> stock_pza { get; set; }
        public decimal precio_articulo { get; set; }
        public decimal cantidad { get; set; }
        public decimal cant_original { get; set; }
        public decimal sugerido { get; set; }
    }
}
