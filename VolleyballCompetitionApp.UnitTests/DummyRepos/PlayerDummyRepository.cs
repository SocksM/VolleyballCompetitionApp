using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolleyballCompetitionApp.Business.DTOs;
using VolleyballCompetitionApp.Business.RepositoryInterfaces;

namespace VolleyballCompetitionApp.UnitTests.DummyRepos
{
	public class PlayerDummyRepository : IPlayerRepository
	{
		public PlayerDummyRepository(string dummyConnectionString) => Console.WriteLine($"Created a player dummy repo with the connection string: \"{dummyConnectionString}\"");

		public int Create(int teamId, string name)
		{
			Random random = new Random();
			return random.Next(50, 1000);
		}

		public void Delete(int id)
		{
			Console.WriteLine($"Deleted PlayerId: {id}");
		}

		public PlayerDTO FindById(int id)
		{
			switch (id)
			{
				case 1:
					return new PlayerDTO { Id = id, TeamId = 1, Name = "Player 1!!" };
				case 2:
					return new PlayerDTO { Id = id, TeamId = 2, Name = "2 Plaaayer" };
				default:
					throw new Exception("Not a valid id passed to the dummy player repository.");
			}
		}

		public List<PlayerDTO> FindByTeamId(int teamId)
		{
			switch (teamId)
			{
				case 1:
					List<PlayerDTO> output1 = [new PlayerDTO { Id = 1, TeamId = teamId, Name = "Player 1!!" }];
					return output1;
				case 2:
					List<PlayerDTO> output2 = [new PlayerDTO { Id = 2, TeamId = teamId, Name = "2 Plaaayer" }];
					return output2;
				default:
					throw new Exception("Not a valid id passed to the dummy player repository.");
			}
		}

		public void Update(int id, int teamId, string name)
		{
			Console.WriteLine($"Updated PlayerId \"{id}\" to:");
			Console.WriteLine($"  Team ID = \"{teamId}\"");
			Console.WriteLine($"  Name = \"{name}\"");
		}
	}
}
