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
			switch (id)
			{
				case 1:
					return new TeamDTO { Id = id, ClubId = 1, Name = "tem 1" };
				case 2:
					return new TeamDTO { Id = id, ClubId = 2, Name = "2teamssss" };
				default:
					throw new Exception("Not a valid id passed to the dummy team repository.");
			}
		}

		public List<TeamDTO> FindByClubId(int clubId)
		{
			switch (clubId)
			{
				case 1:
					List<TeamDTO> output1 = [new TeamDTO { Id = 1, ClubId = clubId, Name = "Player 1!!" }];
					return output1;
				case 2:
					List<TeamDTO> output2 = [new TeamDTO { Id = 2, ClubId = clubId, Name = "2 Plaaayer" }];
					return output2;
				default:
					throw new Exception("Not a valid id passed to the dummy player repository.");
			}
		}

		public void Update(int id, int clubId, string name)
		{
			Console.WriteLine($"Updated PlayerId \"{id}\" to:");
			Console.WriteLine($"  Club ID = \"{clubId}\"");
			Console.WriteLine($"  Name = \"{name}\"");
		}
	}
}
