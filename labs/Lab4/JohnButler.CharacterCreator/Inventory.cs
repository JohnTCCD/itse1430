/*========================
John Butler
ITSE 1430 Fall 2021
Lab 4
========================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnButler.AdventureGame
{
    /// <summary> Holds a collection of items. </summary>
    public class Inventory
    {
        private List<Item> _items = new List<Item>();

        /// <summary> Adds an item to the player's inventory. </summary>
        /// <param name="item"> Item to be added. </param>
        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        /// <summary> Gets the item of the name specified. </summary>
        /// <returns> Items if not null. </returns>
        public IEnumerable<Item> GetAllItems()
        {
            if (_items != null)
                return _items;

            return null;
        }

        /// <summary> Gets the total weight of all items in inventory. </summary>
        /// <returns> The total weight in pounds. </returns>
        public int GetTotalWeight()
        {
            int total = 0;
            foreach (var item in _items)
                total += item.Weight;

            return total;
        }
    }
}
