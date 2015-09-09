using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Domain;
using Domain.Commands;
using Domain.Infrastructure;
using Domain.Infrastructure.Modules;
using Domain.Repositories;
using Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AutofacCommandDispatcherTests
    {
        private ICommandDispatcher _unitUnderTest;
        private IClaimRepository _claimRepository;

        [TestInitialize]
        public void Init()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new CoreModule() { UseMemoryMode = true});
            builder.RegisterModule(new CommandModule());

            var container = builder.Build();

            _claimRepository = container.Resolve<IClaimRepository>();
            _unitUnderTest = container.Resolve<ICommandDispatcher>();
        }

        [TestMethod]
        public void CreateClaim_PolicyNo_AreEqual()
        {
            var id = ClaimId.NewId();
            var expected = "123";

            _unitUnderTest.Dispatch(new CreateClaimCommand()
            {
                Id = id.ToString(),
                PolicyNo = expected
            });

            var actual = _claimRepository.GetById(id).PolicyNo.Value;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateClaim_ClaimNo_AreNotEmpty()
        {
            var id = ClaimId.NewId();

            _unitUnderTest.Dispatch(new CreateClaimCommand()
            {
                Id = id.ToString(),
                PolicyNo = "123"
            });

            var actual = _claimRepository.GetById(id);
            Assert.AreNotEqual(ClaimNo.Empty, actual.ClaimNo);
        }

        [TestMethod]
        public void AssignVehicle_Make_AreEqual()
        {
            var id = ClaimId.NewId();

            _unitUnderTest.Dispatch(new CreateClaimCommand()
            {
                Id = id.ToString(),
                PolicyNo = "123"
            });

            _unitUnderTest.Dispatch(new AssignVehicleCommand()
            {
                Id = id.ToString(),
                Make="Ford",
                Model="Mustang",
                Vin="1Z2",
                Year = 2015
            });

            var actual = _claimRepository.GetById(id).Units.ElementAt(0);
            Assert.AreEqual("Ford", actual.Vehicle.Make);
        }

        [TestMethod]
        public void ProcessPayout()
        {
            var id = ClaimId.NewId();

            _unitUnderTest.Dispatch(new CreateClaimCommand()
            {
                Id = id.ToString(),
                PolicyNo = "123"
            });

            _unitUnderTest.Dispatch(new AssignVehicleCommand()
            {
                Id = id.ToString(),
                Make = "Ford",
                Model = "Mustang",
                Vin = "1Z2",
                Year = 2015
            });

            var expected = 5.00m;
            _unitUnderTest.Dispatch(new ProcessPayoutCommand
            {
                Id = id.ToString(),
                Amount =expected
            });

            var actual = _claimRepository.GetById(id).Payouts.Sum(x=>x.Amount);
            Assert.AreEqual(expected, actual);
        }
    }
}
