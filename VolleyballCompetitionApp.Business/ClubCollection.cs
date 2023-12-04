using VolleyballCompetitionApp.Business.DTOs;
using VolleyballCompetitionApp.Business.Models;
using VolleyballCompetitionApp.Business.RepositoryInterfaces;

namespace VolleyballCompetitionApp.Business
{
	public class ClubCollection
	{
		private readonly IClubRepository _clubRepository;
		private readonly ITeamRepository _teamRepository;
		private readonly IPlayerRepository _playerRepository;

		public ClubCollection(IClubRepository clubRepository, ITeamRepository teamRepository , IPlayerRepository playerRepository)
		{
			_clubRepository = clubRepository;
			_teamRepository = teamRepository;
			_playerRepository = playerRepository;
		}

		public ClubModel FindClubById (int id)
		{
			return new ClubModel(_clubRepository, _teamRepository, _playerRepository, id, _clubRepository.FindById(id).Name);
		}

		public List<ClubModel> GetAllClubs()
		{
			List<ClubModel> clubModels = new List<ClubModel>();
			List<ClubDTO> clubDTOs = _clubRepository.GetAllClubs();
			foreach (ClubDTO dto in clubDTOs)
			{
				clubModels.Add(new ClubModel(_clubRepository, _teamRepository, _playerRepository, dto.Id, dto.Name));
			}
			return clubModels;
		}

		public ClubModel CreateClub(string name) // ipv van void clubmodle voor testing
		{
			// check if parameters are valid
			if (!CheckIfNameValid(name))
			{
				throw new ArgumentException($"Name can't be longer than 255. Name Currently is currently {name.Length} long.");
			}

			// database data uploading
			int id = _clubRepository.Create(name);

			// if no errors change var in class
			return new ClubModel(_clubRepository, _teamRepository, _playerRepository, id, name); // addclub()
		}

		public void DeleteClubById(int id)
		{
			_clubRepository.Delete(id);
			foreach (TeamDTO teamDTO in _teamRepository.FindByClubId(id))
			{
				foreach (PlayerDTO playerDTO in _playerRepository.FindByTeamId(teamDTO.Id))
				{
					_playerRepository.Delete(playerDTO.Id);
				}
				_teamRepository.Delete(teamDTO.Id);
			}
		}

		private bool CheckIfNameValid(string name)
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