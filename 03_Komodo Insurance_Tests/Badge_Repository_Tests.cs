using System;
using System.Collections.Generic;
using _03_Komodo_Insurance_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Komodo_Insurance_Tests
{
    [TestClass]
    public class Badge_Repository_Tests
    {
        private Dictionary<int, Badge> _badgeList = new Dictionary<int, Badge>();
        private Badge_Repository _badgeRepo = new Badge_Repository();
        private Badge _badge = new Badge();

        // Create Method Test
        [TestMethod]
        public void AddBadge_ShouldGetNotNull()
        {
            // Arrange
            _badgeRepo.AddBadge(1, _badge);

            // Act
            Dictionary<int, Badge> badgeFromDictionary = _badgeRepo.GetBadges();

            // Assert
            Assert.IsNotNull(badgeFromDictionary);

        }
    }
}
