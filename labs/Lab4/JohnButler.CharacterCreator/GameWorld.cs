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
        
        public GameWorld ()
        {
            var areas = new[]
            {
                new Area() {
                    Id = 1,
                    Description = "Guest Room",
                    AccessibleIds = new int[2],
                },
                new Area() {
                    Id = 2,
                    Description = "Dinning Room",
                    AccessibleIds = new int[3],
                },
                new Area() {
                    Id = 3,
                    Description = "Master Bedroom",
                    AccessibleIds = new int[2],
                },
                new Area() {
                    Id = 4,
                    Description = "Fire Place",
                    AccessibleIds = new int[3],
                },
                new Area() {
                    Id = 5,
                    Description = "Kitchen",
                    AccessibleIds = new int[4],
                },
                new Area() {
                    Id = 6,
                    Description = "Balcony",
                    AccessibleIds = new int[3],
                },
                new Area() {
                    Id = 7,
                    Description = "Art Gallery",
                    AccessibleIds = new int[2],
                },
                new Area() {
                    Id = 8,
                    Description = "Entrance",
                    AccessibleIds = new int[3],
                },
                new Area() {
                    Id = 9,
                    Description = "Cellar",
                    AccessibleIds = new int[2],
                },
            };
        }


        /// <summary> Adds areas to the game world. </summary>
        /// <param name="areas"> Areas to add. </param>
        public void AddAreasToGame (Area[] areas)
        {
            foreach (var area in areas)
            {
                if (area != null)
                    AddArea(area);
            }
        }
    }
}
