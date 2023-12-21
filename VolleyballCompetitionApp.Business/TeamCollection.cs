using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VolleyballCompetitionApp.Business.Models;
using VolleyballCompetitionApp.Interfaces.DTOs;
using VolleyballCompetitionApp.Interfaces.RepositoryInterfaces;

namespace VolleyballCompetitionApp.Business
{
    public class TeamCollection
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IPlayerRepository _playerRepository;

        public TeamCollection(ITeamRepository teamRepository, IPlayerRepository playerRepository)
        {
            _teamRepository = teamRepository;
            _playerRepository = playerRepository;
        }

        public List<TeamModel> FindTeamByClubId(int clubId)
        {
            List<TeamModel> teamModels = new List<TeamModel>();
            List<TeamDTO> teamDTOs = _teamRepository.FindByClubId(clubId);
            foreach (TeamDTO dto in teamDTOs)
            {
                teamModels.Add(new TeamModel(_teamRepository, dto.Id, clubId, dto.Name));
            }
            return teamModels;
        }

        public TeamModel FindTeamById(int id)
        {
            TeamDTO dto = _teamRepository.FindById(id);
            return new TeamModel(_teamRepository, dto.Id, dto.ClubId, dto.Name);
        }

        public List<TeamModel> GetAllTeams()
        {
            List<TeamModel> teamModels = new List<TeamModel>();
            List<TeamDTO> teamDTOs = _teamRepository.GetAllTeams();
            foreach (TeamDTO dto in teamDTOs)
            {
                teamModels.Add(new TeamModel(_teamRepository, dto.Id, dto.ClubId, dto.Name));
            }
            return teamModels;
        }

        public TeamModel CreateTeam(string name, int clubId)
        {
            // check if parameters are valid
            if (!DataValidator.IsNameValid(name))
            {
                DataValidator.ThrowInvalidNameException(name);
            }

            // database data uploading
            int id = _teamRepository.Create(clubId, name);

            // if no errors change var in class
            return new TeamModel(_teamRepository, id, clubId, name);
        }

        public void DeleteTeamById(int id)
        {
            foreach (PlayerDTO playerDTO in _playerRepository.FindByTeamId(id))
            {
                _playerRepository.Delete(playerDTO.Id);
            }
            _teamRepository.Delete(id);
        }

        public void DeleteTeamByClubId(int clubId)
        {
            List<TeamDTO> teamDtos = _teamRepository.FindByClubId(clubId);
            _teamRepository.DeleteByClubId(clubId);
            foreach (TeamDTO teamDto in teamDtos)
            {
                _playerRepository.DeleteByTeamId(teamDto.Id);
            }
        }
    }
}
