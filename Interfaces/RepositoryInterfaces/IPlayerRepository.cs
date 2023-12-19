﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolleyballCompetitionApp.Interfaces.DTOs;

namespace VolleyballCompetitionApp.Interfaces.RepositoryInterfaces
{
	public interface IPlayerRepository
	{
		public int Create(int teamId, string name);
		public PlayerDTO FindById(int id);
		public List<PlayerDTO> FindByTeamId(int teamId);
		public void Update(int id, int teamId, string name);
		public void Delete(int id);
		public void DeleteByTeamId(int teamId);
	}
}
