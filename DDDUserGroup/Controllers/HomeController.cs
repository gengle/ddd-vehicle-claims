using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Repositories;
using Domain.Services;

namespace DDDUserGroup.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IClaimRepository _claimRepository;

        public HomeController(ICommandDispatcher commandDispatcher, IClaimRepository claimRepository)
        {
            _commandDispatcher = commandDispatcher;
            _claimRepository = claimRepository;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
