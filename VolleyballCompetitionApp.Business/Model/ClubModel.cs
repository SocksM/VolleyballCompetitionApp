using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VolleyballCompetitionApp.Repository;
using VolleyballCompetitionApp.Repository.DTOs;

namespace VolleyballCompetitionApp.Business.Models
{
    public class ClubModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<TeamModel>? Teams { get; private set; }
        private readonly string _connectionString;
        
        public ClubModel(string connectionString, int id, string name, List<TeamModel>? teams = null)
        {
            _connectionString = connectionString;
            Id = id;
            Name = name;
            Teams = teams;  
        }

        public void SetName(string newName) // changes the name in the class and in the database
        {
            // database data uploading
            ClubRepository clubRepository = new ClubRepository(_connectionString); // krijg de connstring op een manier zie todo op lijn 16
            ClubDTO dto = new ClubDTO();
            dto.Name = newName;
            dto.Id = Id;
            clubRepository.Update(dto);

            // if no error: change var in class
            Name = newName;
        }

        public void AddTeam(int id, string name, int clubId, List<PlayerModel>? playerModels = null) 
        {
            Teams.Add(new TeamModel(_connectionString, id, name, clubId, playerModels));
        }

        public void CreateTeam(string name, int clubId)
        {
			// check if parameters are valid
			if (name.Length > 255)
			{
				throw new ArgumentException("Name can't be longer than 255.");
			}

			// database data uploading
			TeamRepository teamRepository = new TeamRepository(_connectionString);
			int id = teamRepository.Create(new TeamDTO 
            { 
                Name = name, 
                ClubId = clubId 
            });

            // if no errors change var in class
            Teams.Add(new TeamModel(_connectionString, id, name, clubId));
		}

		public void DeleteTeamById(int id)
        {
            foreach (TeamModel team in Teams)
            {
                if (team.Id == id)
                {
                    // delete the database row with the same id
                    TeamRepository teamRepository = new TeamRepository(_connectionString);
                    teamRepository.Delete(team.Id);
                    // if no error change var in class
                    Teams.Remove(team);
                    break;
                }
            }
        }
    }
}
