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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            if (!Confirm("Are you sure you want to exit?", "Confirm"))
                return;

            Close();
        }

        private static bool Confirm ( string message, string title )
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var dialog = new AboutBox();
            dialog.ShowDialog();
        }

        private void OnCharacterAdd ( object sender, EventArgs e )
        {
            var dialog = new CharacterForm();
            dialog.StartPosition = FormStartPosition.CenterParent;
            dialog.ShowDialog();
        }
    }
}
