using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using WinFormsPractice.Library;
using WinFormsPractice.Library.Songs;
using System.Text.Json;
using System.IO;

namespace WinFormsPractice
{
    public partial class MusicPlayerMain : Form
    {
        // Manager for song list library
        private SongLibrary libraryManager = new SongLibrary();

        // Playlist Data Container
        // This list holds Song Objects and lets the UI know about changes.
        private BindingList<Song> playlist = new BindingList<Song>();

        // Variables for playback state
        private System.Windows.Forms.Timer playbackTimer = new System.Windows.Forms.Timer();
        private Song currentlyPlayingSong;
        private int elapsedTimeSeconds = 0;
        private bool isPlaying = false;
        
        // Constructor(?) where components are initialized
        public MusicPlayerMain()
        {
            InitializeComponent();
            SetupPlaylistBinding();

            // Init timer to tick every second (1000ms). Good to know that this stuff runs in ms.
            playbackTimer.Interval = 1000;
            playbackTimer.Tick += PlaybackTimer_Tick;


        }

        // Connecting the BindingList data source to the ListBox
        // This one I need to review, it doesn't make much sense
        private void SetupPlaylistBinding()
        {
            this.playlistListBox1.DataSource = playlist;
        }

        //// Disabled Section of code: For Loading Songs when the application launches.
        //private void MusicPlayerMain_Load(object sender, EventArgs e)
        //{
        //    playlist.Add(libraryManager.MasterLibrary[0]);
        //    playlist.Add(libraryManager.MasterLibrary[1]);
        //    playlist.Add(libraryManager.MasterLibrary[2]);
        //}

