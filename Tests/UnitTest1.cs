using System;
using System.Security.Claims;
using Domain;
using Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var manager = new ClaimManager();

            var id = ClaimId.NewId();

            var policyNo = PolicyNo.FromString("XYZ");
            
            var policy = new PolicyInfo(new PolicyNo("XYZ"));
            var claim = new Domain.Claim(id)
                .AssignPolicy(new PolicyInfo(PolicyNo = new PolicyNo("XYZ")});




            //var id = ClaimId.NewId();
            //var claim = new Domain.Claim(id);
        }
    }
}
