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
    public class PlayerCollection
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerCollection(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public List<PlayerModel> FindPlayerByTeamId(int TeamId)
        {
            List<PlayerModel> playerModels = new List<PlayerModel>();
            List<PlayerDTO> playerDTOs = _playerRepository.FindByTeamId(TeamId);
            foreach (PlayerDTO dto in playerDTOs)
            {
                playerModels.Add(new PlayerModel(_playerRepository, dto.Id, TeamId, dto.Name));
            }
            return playerModels;
        }
        public List<PlayerModel> FindPlayerByClubId(int ClubId)
        {
            List<PlayerModel> playerModels = new List<PlayerModel>();
            List<PlayerDTO> playerDTOs = _playerRepository.FindByClubId(ClubId);
            foreach (PlayerDTO dto in playerDTOs)
            {
                playerModels.Add(new PlayerModel(_playerRepository, dto.Id, dto.TeamId, dto.Name));
            }
            return playerModels;
        }

        public PlayerModel FindPlayerById(int id)
        {
            PlayerDTO dto = _playerRepository.FindById(id);
            return new PlayerModel(_playerRepository, dto.Id, dto.TeamId, dto.Name);
        }

        public List<PlayerModel> GetAllPlayers()
        {
            List<PlayerModel> playerModels = new List<PlayerModel>();
            List<PlayerDTO> playerDTOs = _playerRepository.GetAllPlayers();
            foreach (PlayerDTO dto in playerDTOs)
            {
                playerModels.Add(new PlayerModel(_playerRepository, dto.Id, dto.TeamId, dto.Name));
            }
            return playerModels;
        }

        public PlayerModel CreatePlayer(string name, int teamId) // gets a player from the database to add to the variable
        {
            // check if parameters are valid
            if (!DataValidator.IsNameValid(name))
            {
                DataValidator.ThrowInvalidNameException(name);
            }

            // database data uploading
            int id = _playerRepository.Create(teamId, name);

            // if no errors change var in class
            return new PlayerModel(_playerRepository, id, teamId, name);
        }

        public void DeletePlayerById(int id)
        {
            _playerRepository.Delete(id);
        }

        public void DeletePlayerByTeamId(int teamId)
        {
            List<PlayerDTO> playerDtos = _playerRepository.FindByTeamId(teamId);
            _playerRepository.DeleteByTeamId(teamId);
        }
    }
}