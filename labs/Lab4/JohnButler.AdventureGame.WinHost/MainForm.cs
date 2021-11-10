/*========================
John Butler
ITSE 1430 Fall 2021
Lab 4
========================*/

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
    /// <summary> Main Window. </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Character _character;

        /// <summary> Handles when File/Exit is chosen. </summary>
        /// <param name="sender"> Event Sender </param>
        /// <param name="e"> Event Data </param>
        private void OnFileExit ( object sender, EventArgs e )
        {
            if (!Confirm("Are you sure you want to quit?", "Confirm"))
                return;

            Close();
        }

        /// <summary> Displays a confirmation window. </summary>
        /// <param name="message"> Message to be displayed. </param>
        /// <param name="title"> Title of window to be displayed. </param>
        /// <returns> Message box to be displayed. </returns>
        private static bool Confirm ( string message, string title )
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        /// <summary> Handles when Help/About is chosen. </summary>
        /// <param name="sender"> Event Sender </param>
        /// <param name="e"> Event Data </param>
        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var dialog = new AboutBox();
            dialog.ShowDialog();
        }

        /// <summary> Handles when Character/Add is chosen. </summary>
        /// <param name="sender"> Event Sender </param>
        /// <param name="e"> Event Data </param>
        private void OnCharacterAdd ( object sender, EventArgs e )
        {
            if (_character != null)
            {
                DisplayError("There is already a character added.", "Error");
                return;
            }

            var dialog = new CharacterForm();
            dialog.StartPosition = FormStartPosition.CenterParent;
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            _character = dialog.Character;
            UpdateUI();
        }

        /// <summary> Handles when Character/Edit is chosen. </summary>
        /// <param name="sender"> Event Sender </param>
        /// <param name="e"> Event Data </param>
        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            if (_character == null)
                return;

            var dialog = new CharacterForm();
            dialog.Text = "Edit Character";
            dialog.Character = _character;

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            _character = dialog.Character;
            UpdateUI();
        }

        /// <summary> Handles when Character/Delete is chosen. </summary>
        /// <param name="sender"> Event Sender </param>
        /// <param name="e"> Event Data </param>
        private void OnCharacterDelete ( object sender, EventArgs e )
        {
            if (_character == null)
                return;

            if (!Confirm($"Are you sure you want to delete {_character.Name}?", "Delete Character"))
                return;

            _character = null;
            UpdateUI();
        }

        /// <summary> Updates UI if something's changed. </summary>
        private void UpdateUI(Player player = null)
        {
            var characters = (_character != null) ? new Character[1] : new Character[0];
            if (_character != null)
                characters[0] = _character;

            var bindingSource = new BindingSource();
            bindingSource.DataSource = characters;
            _lbCharacters.DataSource = bindingSource;

            if (player == null)
                return;

            textBox1.Text = player.GetPosition(8).Description;
        }

        /// <summary> Displays an error window. </summary>
        /// <param name="message"> Message to be displayed. </param>
        /// <param name="title"> Title to be displayed. </param>
        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OnNewGame ( object sender, EventArgs e )
        {
            if (_character == null)
            {
                DisplayError("There must be a character created.", "Error");
                return;
            }

            characterToolStripMenuItem.Enabled = false;
            StartGame();
        }

        private void StartGame ()
        {
            Player player = new Player();
            player.SetCharacter(_character);
            
            var currentPosition = player.GetStartingPosition().Description;
            UpdateUI(player);
        }
    }
}
