
namespace MovieLibrary.WinHost
{
    partial class MovieForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this._butnCancel = new System.Windows.Forms.Button();
            this._butnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._isClassic = new System.Windows.Forms.CheckBox();
            this._cbRating = new System.Windows.Forms.ComboBox();
            this._txtTitle = new System.Windows.Forms.TextBox();
            this._txtRunLength = new System.Windows.Forms.TextBox();
            this._txtDescription = new System.Windows.Forms.TextBox();
            this._txtReleaseYear = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _butnCancel
            // 
            this._butnCancel.Location = new System.Drawing.Point(665, 384);
            this._butnCancel.Name = "_butnCancel";
            this._butnCancel.Size = new System.Drawing.Size(75, 23);
            this._butnCancel.TabIndex = 0;
            this._butnCancel.Text = "Cancel";
            this._butnCancel.UseVisualStyleBackColor = true;
            // 
            // _butnSave
            // 
            this._butnSave.Location = new System.Drawing.Point(565, 384);
            this._butnSave.Name = "_butnSave";
            this._butnSave.Size = new System.Drawing.Size(75, 23);
            this._butnSave.TabIndex = 1;
            this._butnSave.Text = "Save";
            this._butnSave.UseVisualStyleBackColor = true;
            this._butnSave.Click += new System.EventHandler(this.OnSave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Run Length";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rating";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Release Year";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Description";
            // 
            // _isClassic
            // 
            this._isClassic.AutoSize = true;
            this._isClassic.Location = new System.Drawing.Point(108, 294);
            this._isClassic.Name = "_isClassic";
            this._isClassic.Size = new System.Drawing.Size(81, 19);
            this._isClassic.TabIndex = 8;
            this._isClassic.Text = "Is Classic ?";
            this._isClassic.UseVisualStyleBackColor = true;
            // 
            // _cbRating
            // 
            this._cbRating.FormattingEnabled = true;
            this._cbRating.Items.AddRange(new object[] {
            "G",
            "PG",
            "PG-13",
            "R"});
            this._cbRating.Location = new System.Drawing.Point(108, 140);
            this._cbRating.Name = "_cbRating";
            this._cbRating.Size = new System.Drawing.Size(121, 23);
            this._cbRating.TabIndex = 9;
            // 
            // _txtTitle
            // 
            this._txtTitle.Location = new System.Drawing.Point(108, 43);
            this._txtTitle.Name = "_txtTitle";
            this._txtTitle.Size = new System.Drawing.Size(100, 23);
            this._txtTitle.TabIndex = 10;
            // 
            // _txtRunLength
            // 
            this._txtRunLength.Location = new System.Drawing.Point(108, 88);
            this._txtRunLength.Name = "_txtRunLength";
            this._txtRunLength.Size = new System.Drawing.Size(100, 23);
            this._txtRunLength.TabIndex = 11;
            // 
            // _txtDescription
            // 
            this._txtDescription.Location = new System.Drawing.Point(108, 246);
            this._txtDescription.Name = "_txtDescription";
            this._txtDescription.Size = new System.Drawing.Size(100, 23);
            this._txtDescription.TabIndex = 12;
            // 
            // _txtReleaseYear
            // 
            this._txtReleaseYear.Location = new System.Drawing.Point(108, 189);
            this._txtReleaseYear.Name = "_txtReleaseYear";
            this._txtReleaseYear.Size = new System.Drawing.Size(100, 23);
            this._txtReleaseYear.TabIndex = 13;
            // 
            // MovieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._txtReleaseYear);
            this.Controls.Add(this._txtDescription);
            this.Controls.Add(this._txtRunLength);
            this.Controls.Add(this._txtTitle);
            this.Controls.Add(this._cbRating);
            this.Controls.Add(this._isClassic);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._butnSave);
            this.Controls.Add(this._butnCancel);
            this.Name = "MovieForm";
            this.Text = "Movie Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _butnCancel;
        private System.Windows.Forms.Button _butnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox _isClassic;
        private System.Windows.Forms.ComboBox _cbRating;
        private System.Windows.Forms.TextBox _txtTitle;
        private System.Windows.Forms.TextBox _txtRunLength;
        private System.Windows.Forms.TextBox _txtDescription;
        private System.Windows.Forms.TextBox _txtReleaseYear;
    }
}