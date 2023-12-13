using VolleyballCompetitionApp.Interfaces.DTOs;
using VolleyballCompetitionApp.Interfaces.RepositoryInterfaces;

namespace VolleyballCompetitionApp.Business.Models
{
	public class TeamModel
	{
		public int Id { get; private set; }
		public int ClubId { get; private set; }
		public string Name { get; private set; }

		private readonly ITeamRepository _teamRepository;
		private readonly IPlayerRepository _playerRepository;

		public TeamModel(ITeamRepository teamRepository, IPlayerRepository playerRepository, int id, int clubId, string name)
		{
			_teamRepository = teamRepository;
			_playerRepository = playerRepository;
			Id = id;
			ClubId = clubId;
			Name = name;
		}

		public List<PlayerModel> FindPlayerByTeamId(int TeamId = -1)
		{
			if (TeamId == -1) TeamId = Id;
			List<PlayerModel> playerModels = new List<PlayerModel>();
			List<PlayerDTO> playerDTOs = _playerRepository.FindByTeamId(TeamId);
			foreach (PlayerDTO dto in playerDTOs)
			{
				playerModels.Add(new PlayerModel(_playerRepository, dto.Id, TeamId, dto.Name));
			}
			return playerModels;
		}

		public PlayerModel FindPlayerById(int id)
		{
			PlayerDTO dto = _playerRepository.FindById(id);
			return new PlayerModel(_playerRepository, dto.Id, dto.TeamId, dto.Name);
		}

		public void SetName(string newName) // changes the name in the class and in the database
		{
			// database data uploading
			if (!CheckIfNameValid(newName))
			{
				throw new ArgumentException($"Name can't be longer than 255. Name Currently is currently {newName.Length} long.");
			}

			_teamRepository.Update(Id, ClubId, newName);

			// if no error: change var in class
			Name = newName;
		}

		public PlayerModel CreatePlayer(string name, int teamId = -1) // gets a player from the database to add to the variable
		{
			// check if parameters are valid
			if (teamId == -1)
			{
				teamId = Id;
			}
			if (!CheckIfNameValid(name))
			{
				throw new ArgumentException($"Name can't be longer than 255. Name Currently is currently {name.Length} long.");
			}

			// database data uploading
			int id = _playerRepository.Create(teamId, name);

			// if no errors change var in class
			return new PlayerModel(_playerRepository, id, teamId, name);
		}

		public void DeletePlayerById(int id)
		{
			_playerRepository.Delete(id);
		}

		private bool CheckIfNameValid(string name)
		{
			// check if parameter is valid
			if (name.Length > 255)
			{
				return false;
			}
			return true;
		}
	}
}
