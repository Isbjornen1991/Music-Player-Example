namespace WinFormsPractice
{
    partial class MusicPlayerMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            addSongButton = new Button();
            playlistListBox1 = new ListBox();
            removeSongButton = new Button();
            savePlayListButton = new Button();
            loadPlayListButton = new Button();
            playbackProgressBar = new ProgressBar();
            playButton = new Button();
            clearPlayListButton = new Button();
            artistNameLabel = new Label();
            songNameLabel = new Label();
            DurationLabel = new Label();
            albumLabel = new Label();
            staticDurationLabel = new Label();
            staticSongName = new Label();
            staticArtist = new Label();
            staticAlbum = new Label();
            staticDurationHeader = new Label();
            SuspendLayout();
            // 
            // addSongButton
            // 
            addSongButton.Location = new Point(70, 14);
            addSongButton.Margin = new Padding(5);
            addSongButton.Name = "addSongButton";
            addSongButton.Size = new Size(118, 38);
            addSongButton.TabIndex = 3;
            addSongButton.Text = "Add Song";
            addSongButton.UseVisualStyleBackColor = true;
            addSongButton.Click += addSongButton_Click;
            // 
            // playlistListBox1
            // 
            playlistListBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            playlistListBox1.FormattingEnabled = true;
            playlistListBox1.Location = new Point(424, 14);
            playlistListBox1.Margin = new Padding(5);
            playlistListBox1.Name = "playlistListBox1";
            playlistListBox1.Size = new Size(746, 404);
            playlistListBox1.TabIndex = 4;
            playlistListBox1.SelectedIndexChanged += playlistListBox1_SelectedIndexChanged;
            playlistListBox1.DoubleClick += PlayButton_Click;
            // 
            // removeSongButton
            // 
            removeSongButton.Location = new Point(198, 14);
            removeSongButton.Margin = new Padding(5);
            removeSongButton.Name = "removeSongButton";
            removeSongButton.Size = new Size(118, 38);
            removeSongButton.TabIndex = 5;
            removeSongButton.Text = "Remove Song";
            removeSongButton.UseVisualStyleBackColor = true;
            removeSongButton.Click += removeSongButton_Click;
            // 
            // savePlayListButton
            // 
            savePlayListButton.Location = new Point(228, 141);
            savePlayListButton.Margin = new Padding(5);
            savePlayListButton.Name = "savePlayListButton";
            savePlayListButton.Size = new Size(148, 38);
            savePlayListButton.TabIndex = 6;
            savePlayListButton.Text = "Save Playlist...";
            savePlayListButton.UseVisualStyleBackColor = true;
            savePlayListButton.Click += savePlayListButton_Click;
            // 
            // loadPlayListButton
            // 
            loadPlayListButton.Location = new Point(70, 141);
            loadPlayListButton.Margin = new Padding(5);
            loadPlayListButton.Name = "loadPlayListButton";
            loadPlayListButton.Size = new Size(148, 38);
            loadPlayListButton.TabIndex = 7;
            loadPlayListButton.Text = "Load Playlist...";
            loadPlayListButton.UseVisualStyleBackColor = true;
            loadPlayListButton.Click += loadPlayListButton_Click;
            // 
            // playbackProgressBar
            // 
            playbackProgressBar.Anchor = AnchorStyles.Bottom;
            playbackProgressBar.Location = new Point(70, 526);
            playbackProgressBar.Name = "playbackProgressBar";
            playbackProgressBar.Size = new Size(1042, 23);
            playbackProgressBar.Step = 1;
            playbackProgressBar.TabIndex = 8;
            // 
            // playButton
            // 
            playButton.Anchor = AnchorStyles.Bottom;
            playButton.Location = new Point(569, 461);
            playButton.Name = "playButton";
            playButton.Size = new Size(112, 48);
            playButton.TabIndex = 9;
            playButton.Text = "Play";
            playButton.UseVisualStyleBackColor = true;
            playButton.Click += PlayButton_Click;
            // 
            // clearPlayListButton
            // 
            clearPlayListButton.Location = new Point(228, 189);
            clearPlayListButton.Margin = new Padding(5);
            clearPlayListButton.Name = "clearPlayListButton";
            clearPlayListButton.Size = new Size(148, 38);
            clearPlayListButton.TabIndex = 11;
            clearPlayListButton.Text = "Clear Playlist...";
            clearPlayListButton.UseVisualStyleBackColor = true;
            clearPlayListButton.Click += clearPlayListButton_Click;
            // 
            // artistNameLabel
            // 
            artistNameLabel.AutoSize = true;
            artistNameLabel.Location = new Point(289, 484);
            artistNameLabel.Name = "artistNameLabel";
            artistNameLabel.Size = new Size(0, 25);
            artistNameLabel.TabIndex = 12;
            artistNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // songNameLabel
            // 
            songNameLabel.AutoSize = true;
            songNameLabel.Location = new Point(70, 484);
            songNameLabel.Name = "songNameLabel";
            songNameLabel.Size = new Size(0, 25);
            songNameLabel.TabIndex = 13;
            songNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DurationLabel
            // 
            DurationLabel.AutoSize = true;
            DurationLabel.Font = new Font("Segoe UI", 8F);
            DurationLabel.Location = new Point(600, 532);
            DurationLabel.Name = "DurationLabel";
            DurationLabel.Size = new Size(34, 13);
            DurationLabel.TabIndex = 14;
            DurationLabel.Text = "00:00";
            // 
            // albumLabel
            // 
            albumLabel.AutoSize = true;
            albumLabel.Location = new Point(811, 484);
            albumLabel.Name = "albumLabel";
            albumLabel.Size = new Size(0, 25);
            albumLabel.TabIndex = 15;
            albumLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // staticDurationLabel
            // 
            staticDurationLabel.AutoSize = true;
            staticDurationLabel.Location = new Point(1017, 484);
            staticDurationLabel.Name = "staticDurationLabel";
            staticDurationLabel.Size = new Size(56, 25);
            staticDurationLabel.TabIndex = 16;
            staticDurationLabel.Text = "00:00";
            // 
            // staticSongName
            // 
            staticSongName.AutoSize = true;
            staticSongName.Location = new Point(93, 459);
            staticSongName.Name = "staticSongName";
            staticSongName.Size = new Size(55, 25);
            staticSongName.TabIndex = 17;
            staticSongName.Text = "Song";
            // 
            // staticArtist
            // 
            staticArtist.AutoSize = true;
            staticArtist.Location = new Point(320, 459);
            staticArtist.Name = "staticArtist";
            staticArtist.Size = new Size(56, 25);
            staticArtist.TabIndex = 18;
            staticArtist.Text = "Artist";
            // 
            // staticAlbum
            // 
            staticAlbum.AutoSize = true;
            staticAlbum.Location = new Point(817, 459);
            staticAlbum.Name = "staticAlbum";
            staticAlbum.Size = new Size(67, 25);
            staticAlbum.TabIndex = 19;
            staticAlbum.Text = "Album";
            // 
            // staticDurationHeader
            // 
            staticDurationHeader.AutoSize = true;
            staticDurationHeader.Location = new Point(1004, 459);
            staticDurationHeader.Name = "staticDurationHeader";
            staticDurationHeader.Size = new Size(86, 25);
            staticDurationHeader.TabIndex = 20;
            staticDurationHeader.Text = "Duration";
            // 
            // MusicPlayerMain
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 561);
            Controls.Add(staticDurationHeader);
            Controls.Add(staticAlbum);
            Controls.Add(staticArtist);
            Controls.Add(staticSongName);
            Controls.Add(staticDurationLabel);
            Controls.Add(albumLabel);
            Controls.Add(DurationLabel);
            Controls.Add(songNameLabel);
            Controls.Add(artistNameLabel);
            Controls.Add(clearPlayListButton);
            Controls.Add(playButton);
            Controls.Add(playbackProgressBar);
            Controls.Add(loadPlayListButton);
            Controls.Add(savePlayListButton);
            Controls.Add(removeSongButton);
            Controls.Add(playlistListBox1);
            Controls.Add(addSongButton);
            Font = new Font("Segoe UI", 14F);
            Margin = new Padding(5);
            Name = "MusicPlayerMain";
            Text = "Music Player";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button addSongButton;
        private ListBox playlistListBox1;
        private Button removeSongButton;
        private Button savePlayListButton;
        private Button loadPlayListButton;
        private ProgressBar playbackProgressBar;
        private Button playButton;
        private Button clearPlayListButton;
        private Label artistNameLabel;
        private Label songNameLabel;
        private Label DurationLabel;
        private Label albumLabel;
        private Label staticDurationLabel;
        private Label staticSongName;
        private Label staticArtist;
        private Label staticAlbum;
        private Label staticDurationHeader;
    }
}
