using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ClaimFactoryTests
    {
        private ClaimFactory _unitUnderTest;

        [TestInitialize]
        public void Init()
        {
            _unitUnderTest = new ClaimFactory();    
        }

        [TestMethod]
        public void FromMemento()
        {
            var id = ClaimId.NewId();
            var expected = new Claim(id);

            var actual = _unitUnderTest.FromMemento(expected.GetMemento());

            Assert.AreEqual(expected, actual);
        }
    }
}
