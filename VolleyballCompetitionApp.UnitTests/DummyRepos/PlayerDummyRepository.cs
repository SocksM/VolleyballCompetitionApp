using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolleyballCompetitionApp.Interfaces.DTOs;
using VolleyballCompetitionApp.Interfaces.RepositoryInterfaces;

namespace VolleyballCompetitionApp.UnitTests.DummyRepos
{
	public class PlayerDummyRepository : IPlayerRepository
	{
		private readonly List<PlayerDTO> _dummyDTOs = [
			new PlayerDTO { Id = 1, TeamId = 1, Name = "Player 1!!" },
			new PlayerDTO { Id = 2, TeamId = 2, Name = "2 Plaaayer" }
			];
		public List<PlayerDTO> Creates { get; private set; } = new List<PlayerDTO>();
		public List<PlayerDTO> Updates { get; private set; } = new List<PlayerDTO>();
		public List<int> Deletes { get; private set; } = new List<int>();

		public PlayerDummyRepository()
		{
            Console.WriteLine($"Created a player dummy repo.");
        }

		public int Create(int teamId, string name)
		{
			Random random = new Random();
			int randomNum = random.Next(50, 1000);
			Creates.Add( new PlayerDTO {
				Id = randomNum, 
				TeamId = teamId,
				Name = name
			});
			return randomNum;
		}

		public void Delete(int id)
		{
			Deletes.Add(id);
			Console.WriteLine($"Deleted PlayerId: {id}");
		}

        public void DeleteByTeamId(int teamId)
        {
            foreach (PlayerDTO player in _dummyDTOs)
            {
                if (player.TeamId == teamId)
                {
                    Deletes.Add(player.Id);
                    Console.WriteLine($"Deleted PlayerId: {player.Id}");
                }
            }
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

        public List<PlayerDTO> GetAllPlayers() => _dummyDTOs;

        public void Update(int id, int teamId, string name)
		{
			Updates.Add(new PlayerDTO
			{
				Id = id,
				TeamId = teamId,
				Name = name
			});
			Console.WriteLine($"Updated PlayerId \"{id}\" to:");
			Console.WriteLine($"  Team ID = \"{teamId}\"");
			Console.WriteLine($"  Name = \"{name}\"");
		}

        public List<PlayerDTO> FindByClubId(int clubId)
        {
            throw new NotImplementedException();
        }
    }
}
