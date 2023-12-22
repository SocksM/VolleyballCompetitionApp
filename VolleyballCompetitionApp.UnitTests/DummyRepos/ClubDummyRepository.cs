using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolleyballCompetitionApp.Interfaces.DTOs;
using VolleyballCompetitionApp.Interfaces.RepositoryInterfaces;

namespace VolleyballCompetitionApp.UnitTests.DummyRepos
{
    public class ClubDummyRepository : IClubRepository
    {
        private readonly List<ClubDTO> _dummyDTOs = [
            new ClubDTO { Id = 1, Name = "club 1!" },
            new ClubDTO { Id = 2, Name = "2 club?" }
            ];
        public List<ClubDTO> Creates { get; private set; } = new List<ClubDTO>();
        public List<ClubDTO> Updates { get; private set; } = new List<ClubDTO>();
        public List<int> Deletes { get; private set; } = new List<int>();

        public ClubDummyRepository()
        {
            Console.WriteLine($"Created a club dummy repo.");
        }

        public int Create(string name)
        {
            Creates.Add(new ClubDTO
            {
                Id = 50,
                Name = name
            });
            return 50;
        }

        public void Delete(int id)
        {
            Deletes.Add(id);
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
            Updates.Add(new ClubDTO
            {
                Id = id,
                Name = name
            });

            Console.WriteLine($"Updated ClubId \"{id}\" to:");
            Console.WriteLine($"  Name = \"{name}\"");
        }
    }
}
