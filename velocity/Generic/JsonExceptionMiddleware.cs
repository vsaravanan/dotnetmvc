using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using velocity.Extn;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;

namespace velocity.Generic
{
    public class JsonExceptionMiddleware  
    {
        public async Task Invoke(HttpContext context)
        {

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
            var ex = exceptionFeature?.Error;
            if (ex == null) return;

            HttpResponseMessage hrm;
            ExceptionResponse er = new ExceptionResponse();
            //string contentMessage = "";
            try
            {
                hrm = ((HttpResponseException) ex).Response;
                er = hrm.ExceptionResponse();
                //contentMessage = await hrm.Content.ReadAsStringAsync();
            }
            catch { }

            if (er.Message == null)
            {
                er.StatusCode = HttpStatusCode.InternalServerError;
                er.Message = ex.Message;
                er.Source = ex.Source;
                try
                {
                    ExternalException ee = (ExternalException)ex;
                    er.ErrorCode = ee.ErrorCode;
                }
                catch { }
                er.StackTrace = ex.StackTrace;

            }

            context.Response.StatusCode = (int) er.StatusCode;
            context.Response.ContentType = "application/json";

            using (var writer = new StreamWriter(context.Response.Body))
            {
                //new JsonSerializer().Serialize(writer, er);
                string jsondata = JsonConvert.SerializeObject(er);
                string jsonFormatted = JValue.Parse(jsondata).ToString(Formatting.Indented);
                jsonFormatted = jsonFormatted.Replace("\\r\\n", "\n");
                writer.Write(jsonFormatted);
                await writer.FlushAsync().ConfigureAwait(false);
            }
        }
    }
}
