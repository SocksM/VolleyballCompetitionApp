using System.Xml.Linq;
using VolleyballCompetitionApp.Interfaces.RepositoryInterfaces;

namespace VolleyballCompetitionApp.Business.Models
{
    public class PlayerModel
    {
        public int Id { get; private set; }
        public int TeamId { get; private set; }
        public string Name { get; private set; }

		private readonly IPlayerRepository _playerRepository;

		public PlayerModel(IPlayerRepository playerRepository, int id, int teamId, string name) // done
        {
            _playerRepository = playerRepository;
            Id = id;
            TeamId = teamId;
            Name = name;
        }

		public void SetName(string newName) // changes the name in the class and in the database
		{
			if (!DataValidator.IsNameValid(newName))
			{
				DataValidator.ThrowInvalidNameException(newName);
			}

			// database data uploading
			_playerRepository.Update(Id, TeamId, newName);

			// if no error: change var in class
			Name = newName;
		}

		public void SetTeamId(int teamId)
		{
            // database data uploading
            _playerRepository.Update(Id, teamId, Name);

            // if no error: change var in class
            TeamId = teamId;
		}
	}
}