using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VolleyballCompetitionApp.Business.Models
{
    public class ScoreModel
    {
        public int Id { get; private set; }
        public int TeamId { get; private set; }
        public int MatchId { get; private set; }
        public int Round { get; private set; }
        public int Score { get; private set; }

        public ScoreModel(int id, int teamId, int matchId, int round, int score) // done
        {
            TeamId = teamId;
            MatchId = matchId;
            Round = round;
            Score = score;
        }

        public void SetRound(int round) // changes the name in the class and in the database
        {
            // database connection and data uploading 

            // if no error: change var in class
            Round = round;
        }

        public void SetScore(int score)
        {
            Score = score;
        }

        public void DeleteThis() // deletes the Score row with the same id
        {
            // database connection and data deletion
        }
    }
}
