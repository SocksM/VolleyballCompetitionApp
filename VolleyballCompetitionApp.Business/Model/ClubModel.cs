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
			if (!DataValidator.IsNameValid(newName))
			{
				DataValidator.ThrowInvalidNameException(newName);
			}

			// database data uploading
			_clubRepository.Update(Id, newName);

			// if no error: change var in class
			Name = newName;
		}
	}
}
