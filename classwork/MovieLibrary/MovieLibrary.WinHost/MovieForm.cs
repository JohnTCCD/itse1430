using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieLibrary.WinHost
{
    public partial class MovieForm : Form
    {
        public MovieForm ()
        {
            InitializeComponent();
        }

        public Movie Movie { get; set; }

        //Called when the form asked to close
        //protected override void OnFormClosing ( FormClosingEventArgs e )
        //{
        //    base.OnFormClosing(e);

        //    //Confirm to close if title is set
        //    if (_txtTitle.Text.Length > 0)
        //    {
        //        if (!Confirm("Are yiou sure you want to close without saving?", "Close"))
        //            e.Cancel = true;
        //    }
        //}

        private bool Confirm ( string message, string title )
        {
            return MessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        protected override void OnLoad ( EventArgs e )
        {
            //Alawys call base version first
            base.OnLoad(e);

            //Load UI, if necessary
            if (Movie != null)
                LoadMovie(Movie);

            //Validate so user can see what is required
            ValidateChildren();
        }

        private void LoadMovie( Movie movie )
        {
            _txtTitle.Text = movie.Title;
            _txtDescription.Text = movie.Description;
            _cbRating.SelectedText = movie.Rating;
            _txtRunLength.Text = movie.RunLength.ToString();
            _txtReleaseYear.Text = movie.ReleaseYear.ToString();
            _chkIsClassic.Checked = movie.IsClassic;
        }

        //Called when Save cilcked
        private void OnSave ( object sender, EventArgs e )
        {
            //TODO: Validate children
            if (!ValidateChildren())
            {
                DialogResult = DialogResult.None;
                return;
            }

            //Build up a Movie
            var movie = new Movie();
            movie.Title = _txtTitle.Text;
            movie.Description = _txtDescription.Text;
            movie.Rating = _cbRating.Text;
            movie.RunLength = GetInt32(_txtRunLength);
            movie.ReleaseYear = GetInt32(_txtReleaseYear);
            movie.IsClassic = _chkIsClassic.Checked;

            //TODO: Validate
            if (!ObjectValidator.TryValidate(movie, out var error))
            {
                DisplayError(error, "Error");
                DialogResult = DialogResult.None;
                return;
            }

            Movie = movie;

            //TODO: Return movie

            //Close the form
            //Close();
        }

        private void DisplayError( string message, string title )
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private int GetInt32 ( Control /*TextBox*/ control )
        {
            var text = control.Text;
            if (Int32.TryParse(text, out var result))
                return result;

            return -1;
        }

        private void _txtTitle_KeyUp ( object sender, KeyEventArgs e )
        {
            var target = sender as TextBox;

            System.Diagnostics.Debug.WriteLine($"[KeyUp: Text={target.Name} Key={e.KeyCode}");
        }

        private void OnValidatingTitle ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;

            //title is required
            if (control.Text.Length > 0)
            {
                _errors.SetError(control, "");
                return;
            }

            //Not valid
            _errors.SetError(control, "Title is required.");
            e.Cancel = true;
        }

        private void OnValidatingRating ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;

            //rating is required
            if (control.Text.Length > 0)
            {
                _errors.SetError(control, "");
                return;
            }

            //Not valid
            _errors.SetError(control, "Rating is required.");
            e.Cancel = true;
        }

        private void OnValidatingRunlength ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;

            //run length >= 0
            var value = GetInt32(control);
            if (value >= 0)
            {
                _errors.SetError(control, "");
                return;
            }

            //Not valid
            _errors.SetError(control, "Runlength must be >= 0.");
            e.Cancel = true;
        }

        private void OnValidatingReleaseYear ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;

            //release year >= 1900
            var value = GetInt32(control);
            if (value >= Movie.MinimumReleaseYear)
            {
                _errors.SetError(control, "");
                return;
            }

            //Not valid
            _errors.SetError(control, $"Release year must be >= {Movie.MinimumReleaseYear}.");
            e.Cancel = true;
        }
    }
}
