using VolleyballCompetitionApp.Business.DTOs;

namespace VolleyballCompetitionApp.Business.RepositoryInterfaces
{
	public interface ITeamRepository
	{
		public int Create(int clubId, string name);
		public TeamDTO FindById(int id);
		public List<TeamDTO> FindByClubId(int clubId);
		public void Update(int id, int clubId, string name);
		public void Delete(int id);
	}
}
