using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Application.Services;

namespace DDDUserGroup.Controllers
{
    [RoutePrefix("api/Commands")]
    public class CommandsController : ApiController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly ClaimReader _claimReader;

        public CommandsController(ICommandDispatcher commandDispatcher, ClaimReader claimReader)
        {
            _commandDispatcher = commandDispatcher;
            _claimReader = claimReader;
        }

        [HttpPost]
        [Route("Execute")]
        public IHttpActionResult ExecuteCommand([FromBody] ICommand command)
        {
            _commandDispatcher.Dispatch(command);
            return Ok(_claimReader.GetById(command.Id));
        }
    }
}