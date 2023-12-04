using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VolleyballCompetitionApp.Business.DTOs;

namespace VolleyballCompetitionApp.Business.Models
{
    public class MatchModel
    {
        public int Id { get; private set; }
        public int[] TeamIds { get; private set; } // int[2]
        public int CompetitionId { get; private set; }
        public string Location { get; private set; }

        public MatchModel(int id, int[] teamIds, int competitionId, string location) // done
        {
            Id = id;
            TeamIds = teamIds;
            CompetitionId = competitionId;
            Location = location;
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

        public ScoreDTO CreateScore(int[] teamId, int matchId, int round, int[] score) // creates a new row in the database and in the class
        {
            // data base connection and data uploading

            // verification for the arrays (are there 2 entries or not? if so, error)
            return new ScoreDTO { };
        }

		public void DeleteScore(int round) //
        {

        }
    }
}

