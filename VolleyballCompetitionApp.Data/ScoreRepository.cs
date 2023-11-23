using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolleyballCompetitionApp.Business.Score;

namespace VolleyballCompetitionApp.Data
{
	public class ScoreRepository : IScoreRepository
	{
		private readonly string _connectionString;

        public ScoreRepository(string connnectionString)
        {
            _connectionString = connnectionString;
        }

        public void Create(int[] scores)
		{
			throw new NotImplementedException();
		}

		public List<ScoreModel> GetBy(ScoreColumn column, string where, bool lazyLoad = false)
		{
			throw new NotImplementedException();
		}

		public void Update(ScoreModel model)
		{
			throw new NotImplementedException();
		}
		public void Delete(int id)
		{
			SqlConnection connection = new SqlConnection(_connectionString);
			var querry = "" +
				"Delete From Score " +
				"Where ID = @id";
			SqlCommand command = new SqlCommand(querry, connection);
			command.Parameters.AddWithValue("id", id);
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}
	}
}
