using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JohnButler.AdventureGame.WinHost
{
    public partial class CharacterForm : Form
    {
        public CharacterForm ()
        {
            InitializeComponent();
        }

        public Character Character { get; set; }

        private void OnSave ( object sender, EventArgs e )
        {
            var character = new Character();
            character.Name = _txtName.Text;
            character.Profession = _cbProfession.Text;
            character.Race = _cbRace.Text;
            character.Biography = _txtBiography.Text;
            character.Intelligence = GetIntInput(_txtIntelligence);
            character.Strength = GetIntInput(_txtStrength);
            character.Agility = GetIntInput(_txtAgility);
            character.Constitution = GetIntInput(_txtConstitution);
            character.Charisma = GetIntInput(_txtCharisma);

            //TODO: validate new character

            Character = character;
        }

        private int GetIntInput(Control control)
        {
            var text = control.Text;
            if (Int32.TryParse(text, out var result))
                return result;

            return -1;
        }
    }
}
