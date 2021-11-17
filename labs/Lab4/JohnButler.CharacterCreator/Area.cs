﻿/*========================
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
    public class Area
    {
        /// <summary> Gets or sets the area id. </summary>
        public int Id { get; set; }

        /// <summary> Gets or sets the area description. </summary>
        public string Description { get; set; }

        /// <summary> Gets or sets an array of accessible area ids. </summary>
        public int[] AccessibleIds { get; set; }

        public Area Clone ()
        {
            var area = new Area();
            area.Id = Id;
            area.Description = Description;
            int index = 0;

            foreach (var a in AccessibleIds)
                area.AccessibleIds[index++] = a;

            return area;
        }
    }
}
