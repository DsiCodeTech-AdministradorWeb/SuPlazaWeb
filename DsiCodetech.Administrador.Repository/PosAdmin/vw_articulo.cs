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
    
    public partial class vw_articulo
    {
        public string cod_barras { get; set; }
        public string cod_asociado { get; set; }
        public long id_clasificacion { get; set; }
        public string descripcion { get; set; }
        public string descripcion_corta { get; set; }
        public string tipo_articulo { get; set; }
        public decimal cantidad_um { get; set; }
        public System.Guid id_unidad { get; set; }
        public System.Guid id_proveedor { get; set; }
        public bool kit { get; set; }
    }
}