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
    
    public partial class factura_articulo
    {
        public System.Guid id_factura_articulo { get; set; }
        public long id_factura { get; set; }
        public string cod_barras { get; set; }
        public string descripcion { get; set; }
        public System.Guid id_unidad { get; set; }
        public decimal cantidad { get; set; }
        public decimal iva { get; set; }
        public decimal precio_vta { get; set; }
    
        public virtual factura factura { get; set; }
        public virtual unidad_medida unidad_medida { get; set; }
    }
}
