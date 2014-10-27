using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: CLSCompliant(true)]
namespace Exercise4SoccerTeam
{
    public enum Gender { Male, Female}
    public abstract class SportsPlayer {
        public String Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

        protected SportsPlayer(String name, int age, Gender gender) {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public override String ToString() {
            return "Name: "+ Name + " \tAge: " + Age + " \tGender: " + Gender;
        }
    }

    public enum Position { Goalkeeper, Defender, Midfielder, Striker}
    public class SoccerPlayer : SportsPlayer {
        public Position Position { get; set; }

        public SoccerPlayer(String name, int age, Gender gender, Position position)
            : base(name, age, gender){
                this.Position = position;
        }

        public SoccerPlayer()
            :this("",0,Gender.Male,Position.Defender){
        }

        public override string ToString() {
            return base.ToString() + " \tPosition: " + Position;
        }

        public class SoccerTeam : IEnumerable {
            private const int minAge = 5;
            private const int maxAge = Int32.MaxValue;
            public String TeamName { get; set; }
            public Gender TeamGender { get; set; }

            private int ageLimit;
            public int AgeLimit {
                get {
                    return ageLimit;
                }
                set {
                    if (value < minAge) {
                        throw new ArgumentException("Too young to join");
                    }
                    else {
                        this.ageLimit = value;
                    }
                }
            }

            private List<SoccerPlayer> players;

            public List<SoccerPlayer> Players {
                get {
                    return new List<SoccerPlayer>(players);
                }
            }

            public SoccerTeam(String teamName, Gender teamGender, int ageLimit) {
                this.TeamName = teamName;
                this.TeamGender = teamGender;
                this.AgeLimit = ageLimit;
                players = new List<SoccerPlayer>();
            }

            public IEnumerable GetEnumerator() {
                foreach (SoccerPlayer s in players) {
                    yield return s;
                }
            }
            // indexer property
            public SoccerPlayer this[String playerName] {
                get {
                    SoccerPlayer player = null;
                    bool isFound = false;
                    for (int i = 0; i < players.Count; i++) {
                        if(players[i].Name.ToUpper().Equals(playerName.ToUpper())){
                            isFound = true;
                            player = players[i];
                        }
                    }
                    if (isFound == true) {
                        return player;
                    }
                    else {
                        throw new ArgumentException("Player not found");
                    }
                }
            }
            public void AddPlayer (SoccerPlayer player){
                if (Players == null) {
                    players.Add(player);
                }
                else {
                    if (players.Contains(player)) {
                        throw new ArgumentException("Player already on team");
                    }
                    else {
                        if (player.Gender == TeamGender) {
                            if (player.Age <= AgeLimit) {
                                players.Add(player);
                            }
                            else {
                                throw new ArgumentException("Player too old for team"); 
                            }
                        }
                        else {
                            throw new ArgumentException("Not gender appropriate");
                        }
                    }
                }
            }
        }
    }
}
