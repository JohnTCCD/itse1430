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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFileExit ( object sender, EventArgs e )
        {
            if (!Confirm("Are you sure you want to exit?", "Confirm"))
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var dialog = new AboutBox();
            dialog.ShowDialog();
        }

        /// <summary> Handles when Character/Add is chosen. </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCharacterAdd ( object sender, EventArgs e )
        {
            var dialog = new CharacterForm();
            dialog.StartPosition = FormStartPosition.CenterParent;
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            _character = dialog.Character;
            UpdateUI();
        }

        /// <summary> Updates UI if something's changed. </summary>
        private void UpdateUI()
        {
            var characters = (_character != null) ? new Character[1] : new Character[0];
            if (_character != null)
                characters[0] = _character;

            var bindingSource = new BindingSource();
            bindingSource.DataSource = characters;
            _lbCharacters.DataSource = bindingSource;
        }

        //private void _lbCharacter_SelectedIndexChanged ( object sender, EventArgs e ) { }
    }
}
