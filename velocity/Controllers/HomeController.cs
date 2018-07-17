using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using velocity.Models;

namespace velocity.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult ThankYou(string whatever)
        {
            ViewBag.message = whatever;
            return View();
        }



        public IActionResult Error()        {
            string jsonvalue = (string) TempData["Error"];
            if (jsonvalue == null)
            {

                var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
                    // Get which route the exception occurred at
                string routeWhereExceptionOccurred = exceptionFeature.Path;

                // Get the exception that occurred
                Exception exceptionThatOccurred = exceptionFeature.Error;
                //throw exceptionThatOccurred;

                HttpResponse response = HttpContext.Response;
                //response.StatusCode = (int)status;
                //response.ContentType = "application/json";
                //var err = exceptionThatOccurred.StackTrace;
                var err = exceptionThatOccurred.Message + "\n" +
                    exceptionThatOccurred.StackTrace;
                //response.WriteAsync(err);
                return View(new ErrorViewModel { RequestId  = err});
            }
            else
            {
                ErrorData errors = JsonConvert.DeserializeObject<ErrorData>(jsonvalue);
                return StatusCode(errors.ErrorCode, errors.ErrorMessage);
            }

        }
    }
}
