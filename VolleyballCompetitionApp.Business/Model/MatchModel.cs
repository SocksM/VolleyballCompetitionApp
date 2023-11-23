using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VolleyballCompetitionApp.Business.Models
{
    public class MatchModel
    {
        public int Id { get; private set; }
        public int[] TeamIds { get; private set; } // int[2]
        public int CompetitionId { get; private set; }
        public string Location { get; private set; }
        public List<ScoreModel[]>? Scores { get; private set; } // List<ScoreModel>[2]

        public MatchModel(int id, int[] teamIds, int competitionId, string location, List<ScoreModel[]>? scores = null) // done
        {
            Id = id;
            TeamIds = teamIds;
            CompetitionId = competitionId;
            Location = location;
            Scores = scores;
        }

        public void SetLocation(string location) // changes the name in the class and in the database
        {
            // database connection and data uploading 

            // if no error: change var in class
            Location = location;
        }

        public void DeleteThis() // deletes the Match row with the same id
        {
            // database connection and data deletion
        }

        public void AddScore(int[] teamId, int matchId, int round, int[] score) // creates a new row in the database and in the class
        {
            // data base connection and data uploading

            // verification for the arrays (are there 2 entries or not? if so, error)

            // if no error change var in class
            Scores.Add(new ScoreModel[] { new ScoreModel(teamId[0], matchId, round, score[0]), new ScoreModel(teamId[1], matchId, round, score[1]) });
        }

		public void AddScore(int[] id) // gets a score from the database to add to the variable
		{
            // data base connection and data fetching

            // data verification (does this score belong to this match etc?)

            // if no error, change var in class
            Scores.Add( new ScoreModel[] { new ScoreModel(id[0]), new ScoreModel(id[1]) } );
		}

		public void DeleteScore(int round) //
        {
            foreach (ScoreModel[] score in Scores)
            {
                if (score[0].Round == round)
                {
                    // delete the data base row with the same round num
                    score[0].DeleteThis();
                    score[1].DeleteThis();

                    // if no error change var in class
                    Scores.Remove(score);

                }
            }
        }
    }
}

