using System;
using System.Collections.Generic;
using Gold_Badge_Challenges_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gold_Badge_Challenges_Tests
{
    [TestClass]
    public class Menu_Repository_Tests
    {
        private Menu_Repository _repo = new Menu_Repository();
        private Menu_Item _item;

        // Create Method
        [TestMethod]
        public void AddMenuItemToList_ShouldGetNotNull()
        {
            // Arrange --> Setting up the playing field
            Menu_Item item = new Menu_Item();
            item.MealNumber = "7";

            // Act --> Get/Run the code we want to test
            _repo.AddMenuItem(item);
            Menu_Item itemFromDirectory = _repo.GetMenuItemByMealNumber("7");

            // Assert --> Use the assert class to verify the expected outcome
            Assert.IsNotNull(itemFromDirectory);

        }

        // Delete Method
        [TestMethod]
        public void DeleteMenuItem_ShouldGetTrue()
        {
            // Arrange
            Menu_Item item = new Menu_Item();
            item.MealNumber = "10";
            _repo.AddMenuItem(item);


            // Act
            bool deleteResult = _repo.RemoveItemFromMenu("10");

            // Assert
            Assert.IsTrue(deleteResult);
        }

        // Read Method
        [TestMethod]
        public void ReadMenu_ShouldGetIsNotNull()
        {
            // Arrange
            Menu_Item item = new Menu_Item();
            item.MealNumber = "11";
            _repo.AddMenuItem(item);

            // Act
            List<Menu_Item> itemFromMenu = _repo.GetMenu();

            // Assert
            Assert.IsNotNull(itemFromMenu);
        }
    }
}
