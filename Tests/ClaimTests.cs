using System;
using System.Linq;
using System.Security.Claims;
using Domain;
using Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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

            var claim = new Domain.Claim(expected);
            var actual = claim.Id;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AssignPolicy_PolicyNo_AreEqual()
        {
            var claimId = ClaimId.NewId();
            var claim = new Domain.Claim(claimId);

            var expected = PolicyNo.FromString("PO123");
            claim.AssignPolicy(expected, _policyService.Object);
            var actual = claim.PolicyNo;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AssignPolicy_ClaimNo_AreNotEmpty()
        {
            var claimId = ClaimId.NewId();
            var claim = new Domain.Claim(claimId);

            var policyNo = PolicyNo.FromString("PO123");
            claim.AssignPolicy(policyNo, _policyService.Object);

            Assert.AreNotEqual(ClaimNo.Empty, claim.ClaimNo);
        }

        [TestMethod]
        [ExpectedException(typeof(Core.DomainException))]
        public void AssignPolicyTwice_WithDifferentPolicyNo_Throws()
        {
            var claimId = ClaimId.NewId();

            var claim = new Domain.Claim(claimId);

            claim.AssignPolicy(PolicyNo.FromString("PO1"), _policyService.Object);
            claim.AssignPolicy(PolicyNo.FromString("PO2"), _policyService.Object);
        }
    }
}
