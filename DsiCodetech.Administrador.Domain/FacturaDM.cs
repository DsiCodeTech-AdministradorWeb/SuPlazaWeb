using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DSICodeTech.FacturacionElectronica40.Model;

namespace DsiCodetech.Administrador.Domain
{
    public class FacturaDM
    {
        public string Id { get; set; }

        public string MetodoPago { get; set; }

        public string FormaPago { get; set; }

        public string UsoCfdi { get; set; }

        public string TipoComprobante { get; set; }

        public string Exportacion { get; set; }

        public EmpresaDM Emisor { get; set; }

        public ClienteDM Receptor { get; set; }

        public ComprobanteInformacionGlobal ComprobanteInformacionGlobal { get; set; }

        public ComprobanteCfdiRelacionados ComprobanteCfdiRelacionados { get; set; }

        public ConceptoDM Conceptos { get; set; }

        public List<FacturaArticuloDM> FacturaArticulos { get; set; }    

    }

    public class ConceptoDM
    {
        public string ticket { get; set; }
    }

}
