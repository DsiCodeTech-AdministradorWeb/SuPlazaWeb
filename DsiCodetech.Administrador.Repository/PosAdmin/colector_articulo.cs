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
    using System.Collections.Generic;
    
    public partial class colector_articulo
    {
        public string cod_barras { get; set; }
        public long id_clasificacion { get; set; }
        public string cod_asociado { get; set; }
        public string cod_interno { get; set; }
        public string descripcion { get; set; }
        public string descripcion_corta { get; set; }
        public decimal cantidad_um { get; set; }
        public System.Guid id_unidad { get; set; }
        public System.Guid id_proveedor { get; set; }
        public decimal precio_compra { get; set; }
        public decimal utilidad { get; set; }
        public decimal precio_venta { get; set; }
        public string tipo_articulo { get; set; }
        public decimal stock { get; set; }
        public decimal stock_min { get; set; }
        public decimal stock_max { get; set; }
        public decimal iva { get; set; }
        public Nullable<System.DateTime> kit_fecha_ini { get; set; }
        public Nullable<System.DateTime> kit_fecha_fin { get; set; }
        public bool articulo_disponible { get; set; }
        public bool kit { get; set; }
        public System.DateTime fecha_registro { get; set; }
        public bool visible { get; set; }
        public short puntos { get; set; }
        public System.DateTime last_update_inventory { get; set; }
    }
}