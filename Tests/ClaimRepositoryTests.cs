using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Factories;
using Domain.Infrastructure.Persistance;
using Domain.Infrastructure.Persistance.EntityFramework;
using Domain.Repositories;
using Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace Tests
{
    [TestClass]
    public class ClaimRepositoryTests
    {
        private IWorkspace _ws;
        private IClaimRepository _unitUnderTest;

        [TestInitialize]
        public void Init()
        {
            //_ws = new FakeWorkspace(Path.GetTempFileName());
            _ws = new EFWorkspace(new EFContext());
            _unitUnderTest = new ClaimRepository(_ws, new ClaimFactory());
        }

        [TestMethod]
        public void AddAndCommitWorkspace()
        {
            var id = ClaimId.NewId();
            var claim = _unitUnderTest.GetById(id);
            _unitUnderTest.AddOrUpdate(claim);
            _ws.Commit();
        }

        [TestMethod]
        public void AddAndCommitWorkspaceAndReload()
        {
            var id = ClaimId.NewId();
            var claim = _unitUnderTest.GetById(id);
            _ws.Commit();

            var reloaded = _unitUnderTest.GetById(id);

            Assert.AreEqual(claim, reloaded);
        }

        [TestMethod]
        public void CommitTwiceAfterChanges()
        {
            var id = ClaimId.NewId();
            var claim = _unitUnderTest.GetById(id);
            var policyService = new Mock<IPolicyService>();
            var vehicleService = new Mock<IVehicleService>();

            var expectedPolicy = new PolicyNo("1234");
            claim.AssignPolicy(expectedPolicy, policyService.Object);
            _unitUnderTest.AddOrUpdate(claim);
            _ws.Commit();

            var reloaded = _unitUnderTest.GetById(id);
            var expectedVehicle = new Vehicle("Ford");
            reloaded.AssignVehicle(expectedVehicle, vehicleService.Object);
            _unitUnderTest.AddOrUpdate(reloaded);
            _ws.Commit();

            reloaded = _unitUnderTest.GetById(id);

            Assert.AreEqual(expectedPolicy, reloaded.PolicyNo);
            Assert.AreEqual(expectedVehicle, reloaded.Vehicle);
        }
    }
}
