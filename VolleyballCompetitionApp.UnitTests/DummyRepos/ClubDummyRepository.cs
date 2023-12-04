using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolleyballCompetitionApp.Business.DTOs;
using VolleyballCompetitionApp.Business.RepositoryInterfaces;

namespace VolleyballCompetitionApp.UnitTests.DummyRepos
{
	public class ClubDummyRepository : IClubRepository
	{
		private readonly List<ClubDTO> _dummyDTOs = [
			new ClubDTO { Id = 1, Name = "club 1!" }, 
			new ClubDTO { Id = 2, Name = "2 club?" }
			];

		public ClubDummyRepository(string dummyConnectionString) => Console.WriteLine($"Created a club dummy repo with the connection string: \"{dummyConnectionString}\"");

		public int Create(string name)
		{
			Random random = new Random();
			return random.Next(50, 1000);
		}

		public void Delete(int id)
		{
			Console.WriteLine($"Deleted ClubId: {id}");
		}

		public ClubDTO FindById(int id)
		{
			foreach (ClubDTO dto in _dummyDTOs)
			{
				if (dto.Id == id)
				{
					return dto;
				}
			}
			throw new Exception("Not a valid id passed to the dummy club repository.");
		}

		public List<ClubDTO> GetAllClubs() => _dummyDTOs;

		public void Update(int id, string name)
		{
			Console.WriteLine($"Updated ClubId \"{id}\" to:");
			Console.WriteLine($"  Name = \"{name}\"");
		}
	}
}
