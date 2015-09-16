using Core;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DDDUserGroup.Controllers
{
    public class CommandsController : ApiController
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public CommandsController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        public IHttpActionResult Post([FromBody] ICommand command)
        {
            //try
            //{
            _commandDispatcher.Dispatch(command);
            return Ok();
            //}
            //catch (Exception ex)
            //{

            //}
        }
    }
}