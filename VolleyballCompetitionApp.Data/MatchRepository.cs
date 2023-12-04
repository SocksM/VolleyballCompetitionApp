using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolleyballCompetitionApp.Business.Match;

namespace VolleyballCompetitionApp.Data
{
	public class MatchRepository : IMatchRepository
	{
		private readonly string _connectionString;

        public MatchRepository(string connectionString)
        {
			_connectionString = connectionString;
        }

        public void Create(int team1ID, int team2ID, int competitionID, string location, int score1ID, int score2ID)
		{
			throw new NotImplementedException();
		}

		public List<MatchModel> GetBy(MatchColumn column, string where, bool lazyLoad = false)
		{
			throw new NotImplementedException();
		}

		public void Update(MatchModel model)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			SqlConnection connection = new SqlConnection(_connectionString);
			var querry = "" +
				"Delete From Match " +
				"Where ID = @id";
			SqlCommand command = new SqlCommand(querry, connection);
			command.Parameters.AddWithValue("id", id);
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}
	}
}
