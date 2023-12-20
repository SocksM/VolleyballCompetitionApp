using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolleyballCompetitionApp.Interfaces.DTOs;
using VolleyballCompetitionApp.Interfaces.RepositoryInterfaces;

namespace VolleyballCompetitionApp.UnitTests.DummyRepos
{
	public class TeamDummyRepository : ITeamRepository
	{
		private readonly List<TeamDTO> _dummyDTOs = [
			new TeamDTO { Id = 1, ClubId = 1, Name = "tem 1" },
			new TeamDTO { Id = 2, ClubId = 2, Name = "2teamssss" }
			];
        public List<TeamDTO> Creates { get; private set; } = new List<TeamDTO>();
        public List<TeamDTO> Updates { get; private set; } = new List<TeamDTO>();
        public List<int> Deletes { get; private set; } = new List<int>();

        public TeamDummyRepository()
		{
            Console.WriteLine($"Created a team dummy repo.");
        }

		public int Create(int clubId, string name)
		{
            Random random = new Random();
            int randomNum = random.Next(50, 1000);
            Creates.Add(new TeamDTO
            {
                Id = randomNum,
                ClubId = clubId,
                Name = name
            });
            return randomNum;
        }

		public void Delete(int id)
		{
			Deletes.Add(id);
			Console.WriteLine($"Deleted TeamId: {id}");
		}

        public void DeleteByClubId(int clubId)
        {
            foreach (TeamDTO team in _dummyDTOs)
			{
				if (team.ClubId == clubId)
				{
                    Deletes.Add(team.Id);
                    Console.WriteLine($"Deleted TeamId: {team.Id}");
                }
			}
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

        public List<TeamDTO> GetAllTeams() => _dummyDTOs;

        public void Update(int id, int clubId, string name)
		{
			Updates.Add(new TeamDTO
			{
				Id = id,
				ClubId = clubId,
				Name = name
			});
			Console.WriteLine($"Updated PlayerId \"{id}\" to:");
			Console.WriteLine($"  Club ID = \"{clubId}\"");
			Console.WriteLine($"  Name = \"{name}\"");
		}
    }
}
