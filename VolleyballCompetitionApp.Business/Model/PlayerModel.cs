using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolleyballCompetitionApp.Repository.DTOs;
using VolleyballCompetitionApp.Repository;

namespace VolleyballCompetitionApp.Business.Models
{
    public class PlayerModel
    {
        public int Id { get; private set; }
        public int TeamId { get; private set; }
        public string Name { get; private set; }
        private readonly string _connectionString;

        public PlayerModel(string connectionString, int id, int teamId, string name) // done
        {
            _connectionString = connectionString;
            Id = id;
            TeamId = teamId;
            Name = name;
        }

		public void SetName(string newName) // changes the name in the class and in the database
		{
			// database data uploading
			PlayerRepository playerRepository = new PlayerRepository(_connectionString); // krijg de connstring op een manier zie todo op lijn 16
			PlayerDTO dto = new PlayerDTO();
			dto.Name = newName;
			dto.Id = Id;
			dto.TeamId = TeamId;
			playerRepository.Update(dto);

			// if no error: change var in class
			Name = newName;
		}
	}
}