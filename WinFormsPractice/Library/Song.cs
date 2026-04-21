using System;
using System.Collections.Generic;
//using System.Runtime.CompilerServices;
using System.Text;

namespace WinFormsPractice.Library
{
    public class Song
    {
        //Common attributes for songs
        public string SongName { get; set; }
        public string ArtistName { get; set; }
        public string AlbumTitle { get; set; }

        public int DurationInSeconds { get; set; }

        public string TitleArtistDuration
        {
            get
            {
                int minutes = DurationInSeconds / 60;
                int seconds = DurationInSeconds % 60;
                return $"{SongName} by {ArtistName} ({minutes}:{seconds:00})";
            }
        }

        //Constructor to ensure these values are not created as nulls
        public Song(string SongName, string ArtistName, string AlbumTitle, int DurationInSeconds)
        {
            this.SongName = SongName;
            this.ArtistName = ArtistName;
            this.AlbumTitle = AlbumTitle;
            this.DurationInSeconds = DurationInSeconds;
        }

        public override string ToString()
        {
            int minutes = DurationInSeconds / 60;
            int seconds = DurationInSeconds % 60;

            return $"{SongName} by {ArtistName} ({minutes}:{seconds:00})";
        }

    }
}
