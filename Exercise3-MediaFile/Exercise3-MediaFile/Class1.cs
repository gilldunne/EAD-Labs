using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise3MediaFile
{
    public abstract class MediaFile {
        private String fileName;
        public String FileName {
            get {
                return fileName;
            }
            set {
                if (value == null) {
                    throw new ArgumentException("File name cannot be blank");
                }
                else {
                    fileName = value;
                }
            }
        }

        protected MediaFile(String fileName) {
            this.fileName = fileName;
        }

        public override String ToString() {
            String output = "Filename: " + fileName;
            return output;
        }
    }

    public enum MusicGenre { Pop, Rock, Dance, HipHop, Rap, Other }

    public class MusicFile : MediaFile {
        private String title;
        private String artist;
        private MusicGenre genre;

        public String Title {
            get {
                return title;
            }
        }
        public String Artist {
            get {
                return artist;
            }
        }
        public MusicGenre Genre {
            get {
                return genre;
            }
        }

        public MusicFile(String fileName, String title, String artist, MusicGenre genre)
            : base(fileName) {
                if (String.IsNullOrEmpty(title)) {
                    throw new ArgumentException("Title cannot be empty");
                }
                else if (String.IsNullOrEmpty(artist)) {
                    throw new ArgumentException("Artist cannot be empty");
                }
                else {
                    this.title = title;
                    this.artist = artist;
                    this.genre = genre;
                }
        }

        public MusicFile(String fileName, String title, String artist)
            : this(fileName, title, artist, MusicGenre.Other) {

        }

        public override string ToString() {
            String output = " \tTitle: " + title + " \tArtist: " + artist + " \tGenre: " + genre;
            return base.ToString() + output;
        }
    }

    public class PlaylistCollection : IEnumerable {
        public String PlaylistName { get; set; }

        private List<MusicFile> tracks;

        public List<MusicFile> Tracks {
            get { 
                return new List<MusicFile> (tracks); 
            }
        }

        public PlaylistCollection(String playlistName) {
            this.PlaylistName = playlistName;
            tracks = new List<MusicFile>();
        }

        public void AddTrack(MusicFile track) {
            if (Tracks == null) {
                tracks.Add(track);
            }
            else {
                bool duplicate = false;
                foreach (MusicFile t in tracks) {
                    if ((track.Title == t.Title) && (track.Artist == t.Artist)) {
                        duplicate = true;
                        break;
                    }
                }

                if (duplicate == true) {
                    throw new ArgumentException("Track already in playlist");
                }
                else {
                    tracks.Add(track);
                }
            }
        }
        // Iterate over a collection
        public IEnumerator GetEnumerator() {
            foreach (MusicFile m in tracks) {
                yield return m;
            }
        }
        // Read-Only Indexer - return a collection of music files for genre
        public IEnumerable<MusicFile> this[MusicGenre genre] {
            get {
                // LINQ
                var tracksForGenre = tracks.Where(t => t.Genre == genre);
                return tracksForGenre;
            }
        }
    }
}
