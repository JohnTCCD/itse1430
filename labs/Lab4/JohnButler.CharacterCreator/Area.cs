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
    public class Area
    {
        private Item _item;

        /// <summary> Gets or sets the area id. </summary>
        public int Id { get; set; }

        /// <summary> Gets or sets the area description. </summary>
        public string Description { get; set; }

        /// <summary> Gets or sets an array of accessible area ids. </summary>
        public int[] AccessibleIds { get; set; }

        /// <summary> Gets or sets if the area has an item or not. </summary>
        public bool HasItem { get; set; }

        /// <summary> Displays the description of the current area. </summary>
        /// <param name="id"> Area id. </param>
        /// <param name="hasItem"> Determines if area has an item or not. </param>
        /// <returns> String description to be displayed. </returns>
        public string DisplayDescription (int id, bool hasItem = false)
        {
            if (id == 2 && hasItem)
                return Description + "There is a knief that can be picked up.";
            else if (id == 7 && hasItem)
                return Description + "There is a hand mirror that can be picked up.";
            else if (id == 9 && hasItem)
                return Description + "There is an herbal remedey book that can be picked up.";
            else
                return Description;
        }

        /// <summary> Makes a copy of an area. </summary>
        /// <returns> Copied area. </returns>
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

        /// <summary> Sets an item in the current area. </summary>
        /// <param name="item"> Item to be set. </param>
        public void SetItem( Item item )
        {
            if (_item == null)
                _item = new Item();

            _item = item;
        }

        /// <summary> Gets an item from the current area. </summary>
        /// <returns> Item in the area. </returns>
        public Item GetItem ()
        {
            if (_item != null)
            {
                var item = _item;
                return item;
            }

            return null;
        }

        /// <summary> Deletes the item in the current area. </summary>
        public void RemoveItem ()
        {
            if (_item == null)
                return;

            _item = null;
        }
    }
}
