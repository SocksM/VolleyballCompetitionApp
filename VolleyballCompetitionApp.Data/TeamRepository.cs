using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolleyballCompetitionApp.Business.Team;

namespace VolleyballCompetitionApp.Data
{
	public class TeamRepository : ITeamRepository
	{
		private readonly string _connectionString;

        public TeamRepository(string connectionString)
        {
			_connectionString = connectionString;
        }

        public void Create(int clubID, string name)
		{
			throw new NotImplementedException();
		}

		public List<TeamModel> GetBy(TeamColumn column, string where, bool lazyLoad = false)
		{
			throw new NotImplementedException();
		}

		public void Update(TeamModel model)
		{
			throw new NotImplementedException();
		}
		public void Delete(int id)
		{
			SqlConnection connection = new SqlConnection(_connectionString);
			var querry = "" +
				"Delete From Team " +
				"Where ID = @id";
			SqlCommand command = new SqlCommand(querry, connection);
			command.Parameters.AddWithValue("id", id);
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}
	}
}
