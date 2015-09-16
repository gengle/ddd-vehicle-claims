using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Application.Messaging.Commands;
using Application.Services;
using Core;
using Newtonsoft.Json;

namespace DDDUserGroup.Controllers
{
    public class JsonResult : IHttpActionResult
    {
        object _value;
        HttpRequestMessage _request;

        public JsonResult(object value, HttpRequestMessage request)
        {
            _value = value;
            _request = request;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var formatter = new JsonMediaTypeFormatter();
            formatter.SerializerSettings.TypeNameHandling = TypeNameHandling.None;
            formatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            var response= _request.CreateResponse(HttpStatusCode.OK, _value, formatter);
            
            return Task.FromResult(response);
        }
    }

    [RoutePrefix("api/claims")]
    public class ClaimsController : ApiController
    {
        private readonly ClaimReader _claimReader;

        public ClaimsController(ClaimReader claimReader)
        {
            _claimReader = claimReader;
        }

        // /api/claims
        public IHttpActionResult GetAllClaims()
        {
            var data = _claimReader.GetAll();
            return new JsonResult(data, Request);
        }

        // /api/claims/{id}
        public IHttpActionResult GetClaim(string id)
        {
            return Ok(_claimReader.GetById(id));
        }
    }
}
