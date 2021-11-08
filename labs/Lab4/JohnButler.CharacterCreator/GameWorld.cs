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
                    Description = "Master Bedroom",
                    AccessibleIds = new int[1],
                }
                //TODO: Add the rest of the areas.
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
