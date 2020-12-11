using System;
using Gold_Badge_Challenges_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gold_Badge_Challenges_Tests
{
    [TestClass]
    public class CafeTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Menu_Item item = new Menu_Item();
            item.MealName = "Royale With Cheese";

            string expected = "Royale With Cheese";
            string actual = item.MealName;

            Assert.AreEqual(expected, actual);
        }
    }
}
