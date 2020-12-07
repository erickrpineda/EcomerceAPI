using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace APIecomerce.Controllers
{
    public class BaseAPIController : ApiController
    {
        internal static readonly System.Net.Http.Formatting.MediaTypeFormatter DefaultFormatter = new System.Net.Http.Formatting.JsonMediaTypeFormatter
        {
            UseDataContractJsonSerializer = false,
            SerializerSettings =
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                DateFormatHandling = DateFormatHandling.IsoDateFormat
            }
        };

        internal System.Net.Http.HttpResponseMessage ErrorResponse(string message)
        {
            var resp = new System.Net.Http.HttpResponseMessage();
            resp.Content = new System.Net.Http.StringContent(message);
            resp.StatusCode = System.Net.HttpStatusCode.BadRequest;

            return resp;
        }

        string LocalToken = "cc4e9ba2-7dc3-4cb2-ac29-7f14b3bdcabc";

        internal System.Net.Http.HttpResponseMessage RequestNoAutorizado(string message)
        {
            var resp = new System.Net.Http.HttpResponseMessage();
            resp.Content = new System.Net.Http.StringContent(message);
            resp.StatusCode = System.Net.HttpStatusCode.Unauthorized;
            return resp;
        }

        internal bool ValidarAutorizacion()
        {
            var req = System.Web.HttpContext.Current.Request;
            var token = req.Headers["Authorization"].Replace("Bearer ", "");
            return LocalToken == token;
        }

        internal System.Net.Http.HttpResponseMessage ErrorResponse_Ex(Exception ex)
        {
            return ErrorResponse(ex.Message);
        }

        internal System.Net.Http.HttpResponseMessage OkResponse(object result)
        {
            var resp = new System.Net.Http.HttpResponseMessage();
            resp.Content = new System.Net.Http.ObjectContent(result.GetType(), result, DefaultFormatter);
            resp.StatusCode = System.Net.HttpStatusCode.OK;
            return resp;
        }
    }
}
