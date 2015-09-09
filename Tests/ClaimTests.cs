using System;
using System.Linq;
using System.Security.Claims;
using Domain;
using Domain.Services;
using Domain.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Claim = Domain.Claim;

namespace Tests
{
    [TestClass]
    public class ClaimTests
    {
        private Mock<IPolicyService> _policyService;

        [TestInitialize]
        public void Init()
        {
            _policyService = new Mock<IPolicyService>();
            _policyService.Setup(x => x.GenerateClaimNo(It.IsAny<PolicyNo>())).Returns((PolicyNo x) => new ClaimNo(x.Value + "1"));
        }

        [TestMethod]
        public void NewClaim_ClaimId_AreEqual()
        {
            var expected = ClaimId.NewId();

            var claim = new Claim(expected);
            var actual = claim.Id;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AssignPolicy_PolicyNo_AreEqual()
        {
            var claimId = ClaimId.NewId();
            var claim = new Claim(claimId);

            var expected = PolicyNo.FromString("PO123");
            claim.AssignPolicy(expected, _policyService.Object);
            var actual = claim.PolicyNo;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AssignPolicy_ClaimNo_AreNotEmpty()
        {
            var claimId = ClaimId.NewId();
            var claim = new Claim(claimId);

            var policyNo = PolicyNo.FromString("PO123");
            claim.AssignPolicy(policyNo, _policyService.Object);

            Assert.AreNotEqual(ClaimNo.Empty, claim.ClaimNo);
        }

        [TestMethod]
        [ExpectedException(typeof(ClaimException))]
        public void AssignPolicyTwice_WithDifferentPolicyNo_Throws()
        {
            var claimId = ClaimId.NewId();

            var claim = new Claim(claimId);

            claim.AssignPolicy(PolicyNo.FromString("PO1"), _policyService.Object);
            claim.AssignPolicy(PolicyNo.FromString("PO2"), _policyService.Object);
        }

        [TestMethod]
        public void AssignPolicyTwice_WithSamePolicyNo_Ignores()
        {
            var claimId = ClaimId.NewId();

            var claim = new Claim(claimId);

            claim.AssignPolicy(PolicyNo.FromString("PO1"), _policyService.Object);
            claim.AssignPolicy(PolicyNo.FromString("PO1"), _policyService.Object);

            _policyService.Verify(x=>x.GenerateClaimNo(It.IsAny<PolicyNo>()), Times.Once());
        }

        [TestMethod]
        public void AssignVehicle_AddsUnit()
        {
            var claimId = ClaimId.NewId();
            var claim = new Claim(claimId);

            var vehicle = new Vehicle(make: "Ford", model: "Mustang", year:2015, vin:"1YX");
            var fairMarketService = new Mock<IFairMarketValueService>();
            fairMarketService.Setup(x => x.GetValue(It.IsAny<Vehicle>())).Returns(0m);

            claim.AssignVehicle(vehicle, fairMarketService.Object);

            Assert.AreEqual(1, claim.Units.Count);
        }

        [TestMethod]
        public void AssignSameVehicleTwice_DoesNothing()
        {
            var claimId = ClaimId.NewId();
            var claim = new Claim(claimId);

            var vehicle = new Vehicle(make: "Ford", model: "Mustang", year: 2015, vin: "1YX");
            var fairMarketService = new Mock<IFairMarketValueService>();
            fairMarketService.Setup(x => x.GetValue(It.IsAny<Vehicle>())).Returns(0m);

            claim.AssignVehicle(vehicle, fairMarketService.Object);
            claim.AssignVehicle(vehicle, fairMarketService.Object);

            Assert.AreEqual(1, claim.Units.Count);
        }

        [TestMethod]
        public void AssignVehicle_AlsoAssignsMonetaryAssessment()
        {
            var claimId = ClaimId.NewId();
            var claim = new Claim(claimId);

            var vehicle = new Vehicle(make: "Ford", model: "Mustang", year: 2015, vin: "1YX");
            var fairMarketService = new Mock<IFairMarketValueService>();
            var expected = 1.5m;
            fairMarketService.Setup(x => x.GetValue(It.IsAny<Vehicle>())).Returns(expected);

            claim.AssignVehicle(vehicle, fairMarketService.Object);

            var actual = claim.Units.First().MonetaryAssessment;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PendingPayout_AfterAssignVehicle_AreEqual()
        {
            var claimId = ClaimId.NewId();
            var claim = new Claim(claimId);

            var vehicle = new Vehicle(make: "Ford", model: "Mustang", year: 2015, vin: "1YX");
            var fairMarketService = new Mock<IFairMarketValueService>();
            var expected = 1.5m;
            fairMarketService.Setup(x => x.GetValue(It.IsAny<Vehicle>())).Returns(expected);

            claim.AssignVehicle(vehicle, fairMarketService.Object);
            var actual = claim.PendingPayout.Amount;

            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void PendingPayout_WithNoVehicles_ReturnsZero()
        {
            var claimId = ClaimId.NewId();
            var claim = new Claim(claimId);

            var actual = claim.PendingPayout.Amount;

            Assert.AreEqual(0m, actual);
        }

        [TestMethod]
        public void ProcessPayout_CallsUnderwritingService()
        {
            var claimId = ClaimId.NewId();
            var claim = new Claim(claimId);
            var fairMarketService = new Mock<IFairMarketValueService>();
            var underWritingService = new Mock<IUnderwritingService>();
            var vehicle = new Vehicle(make: "Ford", model: "Mustang", year: 2015, vin: "1YX");
            var expected = 1.5m;

            fairMarketService.Setup(x => x.GetValue(It.IsAny<Vehicle>())).Returns(expected);
            underWritingService.Setup(x => x.ProcessPayout(It.IsAny<PolicyNo>(), It.IsAny<Payout>()));
            claim.AssignVehicle(vehicle, fairMarketService.Object);

            claim.ProcessPayout(new Payout(expected), underWritingService.Object);
            
            underWritingService.Verify(x=>x.ProcessPayout(It.IsAny<PolicyNo>(), It.IsAny<Payout>()));
        }

        [TestMethod]
        public void ProcessPayout_RecordsSuccessfulPayout()
        {
            var claimId = ClaimId.NewId();
            var claim = new Claim(claimId);
            var fairMarketService = new Mock<IFairMarketValueService>();
            var underWritingService = new Mock<IUnderwritingService>();
            var vehicle = new Vehicle(make: "Ford", model: "Mustang", year: 2015, vin: "1YX");
            var expected = 1.5m;

            fairMarketService.Setup(x => x.GetValue(It.IsAny<Vehicle>())).Returns(expected);
            underWritingService.Setup(x => x.ProcessPayout(It.IsAny<PolicyNo>(), It.IsAny<Payout>()));
            claim.AssignVehicle(vehicle, fairMarketService.Object);

            claim.ProcessPayout(new Payout(expected), underWritingService.Object);
            var actual = claim.Payouts.Sum(x => x.Amount);
            
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void ProcessPayout_PendingPayout_AreEquals0m()
        {
            var claimId = ClaimId.NewId();
            var claim = new Claim(claimId);
            var fairMarketService = new Mock<IFairMarketValueService>();
            var underWritingService = new Mock<IUnderwritingService>();
            var vehicle = new Vehicle(make: "Ford", model: "Mustang", year: 2015, vin: "1YX");
            var expected = 1.5m;

            fairMarketService.Setup(x => x.GetValue(It.IsAny<Vehicle>())).Returns(expected);
            underWritingService.Setup(x => x.ProcessPayout(It.IsAny<PolicyNo>(), It.IsAny<Payout>()));
            claim.AssignVehicle(vehicle, fairMarketService.Object);

            claim.ProcessPayout(new Payout(expected), underWritingService.Object);
            Assert.AreEqual(0m, claim.PendingPayout.Amount);
        }
    }
}
