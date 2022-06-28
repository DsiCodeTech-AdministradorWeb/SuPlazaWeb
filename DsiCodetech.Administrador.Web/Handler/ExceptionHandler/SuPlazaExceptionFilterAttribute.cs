using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Net.Http.Formatting;

using NLog;

using DsiCodetech.Administrador.Web.Dto;

namespace DsiCodetech.Administrador.Web.Handler.ExceptionHandler
{
    /// <summary>
    /// Clase para controlar excepciones que conocemos o sabemos que podemos controlar en el flujo del proceso
    /// </summary>
    public class SuPlazaExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            Exception exception = actionExecutedContext.Exception;

            if (actionExecutedContext.ActionContext.RequestContext.Principal != null)
            {
                string user = actionExecutedContext.ActionContext.RequestContext.Principal.Identity.Name;
                Log.Error($"Se genero una excepción para el usuario { user }");
            }

            Log.Error(exception, $"Error generado en { actionExecutedContext.ActionContext.ActionDescriptor.ActionName } en el controller { actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName }");

            actionExecutedContext.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Conflict,
                RequestMessage = actionExecutedContext.Request,
                Content = new ObjectContent<HttpResponseOnError>(new HttpResponseOnError() { Description = exception.Message }, new JsonMediaTypeFormatter() { SerializerSettings = { ContractResolver = new JsonLowerCaseResolver() } }, "application/json")
            };

            base.OnException(actionExecutedContext);
        }
    }
}