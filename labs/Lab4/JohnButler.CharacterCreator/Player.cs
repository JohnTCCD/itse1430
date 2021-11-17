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
        private Character _character;
        private GameWorld _gameWorld;
        private Inventory _inventory;
        private int _positionId;

        /// <summary> Sets the character. </summary>
        /// <param name="character"> Character to set. </param>
        public void SetCharacter (Character character)
        {
            _character = character;
        }

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
            _gameWorld = new GameWorld();
            _gameWorld.CreateGameWorld();
            return _gameWorld.FindStartingArea();
        }

        /// <summary> Gets the player's current position. </summary>
        /// <returns> Area of current position. </returns>
        public Area GetCurrentPosition ()
        {
            return _gameWorld.FindAreaById(_positionId);
        }
    }
}
