using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise3MediaFile;
using System.Collections.Generic;

namespace UnitTestMediaLibrary {
    [TestClass]
    public class UnitTest1 {
        // title should not be blank
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestValidation1() {
            MusicFile mf = new MusicFile("t1.mp3", "", "JT", MusicGenre.Dance);
        }
        // artist should not be blank
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestValidation2() {
            MusicFile mf = new MusicFile("t1.mp3", "Rivers", "", MusicGenre.Dance);
        }
        // artist should not be null
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestValidation3() {
            MusicFile mf = new MusicFile("t1.mp3", "Rivers", null);
        }

        // test constructors are setting values
        [TestMethod]
        public void TestConstructors() {
            MusicFile m1 = new MusicFile("t1.mp3", "Rivers", "JT", MusicGenre.Dance);
            MusicFile m2 = new MusicFile("t2.mp3", "Mountains", "Britney");
            Assert.AreEqual(m1.Artist, "JT");
            Assert.AreEqual(m1.Title, "Rivers");
            Assert.AreEqual(m1.Genre, MusicGenre.Dance);
            Assert.AreEqual(m2.Artist, "Britney");
            Assert.AreEqual(m2.Title, "Mountains");
            Assert.AreEqual(m2.Genre, MusicGenre.Other);
        }
        // adding to playlist
        [TestMethod]
        public void TestAddTrack1() {
            MusicFile m1 = new MusicFile("t1.mp3", "Rivers", "JT", MusicGenre.Dance);
            MusicFile m2 = new MusicFile("t2.mp3", "Mountains", "Britney");

            PlaylistCollection pl = new PlaylistCollection("Songs");
            pl.AddTrack(m1);
            pl.AddTrack(m2);

            CollectionAssert.Contains(pl.Tracks, m1);
            CollectionAssert.Contains(pl.Tracks, m2);
        }
        // add duplicate track
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddTrack2() {
            MusicFile m1 = new MusicFile("t1.mp3", "Rivers", "JT", MusicGenre.Dance);
            PlaylistCollection pl = new PlaylistCollection("Songs");
            pl.AddTrack(m1);
            pl.AddTrack(new MusicFile("t1.mp3", "Rivers", "JT", MusicGenre.Dance));
        }
        // testing read-ony indexer
        [TestMethod]
        public void TestIndexer() {
            MusicFile m1 = new MusicFile("t1.mp3", "Rivers", "JT", MusicGenre.Dance);
            MusicFile m2 = new MusicFile("t2.mp3", "Mountains", "Britney");
            MusicFile m3 = new MusicFile("t3.mp3", "Hills", "Toni", MusicGenre.Dance);
            // full playlist with all genres
            PlaylistCollection pl = new PlaylistCollection("Songs");
            pl.AddTrack(m1);
            pl.AddTrack(m2);
            pl.AddTrack(m3);
            // Manually adding dance music
            List<MusicFile> danceList = new List<MusicFile>();
            danceList.Add(m1);
            danceList.Add(m3);
            // Indexer adding based on genre
            List<MusicFile> playlistDanceList = new List<MusicFile>();
            foreach (MusicFile m in pl[MusicGenre.Dance]) {
                playlistDanceList.Add(m);
            }
            // checks both lists are equal
            CollectionAssert.AreEqual(danceList, playlistDanceList);
        }
    }
}
