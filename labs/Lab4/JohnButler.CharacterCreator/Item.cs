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
    /// <summary> Represents an item the player may carry. </summary>
    class Item
    {
        /// <summary> Gets or sets the name of the item. </summary>
        public string Name { get; set; }

        /// <summary> Gets or sets the monetary value of the item. </summary>
        public int Value { get; set; }

        /// <summary> Gets or sets the weight(pounds) of the item. </summary>
        public int Weight { get; set; }
    }
}
