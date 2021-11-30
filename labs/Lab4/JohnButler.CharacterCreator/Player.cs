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
    /// <summary> Represents a player in the game. </summary>
    public class Player
    {
        private GameWorld _gameWorld = new GameWorld();
        private Inventory _inventory = new Inventory();
        private int _positionId;

        /// <summary> Gets or sets the character. </summary>
        public Character Character { get; set; }

        /// <summary> Sets the current position of the player. </summary>
        /// <param name="id"> Id of the area. </param>
        public void SetCurrentPosition(int id)
        {
            _positionId = id;
        }

        /// <summary> Gets the player's position at the start of the game. </summary>
        /// <returns> Area the game starts in. </returns>
        public Area GetStartingPosition ()
        {
            _gameWorld.CreateGameWorld();
            return _gameWorld.FindStartingArea();
        }

        /// <summary> Gets the player's current position. </summary>
        /// <returns> Area of current position. </returns>
        public Area GetCurrentPosition ()
        {
            return _gameWorld.FindAreaById(_positionId);
        }

        /// <summary> Adds an item to the player's inventory. </summary>
        /// <param name="item"> Item to add to inventory. </param>
        public void TakeItem (Item item)
        {
            _inventory.AddItem(item);
        }

        /// <summary> Gets the player's inventory. </summary>
        /// <returns> Inventory. </returns>
        public Inventory GetInventory ()
        {
            if (_inventory == null)
                return null;

            return _inventory;
        }
    }
}
