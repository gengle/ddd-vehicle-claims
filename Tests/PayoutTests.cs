using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class PayoutTests
    {
        [TestMethod]
        public void ToString_IncludesDollar()
        {
            Assert.AreEqual("$0.00", Payout.Zilch.ToString());
        }
    }
}
