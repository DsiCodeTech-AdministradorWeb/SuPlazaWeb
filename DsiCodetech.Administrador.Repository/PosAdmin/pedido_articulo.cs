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
    
    public partial class pedido_articulo
    {
        public System.Guid id_pedido { get; set; }
        public short no_articulo { get; set; }
        public string cod_barras { get; set; }
        public string cod_anexo { get; set; }
        public decimal cant_original { get; set; }
        public decimal cantidad { get; set; }
        public decimal precio_articulo { get; set; }
        public decimal sugerido { get; set; }
    
        public virtual articulo articulo { get; set; }
        public virtual articulo articulo1 { get; set; }
        public virtual pedido pedido { get; set; }
    }
}
