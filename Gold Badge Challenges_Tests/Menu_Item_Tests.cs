using System;
using Gold_Badge_Challenges_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gold_Badge_Challenges_Tests
{
    [TestClass]
    public class Menu_Item_Tests
    {
        [TestMethod]
        // Testing Property
        public void TestingProperiesAreEqual()
        {
            Menu_Item item = new Menu_Item();
            item.MealName = "Royale With Cheese";

            string expected = "Royale With Cheese";
            string actual = item.MealName;

            Assert.AreEqual(expected, actual);
        }
    }
}
