using System;
using System.Collections.Generic;
using _03_Komodo_Insurance_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Komodo_Insurance_Tests
{
    [TestClass]
    public class Badge_Repository_Tests
    {
        private Badge_Repository _badgeRepo;
        private Badge _badge;

        [TestInitialize]
        public void Arrange()
        {
            _badgeRepo = new Badge_Repository();
            _badge = new Badge(12, new List<string> { "A6", "A9" });
            _badgeRepo.AddBadge(12, _badge); 
        }

        // Create Method Test
        [TestMethod]
        public void AddBadge_ShouldGetNotNull()
        {
            // Arrange
            Dictionary<int, Badge> badgeList =_badgeRepo.GetBadges();
            int numberOne = badgeList.Count;
            _badgeRepo.AddBadge(1, _badge);

            // Act
            badgeList = _badgeRepo.GetBadges();
            int numberTwo = badgeList.Count;

            // Assert
            Assert.AreNotEqual(numberOne, numberTwo);

        }

        [TestMethod]
        public void ReadMethod_ShouldGetNull()
        {
            // Arrange
            // Act
            Dictionary<int, Badge> badgeFromDirectory = _badgeRepo.GetBadges();

            // Assert
            Assert.IsNotNull(badgeFromDirectory);
        }

        [TestMethod]
        public void UpdateExistingBadge_ShouldReturnTrue()
        {
            // Arrange
            // TestInitialize
            Badge newBadge = new Badge(12, new List<string> { "A6", "A7" });

            // Act
            bool updateResult = _badgeRepo.UpdateExistingBadge(12, newBadge);

            // Assert
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void GetBadgeById_ShouldGetNotNull()
        {
            // Arrange
            // Test Initialize

            // Act
            Badge result =_badgeRepo.GetBadgeByID(12);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
