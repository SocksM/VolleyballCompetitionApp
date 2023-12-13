using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolleyballCompetitionApp.Interfaces.DTOs;

namespace VolleyballCompetitionApp.Business.Models
{
    public class CompetitionModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateOnly Start { get; private set; }
        public DateOnly End { get; private set; }

        public CompetitionModel(int id, string name, DateOnly start, DateOnly end, List<MatchModel>? matches = null) // done
        {
            Id = id;
            Name = name;
            Start = start;
            End = end;
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

        public MatchDTO CreateMatch ()
        {
            return new MatchDTO { };
        }

		public void DeleteMatch(int id) //
        {
           
        }
    }
}
