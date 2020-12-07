using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Badge_Challenges_Repository
{
    public class Menu_Repository
    {
        private List<Menu_Item> _ListOfMenuItems = new List<Menu_Item>();

        // Create
        public void AddMenuItem(Menu_Item menuItem)
        {
            _ListOfMenuItems.Add(menuItem);
        }

        // Read
        public List<Menu_Item> GetMenu()
        {
            return _ListOfMenuItems;
        }


        // Delete

        public bool RemoveItemFromMenu(string mealNumber)
        {
            Menu_Item item = GetMenuItemByMealNumber(mealNumber);
            if(item == null)
            {
                return false;
            }

            int initialCount = _ListOfMenuItems.Count;
            _ListOfMenuItems.Remove(item);

            if(initialCount > _ListOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // Helper Method
        public Menu_Item GetMenuItemByMealNumber(string mealNumber)
        {
            foreach(Menu_Item item in _ListOfMenuItems)
            {
                if(item.MealNumber == mealNumber)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
