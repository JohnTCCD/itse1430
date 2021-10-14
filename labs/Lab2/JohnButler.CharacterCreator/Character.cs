/*========================
John Butler
ITSE 1430 Fall 2021
Lab 2 : Character Creator
========================*/
using System;

namespace JohnButler.CharacterCreator
{
    /// <summary> Represents a character in the game. </summary>
    public class Character
    {
        private string _name, _profession, _race, _biography;

        /// <summary> Gets or sets the name. </summary>
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value?.Trim(); }
        }

        /// <summary> Gets or sets the profession. </summary>
        public string Profession
        {
            get { return _profession ?? ""; }
            set { _profession = value?.Trim(); }
        }

        /// <summary> Gets or sets the race. </summary>
        public string Race
        {
            get { return _race ?? ""; }
            set { _race = value?.Trim(); }
        }

        /// <summary> Gets or sets the biography. </summary>
        public string Biography
        {
            get { return _biography ?? ""; }
            set { _biography = value?.Trim(); }
        }

        public const int MaximumValue = 100, MinimumValue = 1;

        /// <summary> Gets or sets the strength. </summary>
        /// <value> minimumValue </value>
        public int Strength { get; set; } = MinimumValue;

        /// <summary> Gets or sets the intelligence. </summary>
        /// <value> minimumValue </value>
        public int Intelligence { get; set; } = MinimumValue;

        /// <summary> Gets or sets the agility. </summary>
        /// <value> minimumValue </value>
        public int Agility { get; set; } = MinimumValue;

        /// <summary> Gets or sets the constitution. </summary>
        /// <value> minimumValue </value>
        public int Constitution { get; set; } = MinimumValue;

        /// <summary> Gets or sets the charisma. </summary>
        /// <value> minimumValue </value>
        public int Charisma { get; set; } = MinimumValue;

    }
}
