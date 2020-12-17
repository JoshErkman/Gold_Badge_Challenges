using System;
using System.Collections.Generic;
using _02_Komodo_Claims_Department_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Komodo__Claims_Department_Tests
{
    [TestClass]
    public class Claims_Repository_Tests
    {
        private Claims_Repository _repo = new Claims_Repository();
        private Claim _claim = new Claim();

        [TestMethod]
        // Create
        public void AddClaimToQueue_ShouldGetNotNull()
        {
            // Arrange
            _repo.AddClaim(_claim);

            // Act
            Queue<Claim> claimFromQueue = _repo.GetClaims();

            // Assert
            Assert.IsNotNull(claimFromQueue);
        }

        // Take Care of next claim
        [TestMethod]
        public void TakeCareOfNextClaim_ShouldGetNull()
        {
            // Arrange
            _repo.AddClaim(_claim);
            _repo.TakeCareOfClaim();

            // Act
            Queue<Claim> claimFromQueue = _repo.GetClaims();

            // Assert
            Assert.AreEqual(0, claimFromQueue.Count);
        }

        // Read Method
        [TestMethod]
        public void ReadMethod_ShouldGetNotNull()
        {
            // Arrange
            _repo.AddClaim(_claim);

            // Act
            Queue<Claim> claims = _repo.GetClaims();

            // Assert
            Assert.IsNotNull(claims);
        }

        [TestMethod]
        public void ViewNextClaim_ShouldBeEqual()
        {
            // Arrange
            _repo.AddClaim(_claim);

            // Act
            Claim claim = _repo.ViewNextClaim();

            // Assert
            Assert.AreEqual(_claim, claim);
        }
    }
}
