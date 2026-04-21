using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsPractice.Library;
using WinFormsPractice.Library.Songs;

namespace WinFormsPractice
{
    public partial class Library_Selection_Form : Form
    {
        private SongLibrary _songLibrary;

        // Holding the selected song
        public Song SelectedSong { get; private set; }

        // For passing data between SongLibrary.cs and this form.
        public Library_Selection_Form(SongLibrary library)
        {
            InitializeComponent();
            _songLibrary = library;
            SetupLibraryBinding();
        }

        // Connecting the ListBox to the library contents
        private void SetupLibraryBinding()
        {
            this.libraryListBox.DataSource = _songLibrary.MasterLibrary;
            this.libraryListBox.DisplayMember = "TitleArtistDuration";
        }

        private void libraryListBox_DoubleClick(object sender, EventArgs e)
        {
            AddSelectedSong();
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            AddSelectedSong();
        }
        private void AddSelectedSong()
        {
            if (this.libraryListBox.SelectedItem is Song song)
            {
                // Store the selected song
                SelectedSong = song;

                // Set the DialogResult to OK (tells the calling form a selection was made)
                this.DialogResult = DialogResult.OK;

                // Close the modal window
                this.Close();
            }
            else
            {
                MessageBox.Show("Please double-click a song or select a song and click 'Select'.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}