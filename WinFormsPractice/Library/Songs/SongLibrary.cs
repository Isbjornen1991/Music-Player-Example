using System;
using System.Collections.Generic;
using System.Text;
using WinFormsPractice.Library;

namespace WinFormsPractice.Library.Songs
{
    public class SongLibrary
    {
        public List<Song> MasterLibrary { get; set; }

        public SongLibrary()
        {
            MasterLibrary = new List<Song>();

            LoadMasterLibraryData();
        }

        private void LoadMasterLibraryData()
        {
            MasterLibrary.Add(new Song("Stairway to Heaven", "Led Zeppelin", "Led Zeppelin IV", 482));
            MasterLibrary.Add(new Song("Bohemian Rhapsody", "Queen", "A Night at the Opera", 355));
            MasterLibrary.Add(new Song("Hotel California", "Eagles", "Hotel California", 390));
            MasterLibrary.Add(new Song("Smells Like Teen Spirit", "Nirvana", "Nevermind", 301));
            MasterLibrary.Add(new Song("Imagine", "John Lennon", "Imagine", 187));
            MasterLibrary.Add(new Song("Hey Jude", "The Beatles", "Hey Jude", 431));
            MasterLibrary.Add(new Song("Billie Jean", "Michael Jackson", "Thriller", 294));
            MasterLibrary.Add(new Song("Test Track 1", "Artist A", "Album X", 240));
            MasterLibrary.Add(new Song("Instructions", "Regina Hardon", "Album X", 243));
        }

    }
}
