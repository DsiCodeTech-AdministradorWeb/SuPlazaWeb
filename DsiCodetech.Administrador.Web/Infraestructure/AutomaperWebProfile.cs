
using DsiCodetech.Administrador.Domain;
using DsiCodetech.Administrador.Domain.Filter.Model;

using DsiCodetech.Administrador.Web.Dto;
using DsiCodetech.Administrador.Web.Dto.Filter;

namespace DsiCodetech.Administrador.Web.Infraestructure
{
    public class AutomaperWebProfile : AutoMapper.Profile
    {
        public AutomaperWebProfile()
        {
            /* Módulo del SAT para la facturación */
            CreateMap<PeriocidadDM, PeriodicidadDto>().ReverseMap();
            CreateMap<MesDto, MesDM>().ReverseMap();
            CreateMap<ExportacionDM, ExportacionDto>().ReverseMap();
            CreateMap<UsoCfdiDM, UsoCfdiDto>().ReverseMap();
            CreateMap<RegimenFiscalDM, RegimenFiscalDto>().ReverseMap();
            CreateMap<FormaPagoDto, FormaPagoDM>().ReverseMap();
            CreateMap<MetodoPagoDM, MetodoPagoDto>().ReverseMap();
            CreateMap<TipoComprobanteDM, TipoComprobanteDto>().ReverseMap();
            CreateMap<TipoRelacionDM, TipoRelacionDto>().ReverseMap();

            /* Módulo para la facturación */
            CreateMap<FacturaFilterDM, FacturaFilterDto>().ReverseMap();
            CreateMap<FacturaDM, FacturaDto>()
                .ForMember(x => x.Emisor, x => x.MapFrom(y => y.Emisor))
                .ForMember(x => x.Receptor, x => x.MapFrom(y => y.Receptor))
                .ReverseMap();

            /* Módulo del Cliente */
            CreateMap<ClienteDM, ClienteFilterDto>().ReverseMap();

            CreateMap<ClienteDM, ClienteDto>()
                .ForMember(x => x.Direccion, x => x.MapFrom(d => d.Direccion))
                .ReverseMap();

            /* Módulo direcciones */
            CreateMap<MunicipioDM, MunicipioDto>().ReverseMap();
            CreateMap<EntidadDM, EntidadDto>().ReverseMap();

            /* Módulo venta */
            CreateMap<VentaDM, VentaDto>().ReverseMap();
        }

        public static void Run()
        {

            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<AutomaperWebProfile>();
            });
        }
    }
}