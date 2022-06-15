using DsiCodetech.Administrador.Domain;
using DsiCodetech.Administrador.Web.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DsiCodetech.Administrador.Web.Infraestructure
{
    public class AutomaperWebProfile: AutoMapper.Profile
    {
        public AutomaperWebProfile()
        {
            CreateMap<RegimenFiscalDM, RegimenFiscalDto>().ReverseMap();
        }
    }
}