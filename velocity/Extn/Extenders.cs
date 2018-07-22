using System.Net;
using System.Net.Http;

namespace velocity.Extn
{
    public static class Extenders
    {
        public static ExceptionResponse ExceptionResponse(this HttpResponseMessage hrm)
        {
            //string responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
            //ExceptionResponse exceptionResponse = JsonConvert.DeserializeObject<ExceptionResponse>(responseContent);

            ExceptionResponse exceptionResponse = new ExceptionResponse(hrm.StatusCode, hrm.ReasonPhrase);
            return exceptionResponse;

        }

    }

    public struct ExceptionResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        //public ExceptionResponse InnerException { get; set; }
        public int? ErrorCode { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }

        public ExceptionResponse(HttpStatusCode statusCode, string message)
        {
            this.StatusCode = statusCode;
            this.Message = message;
            this.ErrorCode = null;
            this.Source = null;
            this.StackTrace = null;
        }

    }


}
