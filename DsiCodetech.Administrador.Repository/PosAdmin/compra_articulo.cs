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
    
    public partial class compra_articulo
    {
        public System.Guid id_compra { get; set; }
        public string cod_barras { get; set; }
        public short num_articulo { get; set; }
        public decimal cant_cja { get; set; }
        public decimal cant_pza { get; set; }
        public decimal precio_compra { get; set; }
        public short no_captura { get; set; }
        public decimal no_entrega { get; set; }
    
        public virtual articulo articulo { get; set; }
        public virtual compra compra { get; set; }
    }
}
