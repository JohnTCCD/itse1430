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
    /// <summary> Represents an area in the game. </summary>
    class Area
    {
        /// <summary> Gets or sets the area id. </summary>
        public int Id { get; set; }

        /// <summary> Gets or sets the area description. </summary>
        public string Description { get; set; }

        private List<int> _accessible = new List<int>();


    }
}
