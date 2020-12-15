using System;
using _02_Komodo_Claims_Department_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Komodo__Claims_Department_Tests
{
    [TestClass]
    public class Claims_Tests
    {
        [TestMethod]
        public void TestingPropertiesAreEqual()
        {
            Claim claim = new Claim();
            claim.ClaimId = "1";

            string expected = "1";
            string actual = claim.ClaimId;

            Assert.AreEqual(expected, actual);
        }
    }
}
