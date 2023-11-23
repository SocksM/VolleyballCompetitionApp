using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolleyballCompetitionApp.Business.Models
{
    public class CompetitionModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateOnly Start { get; private set; }
        public DateOnly End { get; private set; }
        public List<MatchModel>? Matches { get; private set; }

        public CompetitionModel(int id, string name, DateOnly start, DateOnly end, List<MatchModel>? matches = null) // done
        {
            Id = id;
            Name = name;
            Start = start;
            End = end;
            Matches = matches;
        }

        public void SetName(string newName) // changes the name in the class and in the database
        {
            // database connection and data uploading 

            // if no error: change var in class
            Name = newName;
        }

        public void SetSart(DateOnly start) // changes the start date in the class and in the database
        {
            // database connection and data uploading 

            // if no error: change var in class
            Start = start;
        }

        public void SetEnd(DateOnly end) // changes the end date in the class and in the database
        {
            // database connection and data uploading 

            // if no error: change var in class
            End = end;
        }

        public void DeleteThis() // deletes the competition row with the same id
        {
            // database connection and data deletion
        }

        public void AddMatch(string name, string location) // creates a new row in the database and in the class
        {
            // data base connection and data uploading

            // if no error change var in class
            Matches.Add(new MatchModel(name, location));
        }

		public void AddMatch(int id) // gets a match from the database to add to the variable
		{
			// data base connection and data fetching

			// data verification (does this match belong to this competition etc?)

			// if no error, change var in class
			Matches.Add(new MatchModel(id));
		}

		public void DeleteMatch(int id) //
        {
            foreach (MatchModel match in Matches)
            {
                if (match.Id == id)
                {
                    // delete the data base row with the same id\

                    // if no error change var in class
                    match.DeleteThis();
                    Matches.Remove(match);

                }
            }
        }
    }
}