        // Code for adding songs
        private void addSongButton_Click(object sender, EventArgs e)
        {
            // Instantiate the selection form, passing the master library data
            using (var selectionForm = new Library_Selection_Form(libraryManager))
            {
                // Show the form as a modal dialog.
                DialogResult result = selectionForm.ShowDialog();

                // Check if the user clicked the 'Select' button (DialogResult.OK)
                if (result == DialogResult.OK && selectionForm.SelectedSong != null)
                {
                    // If a song was selected, add it to the main playlist
                    playlist.Add(selectionForm.SelectedSong);
                }
            }
        }
        // Code for removing songs one by one
        private void removeSongButton_Click(object sender, EventArgs args)
        {
            if (playlistListBox1.SelectedItem is Song SelectedSong)
            {
                playlist.Remove(SelectedSong);
            }
            else
            {
                MessageBox.Show("Please select a song from the playlist to remove it.", "No Song Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Code for clearing the playlist
        private void clearPlayListButton_Click(object sender, EventArgs args)
        {
            playlist.Clear();
            playbackTimer.Stop();
            isPlaying = false;
            currentlyPlayingSong = null;
            elapsedTimeSeconds = 0;
            songNameLabel.Text = "---";
            artistNameLabel.Text = "---";
            albumLabel.Text = "---";
            DurationLabel.Text = "0:00";
            staticDurationLabel.Text = "-:--";
            MessageBox.Show("Playlist cleared successfully.", "Clear Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Code for saving a playlist
        private void savePlayListButton_Click(object sender, EventArgs args)
        {
            string jsonContent = JsonSerializer.Serialize(playlist);

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.DefaultExt = "json";

                // What types of files are accepted
                saveFileDialog.Filter = "JSON Playlist Files (*.json)|*json|All Files (*.*)|*.*";

                // Default File Name
                saveFileDialog.FileName = "MyPlaylist.json";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(saveFileDialog.FileName, jsonContent);
                        MessageBox.Show($"Playlist successfully saved to:\n{saveFileDialog.FileName}", "Save Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"An error occurred while writing the file: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        // Code for loading a playlist
        private void loadPlayListButton_Click(object sender, EventArgs args)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.DefaultExt = "json";
                openFileDialog.Filter = "JSON Playlist Files (*.json)|*.json|All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string jsonContent = "";

                    try
                    {
                        jsonContent = File.ReadAllText(openFileDialog.FileName);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"An error occurred while reading the file: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {
                        List<Song> loadedSongs = JsonSerializer.Deserialize<List<Song>>(jsonContent);

                        if (loadedSongs != null)
                        {
                            playlist.Clear();
                            foreach (var song in loadedSongs)
                            {
                                playlist.Add(song);
                            }
                            MessageBox.Show($"Successfully loaded {loadedSongs.Count} songs into the playlist.", "Load Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (JsonException ex)
                    {
                        MessageBox.Show($"The file format is invalid or corrupted. {ex.Message}", "Load Error (JSON Format)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Code for playing/pausing the song when the button is pressed
        private void PlayButton_Click(object sender, EventArgs args)
        {
            // Define the selected song once at the start
            Song selectedSong = playlistListBox1.SelectedItem as Song;

            // 1. If currently playing, PAUSE.
            if (isPlaying)
            {
                // If the user selected a different song while playing, 
                // we stop the current playback and fall through to the START NEW SONG logic below.
                if (selectedSong != null && selectedSong != currentlyPlayingSong)
                {
                    playbackTimer.Stop();
                    isPlaying = false;
                }
                else
                {
                    // Pause the current song (same song selected or no new selection)
                    playbackTimer.Stop();
                    isPlaying = false;
                    MessageBox.Show($"Playback paused: {currentlyPlayingSong?.SongName}", "Paused", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // Check for missing song data (Only reached if isPlaying is false, or if a new song was selected)
            if (selectedSong == null && currentlyPlayingSong == null)
            {
                MessageBox.Show("Please select a song from the playlist to start playback.", "No Song Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if we selected a new song, or if the current selected song is different  from the last one played/paused.
            bool isNewSong = selectedSong != null && selectedSong != currentlyPlayingSong;

            if (isNewSong)
            {
                // (reset everything)
                currentlyPlayingSong = selectedSong;
                elapsedTimeSeconds = 0;

                // PROGRESS BAR: Set the maximum value to the song's total duration because this thing loves to crash if value exceeds max.
                playbackProgressBar.Maximum = currentlyPlayingSong.DurationInSeconds;

                // Update labels
                songNameLabel.Text = currentlyPlayingSong.SongName;
                artistNameLabel.Text = currentlyPlayingSong.ArtistName;
                albumLabel.Text = currentlyPlayingSong.AlbumTitle;

                // Set the static total duration label
                int totalMinutes = currentlyPlayingSong.DurationInSeconds / 60;
                int totalSeconds = currentlyPlayingSong.DurationInSeconds % 60;
        
                staticDurationLabel.Text = $"{totalMinutes}:{totalSeconds:00}";

                // Reset dynamic label
                DurationLabel.Text = "0:00";
                MessageBox.Show($"Starting playback: {currentlyPlayingSong.SongName}", "Playing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (currentlyPlayingSong != null)
            {
                // Resume the paused song (time is already set)
                MessageBox.Show($"Resuming playback: {currentlyPlayingSong.SongName}", "Resuming", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Set the progress bar value to the current elapsed time 
            playbackProgressBar.Value = elapsedTimeSeconds;

            // Start the timer and set state
            playbackTimer.Start();
            isPlaying = true;
        }

        // Event handler that fires every 1000 milliseconds (tick)
        private void PlaybackTimer_Tick(object sender, EventArgs e)
        {
            if (currentlyPlayingSong == null)
            {
                playbackTimer.Stop();
                isPlaying = false;
                DurationLabel.Text = "0:00";
                // PROGRESS BAR: Reset on null check just in case because this thing loves to crash the app.
                playbackProgressBar.Value = 0;
                return;
            }

            // Check if the song has finished
            if (elapsedTimeSeconds >= currentlyPlayingSong.DurationInSeconds)
            {
                playbackTimer.Stop();
                isPlaying = false;
                DurationLabel.Text = "END";

                // Reset the prgress bar after completion
                playbackProgressBar.Value = 0;

                MessageBox.Show($"Playback finished for {currentlyPlayingSong.SongName}.", "Playback Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Increment the elapsed time
            elapsedTimeSeconds++;

            // Update the progress bar value
            // Check to ensure we don't try to set value > maximum, though the check above handles the finish because my god it loves to crash stuff.
            if (elapsedTimeSeconds <= playbackProgressBar.Maximum)
            {
                playbackProgressBar.Value = elapsedTimeSeconds;
            }

            // Calculate time format for the elapsed time
            int currentMinutes = elapsedTimeSeconds / 60;
            int currentSeconds = elapsedTimeSeconds % 60;

            // Update the dynamic label
            DurationLabel.Text = $"{currentMinutes}:{currentSeconds:00}";
        }


        // I forgot what this did, but it got added automatically
        private void playlistListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}