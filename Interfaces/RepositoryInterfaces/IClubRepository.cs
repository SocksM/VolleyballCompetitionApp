using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolleyballCompetitionApp.Tools.DTOs;

namespace VolleyballCompetitionApp.Tools.RepositoryInterfaces
{
	public interface IClubRepository
	{
		public int Create(string name);
		public ClubDTO FindById(int id);
		public List<ClubDTO> GetAllClubs();
		public void Update(int id, string name);
		public void Delete(int id);
	}
}
