using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Domain.Commands;
using Domain.Repositories;
using Domain.Services;

namespace DDDUserGroup.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IClaimRepository _claimRepository;
        private readonly IWorkspace _workspace;

        public HomeController(ICommandDispatcher commandDispatcher, IClaimRepository claimRepository, IWorkspace workspace)
        {
            _commandDispatcher = commandDispatcher;
            _claimRepository = claimRepository;
            _workspace = workspace;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            var id = ClaimId.NewId();
            _commandDispatcher.Dispatch(new CreateClaimCommand() { Id = id, PolicyNo = "1234"});
            _commandDispatcher.Dispatch(new AssignVehicleCommand(){Id = id,Vehicle = new Vehicle(make: "Ford", model: "Mustang")});
            
            return View();
        }
    }
}
