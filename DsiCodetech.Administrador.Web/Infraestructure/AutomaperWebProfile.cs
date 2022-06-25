using DsiCodetech.Administrador.Domain;
using DsiCodetech.Administrador.Web.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DsiCodetech.Administrador.Web.Infraestructure
{
    public class AutomaperWebProfile : AutoMapper.Profile
    {
        public AutomaperWebProfile()
        {
            CreateMap<ClientesDto, ClienteDM>().ReverseMap();

            /* Módulo del SAT para la facturación */
            CreateMap<PeriocidadDM, PeriodicidadDto>().ReverseMap();
            CreateMap<MesDto, MesDM>().ReverseMap();
            CreateMap<ExportacionDM, ExportacionDto>().ReverseMap();
            CreateMap<UsoCfdiDM, UsoCfdiDto>().ReverseMap();
            CreateMap<RegimenFiscalDM, RegimenFiscalDto>().ReverseMap();
            CreateMap<FormaPagoDto, FormaPagoDM>().ReverseMap();
            CreateMap<MetodoPagoDM, MetodoPagoDto>().ReverseMap();
            CreateMap<TipoComprobanteDM, TipoComprobanteDto>().ReverseMap();
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