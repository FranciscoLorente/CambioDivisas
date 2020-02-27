using CambioDivisas.Services.Log;
using System.Web.Mvc;

namespace CambioDivisas.Controllers
{
    public class BaseController: Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            ILog log = new LogFichero();

            if (filterContext.ExceptionHandled)
            {
                return;
            }

            log.EscribirEntrada(filterContext.Exception.Message);

            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
            filterContext.ExceptionHandled = true;
        }
    }
}