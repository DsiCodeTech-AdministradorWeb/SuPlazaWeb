//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DsiCodetech.Administrador.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class salida
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public salida()
        {
            this.salida_articulo = new HashSet<salida_articulo>();
        }
    
        public System.Guid id_salida { get; set; }
        public long num_salida { get; set; }
        public System.DateTime fecha_salida { get; set; }
        public string observacion { get; set; }
        public Nullable<long> id_movto { get; set; }
        public string user_name { get; set; }
        public bool cancelada { get; set; }
        public Nullable<System.DateTime> fecha_cancelacion { get; set; }
    
        public virtual movimiento_almacen movimiento_almacen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<salida_articulo> salida_articulo { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
