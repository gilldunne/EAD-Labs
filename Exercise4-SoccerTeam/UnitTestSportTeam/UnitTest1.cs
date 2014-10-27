using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Exercise4SoccerTeam;

namespace UnitTestSportTeam {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestValidation1() {
            SoccerPlayer sp = new SoccerPlayer();
            Assert.AreEqual(sp.Name, "");
            Assert.AreEqual(sp.Age, 0);
            Assert.AreEqual(sp.Gender, Gender.Male);
            Assert.AreEqual(sp.Position, Position.Defender);
        }

        [TestMethod]
        public void TestValidation2() {
            SoccerPlayer sp = new SoccerPlayer("Fergie", 22, Gender.Male, Position.Goalkeeper);
            Assert.AreEqual(sp.Name, "Fergie");
            Assert.AreEqual(sp.Age, 22);
            Assert.AreEqual(sp.Gender, Gender.Male);
            Assert.AreEqual(sp.Position, Position.Goalkeeper);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAgeLimit() {
            SoccerPlayer sp = new SoccerPlayer("Fergie", 22, Gender.Male, Position.Goalkeeper);
            SoccerTeam st = new SoccerTeam("Team 1", Gender.Male, 18);
            st.AddPlayer(sp);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGender() {
            SoccerPlayer sp = new SoccerPlayer("Fergie", 22, Gender.Female, Position.Goalkeeper);
            SoccerTeam st = new SoccerTeam("Team 1", Gender.Male, 18);
            st.AddPlayer(sp);
        }

        [TestMethod]
        public void TestAddPlayer1() {
            SoccerPlayer sp1 = new SoccerPlayer("Fergie", 12, Gender.Male, Position.Goalkeeper);
            SoccerPlayer sp2 = new SoccerPlayer("Sam", 12, Gender.Male, Position.Defender);      
            SoccerTeam st = new SoccerTeam("Team 1", Gender.Male, 18);
            st.AddPlayer(sp1);
            st.AddPlayer(sp2);
            CollectionAssert.Contains(st.Players, sp1);
            CollectionAssert.Contains(st.Players, sp2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddPlayer2() {
            SoccerPlayer sp1 = new SoccerPlayer("Fergie", 12, Gender.Male, Position.Goalkeeper);
            SoccerTeam st = new SoccerTeam("Team 1", Gender.Male, 18);
            st.AddPlayer(sp1);
            st.AddPlayer(sp1);
        }
        [TestMethod]
         public void TestIndexer() {
             SoccerPlayer m1 = new SoccerPlayer("Tom", 12, Gender.Male, Position.Goalkeeper);
             SoccerPlayer m2 = new SoccerPlayer("Sam", 12, Gender.Male, Position.Defender);
             SoccerPlayer m3 = new SoccerPlayer("Fergie", 12, Gender.Male, Position.Goalkeeper);
             
             SoccerTeam pl = new SoccerTeam("Team 1", Gender.Male, 18);
             pl.AddPlayer(m1);
             pl.AddPlayer(m2);
             pl.AddPlayer(m3); 

             List<SoccerPlayer> team = new List<SoccerPlayer>();
             team.Add(m1);
           
             // Indexer adding based on name
             List<SoccerPlayer> nameList = new List<SoccerPlayer>();
             foreach (SoccerPlayer m in pl["Sam"]) { // ERROR!!
                  nameList.Add(m);
             }
             // checks both lists are equal
             CollectionAssert.AreEqual(team, nameList);
         }
    }
}
