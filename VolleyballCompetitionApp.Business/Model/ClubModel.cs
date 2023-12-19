using VolleyballCompetitionApp.Interfaces.RepositoryInterfaces;

namespace VolleyballCompetitionApp.Business.Models
{
	public class ClubModel
	{
		public int Id { get; private set; }
		public string Name { get; private set; }

		private readonly IClubRepository _clubRepository;

		public ClubModel(IClubRepository clubRepository, int id, string name)
		{
			_clubRepository = clubRepository;
			Id = id;
			Name = name;
		}

		public void SetName(string newName) // changes the name in the class and in the database
		{
			// check if parameters are valid
			if (!CheckIfNameValid(newName))
			{
				throw new ArgumentException($"Name can't be longer than 255. Name Currently is currently {newName.Length} long.");
			}

			// database data uploading
			_clubRepository.Update(Id, newName);

			// if no error: change var in class
			Name = newName;
		}

		private bool CheckIfNameValid (string name)
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
