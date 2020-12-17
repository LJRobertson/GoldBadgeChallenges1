using System;
using System.Collections.Generic;
using _01_Challenge1Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Challenge1CafeTests
{
    [TestClass]
    public class CafeRepoTests
    {
        private MenuItemRepo _repo; 
        private MenuItem _item;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuItemRepo();  
            _item = new MenuItem(1, "Sub Sandwhich", "sub sandwhich and chips", new List<string> { "bread", "turkey", "cheese", "lettuce", "tomato" }, 9.95);
            
            _repo.AddMenuItemToList(_item);
        }

        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            //Arrange
            MenuItem item = new MenuItem();
            item.MealNumber = 7;
            MenuItemRepo repo = new MenuItemRepo();

            //Act
            repo.AddMenuItemToList(item);
            MenuItem itemFromRepo = repo.GetMenuItemByNumber(7);

            //Assert
            Assert.IsNotNull(itemFromRepo);
        }

        [TestMethod]
        public void ReturnItemList_ShouldBeNotNull()
        {
            //Arrange

            //Act
            List<MenuItem> testList = _repo.GetMenuList();
            
            //Assert
            Assert.IsNotNull(testList);
        }

        [TestMethod]
        public void DeleteItem_ShouldReturnTrue()
        {
            //Arrange

            //Act
            bool deleteItem = _repo.RemoveMenuItemFromList(_item.MealNumber);

            //Assert
            Assert.IsTrue(deleteItem);
        }

        [TestMethod]
        public void GetMenuItemByNumber_ShouldBeEqual()
        {
            // Arrange

            //Act
            MenuItem item = _repo.GetMenuItemByNumber(1);
            int mealNumber = item.MealNumber;
            
            //Assert
            Assert.AreEqual(1, mealNumber);
        }
    }
}
