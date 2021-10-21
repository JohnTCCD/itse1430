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

        /// <summary> Handles when save button is clicked. </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSave ( object sender, EventArgs e )
        {
            if (!ValidateChildren())
            {
                DialogResult = DialogResult.None;
                return;
            }

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
            var error = character.Validate();

            if (!String.IsNullOrEmpty(error))
            {
                DisplayError(error, "Error");
                DialogResult = DialogResult.None;
                return;
            }

            Character = character;
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            if (Character != null)
                LoadCharacter(Character);

            ValidateChildren();
        }

        private void LoadCharacter ( Character character )
        {
            _txtName.Text = character.Name;
            _cbProfession.Text = character.Profession;
            _cbRace.Text = character.Race;
            _txtBiography.Text = character.Biography;
            _txtIntelligence.Text = character.Intelligence.ToString();
            _txtStrength.Text = character.Strength.ToString();
            _txtAgility.Text = character.Agility.ToString();
            _txtConstitution.Text = character.Constitution.ToString();
            _txtCharisma.Text = character.Charisma.ToString();
        }

        /// <summary> Handles when the cancel button is clicked. </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancel ( object sender, EventArgs e )
        {
            Close();
        }

        /// <summary> Gets integer input from text box. </summary>
        /// <param name="control"> Text box for input. </param>
        /// <returns> Int input if true. </returns>
        private int GetIntInput(Control control)
        {
            var text = control.Text;
            if (Int32.TryParse(text, out var result))
                return result;

            return -1;
        }

        /// <summary> Validates control </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnValidatingName ( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var control = sender as Control;

            if (control.Text.Length > 0)
            {
                _error.SetError(control, "");
                return;
            }

            _error.SetError(control, "Name is required.");
            e.Cancel = true;
        }

        /// <summary> Validates control </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnValidatingProfession ( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var control = sender as Control;

            if (control.Text.Length > 0)
            {
                _error.SetError(control, "");
                return;
            }

            _error.SetError(control, "Profession is required.");
            e.Cancel = true;
        }

        /// <summary> Validates control </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnValidatingRace ( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var control = sender as Control;

            if (control.Text.Length > 0)
            {
                _error.SetError(control, "");
                return;
            }

            _error.SetError(control, "Race is required.");
            e.Cancel = true;
        }

        /// <summary> Validates control </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnValidatingIntelligence ( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var control = sender as Control;

            var value = GetIntInput(control);
            if (value >= Character.MinimumValue && value <= Character.MaximumValue)
            {
                _error.SetError(control, "");
                return;
            }

            _error.SetError(control, $"Intelligence must be {Character.MinimumValue} - {Character.MaximumValue}.");
            e.Cancel = true;
        }

        /// <summary> Validates control </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnValidatingStrength ( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var control = sender as Control;

            var value = GetIntInput(control);
            if (value >= Character.MinimumValue && value <= Character.MaximumValue)
            {
                _error.SetError(control, "");
                return;
            }

            _error.SetError(control, $"Strength must be {Character.MinimumValue} - {Character.MaximumValue}.");
            e.Cancel = true;
        }

        /// <summary> Validates control </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnValidatingAgility ( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var control = sender as Control;

            var value = GetIntInput(control);
            if (value >= Character.MinimumValue && value <= Character.MaximumValue)
            {
                _error.SetError(control, "");
                return;
            }

            _error.SetError(control, $"Agility must be {Character.MinimumValue} - {Character.MaximumValue}.");
            e.Cancel = true;
        }

        /// <summary> Validates control </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnValidatingConstitution ( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var control = sender as Control;

            var value = GetIntInput(control);
            if (value >= Character.MinimumValue && value <= Character.MaximumValue)
            {
                _error.SetError(control, "");
                return;
            }

            _error.SetError(control, $"Constitution must be {Character.MinimumValue} - {Character.MaximumValue}.");
            e.Cancel = true;
        }

        /// <summary> Validates control </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnValidatingCharisma ( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var control = sender as Control;

            var value = GetIntInput(control);
            if (value >= Character.MinimumValue && value <= Character.MaximumValue)
            {
                _error.SetError(control, "");
                return;
            }

            _error.SetError(control, $"Charisma must be {Character.MinimumValue} - {Character.MaximumValue}.");
            e.Cancel = true;
        }

        /// <summary> Displays an error window. </summary>
        /// <param name="message"> Message to be displayed. </param>
        /// <param name="title"> Title to be displayed. </param>
        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
