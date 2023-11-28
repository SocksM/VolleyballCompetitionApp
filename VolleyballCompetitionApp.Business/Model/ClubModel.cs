﻿using VolleyballCompetitionApp.Business.DTOs;
using VolleyballCompetitionApp.Business.RepositoryInterfaces;

namespace VolleyballCompetitionApp.Business.Models
{
	public class ClubModel
	{
		public int Id { get; private set; }
		public string Name { get; private set; }

		private readonly IClubRepository _clubRepository;
		private readonly ITeamRepository _teamRepository;
		private readonly IPlayerRepository _playerRepository;

		public ClubModel(IClubRepository clubRepository, ITeamRepository teamRepository, IPlayerRepository playerRepository, int id, string name)
		{
			_clubRepository = clubRepository;
			_teamRepository = teamRepository;
			_playerRepository = playerRepository;
			Id = id;
			Name = name;
		}

		public void SetName(string newName) // changes the name in the class and in the database
		{
			// check if parameters are valid
			if (!CheckIfNameValid(newName))
			{
				throw new ArgumentException($"Name can't be longer than 255.  Name Currently is currently {newName.Length} long.");
			}

			// database data uploading
			_clubRepository.Update(Id, newName);

			// if no error: change var in class
			Name = newName;
		}

		public TeamModel CreateTeam(string name, int clubId)
		{
			// check if parameters are valid
			if (!CheckIfNameValid(name))
			{
				throw new ArgumentException($"Name can't be longer than 255. Name Currently is currently {name.Length} long.");
			}

			// database data uploading
			int id = _teamRepository.Create(clubId, name);

			// if no errors change var in class
			return new TeamModel(_teamRepository, _playerRepository, id, clubId, name);
		}

		public void DeleteTeamById(int id) 
		{
			foreach (PlayerDTO playerDTO in _playerRepository.FindByTeamId(id))
			{
				_playerRepository.Delete(playerDTO.Id);
			}
			_teamRepository.Delete(id);
		}

		private bool CheckIfNameValid (string name)
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
