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
using Domain.States;
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
        public void CreateClaim()
        {
            var id = ClaimId.NewId();
            _unitUnderTest.Dispatch(new CreateClaimCommand() { Id = id});

            var actual = _claimRepository.GetAll().First();

            Assert.AreEqual(id, actual.Id);
        }

        [TestMethod]
        public void CreateClaim_ThenAssignVehicle()
        {
            var id = ClaimId.NewId();
            _unitUnderTest.Dispatch(new CreateClaimCommand() { Id = id });

            var expected = new Vehicle(make:"Ford", model:"Mustang", vin:"12345", year:2015);
            _unitUnderTest.Dispatch(new AssignVehicleCommand()
            {
                Id = id,
                Vehicle = expected
            });

            var actual = _claimRepository.GetAll().First();

            Assert.AreEqual(expected, actual.Vehicle);
        }

        [TestMethod]
        public void AssignVehicle_ThenRejectPayout()
        {
            var id = ClaimId.NewId();
            _unitUnderTest.Dispatch(new CreateClaimCommand() { Id = id });
            _unitUnderTest.Dispatch(new AssignVehicleCommand()
            {
                Id = id,
                Vehicle = new Vehicle(make: "Ford", model: "Mustang", vin: "12345", year: 2015)
            });
            _unitUnderTest.Dispatch(new RejectPayoutCommand() { Id = id});

            var actual = _claimRepository.GetById(id);

            Assert.AreEqual(Payout.Zilch, actual.Payout);
        }

        [TestMethod]
        public void RejectPayout_ThenCloseClaim()
        {
            var id = ClaimId.NewId();
            _unitUnderTest.Dispatch(new CreateClaimCommand() { Id = id });
            _unitUnderTest.Dispatch(new AssignVehicleCommand()
            {
                Id = id,
                Vehicle = new Vehicle(make: "Ford", model: "Mustang", vin: "12345", year: 2015)
            });
            _unitUnderTest.Dispatch(new RejectPayoutCommand() { Id = id });
            _unitUnderTest.Dispatch(new CloseClaimCommand() { Id = id });

            var actual = _claimRepository.GetById(id);

            Assert.IsInstanceOfType(actual._state, typeof(ClosedClaim));
        }

        [TestMethod]
        public void AssignVehicle_ThenApprovePayout()
        {
            var id = ClaimId.NewId();
            _unitUnderTest.Dispatch(new CreateClaimCommand() { Id = id });
            _unitUnderTest.Dispatch(new AssignVehicleCommand()
            {
                Id = id,
                Vehicle = new Vehicle(make: "Ford", model: "Mustang", vin: "12345", year: 2015)
            });
            var expected = 5m;
            _unitUnderTest.Dispatch(new ApprovePayoutCommand() { Id = id, Amount =expected});

            var actual = _claimRepository.GetById(id);

            Assert.AreEqual(expected, actual.Payout);
        }

        [TestMethod]
        public void ApprovePayout_ThenCloseClaim()
        {
            var id = ClaimId.NewId();
            _unitUnderTest.Dispatch(new CreateClaimCommand() { Id = id });
            _unitUnderTest.Dispatch(new AssignVehicleCommand()
            {
                Id = id,
                Vehicle = new Vehicle(make: "Ford", model: "Mustang", vin: "12345", year: 2015)
            });
            _unitUnderTest.Dispatch(new ApprovePayoutCommand() { Id = id, Amount = 5m });
            _unitUnderTest.Dispatch(new CloseClaimCommand() { Id = id});

            var actual = _claimRepository.GetById(id);

            Assert.IsInstanceOfType(actual._state, typeof(ClosedClaim));
        }
    }
}
