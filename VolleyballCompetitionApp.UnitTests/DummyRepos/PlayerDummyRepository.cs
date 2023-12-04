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
		private readonly List<PlayerDTO> _dummyDTOs = [
			new PlayerDTO { Id = 1, TeamId = 1, Name = "Player 1!!" },
			new PlayerDTO { Id = 2, TeamId = 2, Name = "2 Plaaayer" }
			];

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
			foreach (PlayerDTO dto in _dummyDTOs)
			{
				if (dto.Id == id)
				{
					return dto;
				}
			}
			throw new Exception("Not a valid id passed to the dummy Player repository.");
		}

		public List<PlayerDTO> FindByTeamId(int teamId)
		{
			List<PlayerDTO> output = new List<PlayerDTO>();
			foreach (PlayerDTO dto in _dummyDTOs)
			{
				if (dto.TeamId == teamId)
				{
					output.Add(dto);
				}
			}
			if (output.Count > 0)
			{
				return output;
			}
			throw new Exception("Not a valid id passed to the dummy Player repository.");
		}

		public void Update(int id, int teamId, string name)
		{
			Console.WriteLine($"Updated PlayerId \"{id}\" to:");
			Console.WriteLine($"  Team ID = \"{teamId}\"");
			Console.WriteLine($"  Name = \"{name}\"");
		}
	}
}
