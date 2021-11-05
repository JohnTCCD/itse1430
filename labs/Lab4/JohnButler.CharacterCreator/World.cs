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
    /// <summary> Represents the world of the game. </summary>
    class World
    {
        private List<Area> _areas = new List<Area>();

        public void AddArea (Area area)
        {
            _areas.Add(area);
        }

        public Area FindAreaById (int id)
        {
            foreach (var area in _areas)
                if (id == area.Id)
                    return area;

            return null;
        }

       //public Area GetAllAreas ()
       // {
       //     IEnumerable<Area> areas =
       // }


    }
}
