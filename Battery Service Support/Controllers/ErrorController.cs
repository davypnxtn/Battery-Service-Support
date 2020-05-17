using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Battery_Service_Support.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }

        // ----- Weergeven foutpagina adhv statuscode, loggen details van foutmelding in logfile -----
        [AllowAnonymous]
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            if (statusCodeResult != null)
            {
                switch (statusCode)
                {
                    case 400:
                        ViewData["ErrorMessage"] = "Sorry, bad request";
                        logger.LogWarning($"400 Error Occured. Path = {statusCodeResult.OriginalPath}" + $"and QueryString = {statusCodeResult.OriginalQueryString}");
                        break;
                    case 401:
                        ViewData["ErrorMessage"] = "Sorry, the request has not been applied because it lacks valid authentication credentials for the target resource";
                        logger.LogWarning($"400 Error Occured. Path = {statusCodeResult.OriginalPath}" + $"and QueryString = {statusCodeResult.OriginalQueryString}");
                        break;
                    case 403:
                        ViewData["ErrorMessage"] = "Sorry, the server understood the request but refuses to authorize it";
                        logger.LogWarning($"400 Error Occured. Path = {statusCodeResult.OriginalPath}" + $"and QueryString = {statusCodeResult.OriginalQueryString}");
                        break;
                    case 404:
                        ViewData["ErrorMessage"] = "Sorry, the resource you requested could not be found";
                        logger.LogWarning($"404 Error Occured. Path = {statusCodeResult.OriginalPath}" + $"and QueryString = {statusCodeResult.OriginalQueryString}");
                        break;
                    case 405:
                        ViewData["ErrorMessage"] = "Sorry, this method is not allowed";
                        logger.LogWarning($"405 Error Occured. Path = {statusCodeResult.OriginalPath}" + $"and QueryString = {statusCodeResult.OriginalQueryString}");
                        break;
                    case 500:
                        ViewData["ErrorMessage"] = "Sorry, the server encountered an unexpected condition that prevented it from fulfilling the request";
                        logger.LogWarning($"404 Error Occured. Path = {statusCodeResult.OriginalPath}" + $"and QueryString = {statusCodeResult.OriginalQueryString}");
                        break;
                    case 501:
                        ViewData["ErrorMessage"] = "Sorry, the server does not support the functionality required to fulfill the request";
                        logger.LogWarning($"404 Error Occured. Path = {statusCodeResult.OriginalPath}" + $"and QueryString = {statusCodeResult.OriginalQueryString}");
                        break;
                    case 503:
                        ViewData["ErrorMessage"] = "Sorry, the server is currently unable to handle the request due to a temporary overload or scheduled maintenance";
                        logger.LogWarning($"404 Error Occured. Path = {statusCodeResult.OriginalPath}" + $"and QueryString = {statusCodeResult.OriginalQueryString}");
                        break;
                }
            }
            
            return View("NotFound");
        }

        // ----- Weergeven foutpagina indien er geen statuscode meegegeven wordt, loggen details van foutmelding in logfile -----
        [AllowAnonymous]
        [Route("Error")]
        public IActionResult Error()
        {
            
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            logger.LogError($"The path {exceptionDetails.Path} threw an exception " + $"{exceptionDetails.Error}");

            return View("Error");
        }
    }
}
