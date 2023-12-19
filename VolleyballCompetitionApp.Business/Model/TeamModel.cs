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
		public TeamModel(ITeamRepository teamRepository, int id, int clubId, string name)
		{
			_teamRepository = teamRepository;
			Id = id;
			ClubId = clubId;
			Name = name;
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
