using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Results;
using System.Web.Http.ExceptionHandling;

using System.Net.Http.Formatting;

using NLog;

using DsiCodetech.Administrador.Web.Dto;

namespace DsiCodetech.Administrador.Web.Handler.ExceptionHandler
{
    /// <summary>
    /// Clase para controlar todas aquellas excepciones no controladas del sistema
    /// </summary>
    public class SuPlazaExceptionHandler : System.Web.Http.ExceptionHandling.ExceptionHandler
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public override void Handle(ExceptionHandlerContext context)
        {
            Exception exception = context.Exception;

            if (context.ExceptionContext.ActionContext != null && context.ExceptionContext.ControllerContext != null)
            {
                Log.Error(exception,
                    $"Error generado en { context.ExceptionContext.ActionContext.ActionDescriptor.ActionName } " +
                    $"en el controller { context.ExceptionContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName }");

            }

            var response = context.Request
                .CreateResponse(HttpStatusCode.Conflict,
                new HttpResponseOnError { Description = context.Exception.Message },
                new JsonMediaTypeFormatter() { SerializerSettings = { ContractResolver = new JsonLowerCaseResolver() } });

            context.Result = new ResponseMessageResult(response);
            base.Handle(context);
        }

    }
}