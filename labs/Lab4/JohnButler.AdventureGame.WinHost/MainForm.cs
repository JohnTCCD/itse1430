﻿/*========================
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
        private Player _player;

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
        private void UpdateUI(Area area = null)
        {
            var characters = (_character != null) ? new Character[1] : new Character[0];
                
            if (_character != null)
                characters[0] = _character;

            var bindingSource = new BindingSource();
            bindingSource.DataSource = characters;
            _lbCharacters.DataSource = bindingSource;
            _lbCharacters.DisplayMember = nameof(Name);

            if (_player == null || area == null)
                return;
            
            _player.SetCurrentPosition(area.Id);
            textBox1.Text = _player.GetCurrentPosition().Description;
            EnableButtons(area.Id);
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
            _player = new Player();
            _player.SetCharacter(_character);
            var currentArea = _player.GetStartingPosition();
            UpdateUI(currentArea);
        }

        private void EnableButtons(int id)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            switch (id)
            {
                case 1:
                {
                    button2.Enabled = true;
                    button3.Enabled = true;
                    break;
                }
                case 2:
                {
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    break;
                }
                case 3:
                {
                    button3.Enabled = true;
                    button4.Enabled = true;
                    break;
                }
                case 4:
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    break;
                }
                case 5:
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    break;
                }
                case 6:
                {
                    button1.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    break;
                }
                case 7:
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                    break;
                }
                case 8:
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button4.Enabled = true;
                    break;
                }
                case 9:
                {
                    button1.Enabled = true;
                    button4.Enabled = true;
                    break;
                }
                default: DisplayError("Unknown Error", "Error"); break;
            }
        }

        private void OnMoveNorth ( object sender, EventArgs e )
        {
            var currentArea = _player.GetCurrentPosition();

            foreach (var areaId in currentArea.AccessibleIds)
            {
                if (currentArea.Id - 3 == areaId)
                    _player.SetCurrentPosition(areaId);
            }

            currentArea = _player.GetCurrentPosition();
            UpdateUI(currentArea);
        }

        private void OnMoveSouth ( object sender, EventArgs e )
        {
            var currentArea = _player.GetCurrentPosition();

            foreach (var areaId in currentArea.AccessibleIds)
            {
                if (currentArea.Id + 3 == areaId)
                    _player.SetCurrentPosition(areaId);
            }

            currentArea = _player.GetCurrentPosition();
            UpdateUI(currentArea);
        }

        private void OnMoveEast ( object sender, EventArgs e )
        {
            var currentArea = _player.GetCurrentPosition();

            foreach (var areaId in currentArea.AccessibleIds)
            {
                if (currentArea.Id + 1 == areaId)
                    _player.SetCurrentPosition(areaId);
            }

            currentArea = _player.GetCurrentPosition();
            UpdateUI(currentArea);
        }

        private void OnMoveWest ( object sender, EventArgs e )
        {
            var currentArea = _player.GetCurrentPosition();

            foreach (var areaId in currentArea.AccessibleIds)
            {
                if (currentArea.Id - 1 == areaId)
                    _player.SetCurrentPosition(areaId);
            }

            currentArea = _player.GetCurrentPosition();
            UpdateUI(currentArea);
        }
    }
}
