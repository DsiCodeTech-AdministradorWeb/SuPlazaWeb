using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

using NLog;

using DsiCodetech.Administrador.Business.Interface;
using DsiCodetech.Administrador.Web.Dto;

using DsiCodetech.Administrador.Web.Handler.ExceptionHandler;

namespace DsiCodetech.Administrador.Web.Controllers
{

    [SuPlazaExceptionFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix(prefix: "api/direccion")]
    public class DireccionController : ApiController
    {
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");

        private readonly IDireccionBusiness direccionBusiness;

        public DireccionController(IDireccionBusiness direccionBusiness)
        {
            this.direccionBusiness = direccionBusiness;
        }

        [ResponseType(typeof(List<EntidadDto>))]
        [Route(template: "entidades")]
        [HttpGet]
        public IHttpActionResult GetEntidades()
        {
            try
            {
                return Ok(AutoMapper.Mapper.Map<List<EntidadDto>>(direccionBusiness.GetAllEntidades()));
            }
            catch (Exception ex)
            {
                loggerdb.Error(ex);
                throw;
            }
        }

        [ResponseType(typeof(List<MunicipioDto>))]
        [Route(template: "municipios/{id}")]
        [HttpGet]
        public IHttpActionResult GetMunicipios(short id)
        {
            try
            {
                return Ok(AutoMapper.Mapper.Map<List<MunicipioDto>>(direccionBusiness.GetAllMunicipios(id)));
            }
            catch (Exception ex)
            {
                loggerdb.Error(ex);
                throw;
            }
        }
    }
}