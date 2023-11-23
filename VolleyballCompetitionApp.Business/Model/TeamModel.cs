using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
using VolleyballCompetitionApp.Repository;
using System.Xml.Linq;
using VolleyballCompetitionApp.Repository.DTOs;

namespace VolleyballCompetitionApp.Business.Models
{
    public class TeamModel
    {
        public int Id { get; private set; }
		public int ClubId { get; private set; }
		public string Name { get; private set; }
        public List<PlayerModel>? Players { get; private set; }
		private readonly string _connectionString;

        public TeamModel(string connectionString, int id, string name, int ClubId, List<PlayerModel>? players = null) // done
        {
			_connectionString = connectionString;
            Id = id;
            Name = name;
            Players = players;
        }

		public void SetName(string newName) // changes the name in the class and in the database
		{
			// database data uploading
			TeamRepository teamRepository = new TeamRepository(_connectionString); // krijg de connstring op een manier zie todo op lijn 16
			TeamDTO dto = new TeamDTO();
			dto.Name = newName;
			dto.Id = Id;
			dto.ClubId = ClubId;
			teamRepository.Update(dto);

			// if no error: change var in class
			Name = newName;
		}

		public void AddPlayer(int id, int teamId, string name)
        {
            Players.Add(new PlayerModel(_connectionString, id, teamId, name));
        }

		public void CreatePlayer(string name, int teamId) // gets a player from the database to add to the variable
		{
			// check if parameters are valid
			if (name.Length > 255)
			{
				throw new ArgumentException("Name can't be longer than 255.");
			}

			// database data uploading
			PlayerRepository playerRepository = new PlayerRepository(_connectionString);
			int id = playerRepository.Create(new PlayerDTO
			{
				Name = name
			});

			// if no errors change var in class
			Players.Add(new PlayerModel(_connectionString, id, teamId, name));
		}

		public void DeletePlayerById(int id)
		{
			foreach (PlayerModel player in Players)
			{
				if (player.Id == id)
				{
					// delete the database row with the same id
					PlayerRepository playerRepository = new PlayerRepository(_connectionString);
					playerRepository.Delete(player.Id);
					// if no error change var in class
					Players.Remove(player);
					break;
				}
			}
		}
	}
}
