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
    /// <summary> Represents a world. </summary>
    public class World
    {
        private List<Area> _areas = new List<Area>();

        /// <summary> Adds a new area. </summary>
        /// <param name="area"> Area to add. </param>
        protected void AddArea (Area area)
        {
            _areas.Add(area);
        }

        /// <summary> Finds an area by its Id. </summary>
        /// <param name="id"> Id of the area to find. </param>
        /// <returns> Area of specified area if true, null if false. </returns>
        public Area FindAreaById (int id)
        {
            foreach (var area in _areas)
                if (id == area.Id)
                    return area;

            return null;
        }

        /// <summary> Gets all available areas. </summary>
        /// <returns> A copy of a array of all available areas. </returns>
        public Area[] GetAllAreas ()
        {
            var count = 0;

            foreach (var area in _areas)
            {
                if (area != null)
                    ++count;
            }

            var areas = new Area[count];
            var index = 0;

            foreach (var area in _areas)
            {
                if (area != null)
                    areas[index++] = area.Copy();
            }

            return areas;
        }

        /// <summary> Identifies the starting area for the game. </summary>
        /// <returns> Area the game starts with. </returns>
        public Area FindStartingArea ()
        {
            foreach (var area in _areas)
            {
                if (area.Id == 8)
                    return area;
            }

            return null;
        }
    }
}
