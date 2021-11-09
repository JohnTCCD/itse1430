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
    /// <summary> Represents a wolrd of the game. </summary>
    public class GameWorld : World
    {
        /// <summary> Creates and adds the nine areas to the game. </summary>
        public GameWorld ()
        {
            var areas = new[]
            {
                new Area() {
                    Id = 1,
                    Description = "Guest Room",
                    AccessibleIds = new[] { 2, 4 },
                },
                new Area() {
                    Id = 2,
                    Description = "Dinning Room",
                    AccessibleIds = new[] { 1, 3, 5 },
                },
                new Area() {
                    Id = 3,
                    Description = "Master Bedroom",
                    AccessibleIds = new[] { 2, 6 },
                },
                new Area() {
                    Id = 4,
                    Description = "Fire Place",
                    AccessibleIds = new[] { 1, 5, 7 },
                },
                new Area() {
                    Id = 5,
                    Description = "Kitchen",
                    AccessibleIds = new[] { 2, 6, 8, 4 },
                },
                new Area() {
                    Id = 6,
                    Description = "Balcony",
                    AccessibleIds = new[] { 3, 5, 9 },
                },
                new Area() {
                    Id = 7,
                    Description = "Art Gallery",
                    AccessibleIds = new[] { 4, 8 },
                },
                new Area() {
                    Id = 8,
                    Description = "Entrance",
                    AccessibleIds = new[] { 7, 5, 9 },
                },
                new Area() {
                    Id = 9,
                    Description = "Cellar",
                    AccessibleIds = new[] { 8, 6 },
                },
            };

            foreach (var area in areas)
                if (area != null)
                    AddArea(area);
        }


        /// <summary> Adds areas to the game world. </summary>
        /// <param name="areas"> Areas to add. </param>
        //public void AddAreasToGame (Area[] areas)
        //{
        //    foreach (var area in areas)
        //    {
        //        if (area != null)
        //            AddArea(area);
        //    }
        //}
    }
}
