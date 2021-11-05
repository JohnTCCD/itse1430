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

        public Area FindArea (int id) //Place holder
        {
            if (_areas.ElementAt(id - 1).Id == id)
            {
                var area = _areas.ElementAt(id - 1);
                return area;
            }
            else
                return null;
        }

       
    }
}
