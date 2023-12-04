using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolleyballCompetitionApp.Business.DTOs;
using VolleyballCompetitionApp.Business.RepositoryInterfaces;

namespace VolleyballCompetitionApp.UnitTests.DummyRepos
{
	public class TeamDummyRepository : ITeamRepository
	{
		private readonly List<TeamDTO> _dummyDTOs = [
			new TeamDTO { Id = 1, ClubId = 1, Name = "tem 1" },
			new TeamDTO { Id = 2, ClubId = 2, Name = "2teamssss" }
			];
		public TeamDummyRepository(string dummyConnectionString) => Console.WriteLine($"Created a team dummy repo with the connection string: \"{dummyConnectionString}\"");

		public int Create(int clubId, string name)
		{
			Random random = new Random();
			return random.Next(50, 1000);
		}

		public void Delete(int id)
		{
			Console.WriteLine($"Deleted TeamId: {id}");
		}

		public TeamDTO FindById(int id)
		{
			foreach (TeamDTO dto in _dummyDTOs)
			{
				if (dto.Id == id)
				{
					return dto;
				}
			}
			throw new Exception("Not a valid id passed to the dummy Team repository.");
		}

		public List<TeamDTO> FindByClubId(int clubId)
		{
			List<TeamDTO> output = new List<TeamDTO>();
			foreach (TeamDTO dto in _dummyDTOs)
			{
				if (dto.ClubId == clubId)
				{
					output.Add(dto);
				}
			}
			if (output.Count > 0)
			{
				return output;
			}
			throw new Exception("Not a valid id passed to the dummy Team repository.");
		}

		public void Update(int id, int clubId, string name)
		{
			Console.WriteLine($"Updated PlayerId \"{id}\" to:");
			Console.WriteLine($"  Club ID = \"{clubId}\"");
			Console.WriteLine($"  Name = \"{name}\"");
		}
	}
}
