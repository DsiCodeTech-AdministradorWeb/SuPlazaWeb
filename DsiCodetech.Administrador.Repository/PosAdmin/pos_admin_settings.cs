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
    
    public partial class pos_admin_settings
    {
        public System.Guid id_setting { get; set; }
        public string path_ptr_label { get; set; }
        public string path_dir_bascula { get; set; }
        public long cod_normal { get; set; }
        public long cod_pesable { get; set; }
        public long cod_nopesable { get; set; }
        public decimal iva { get; set; }
        public string cfdi_user { get; set; }
        public string cfdi_pwsd { get; set; }
        public string cfdi_path_txt { get; set; }
        public string cfdi_path_pdf { get; set; }
    }
}
