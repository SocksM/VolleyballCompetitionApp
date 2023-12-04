using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolleyballCompetitionApp.Business.Competition;

namespace VolleyballCompetitionApp.Data
{
	public class CompetitionRepository : ICompetitionRepository
	{
		private readonly string _connectionString;

        public CompetitionRepository(string connectionString)
        {
			_connectionString = connectionString;
        }

        public void Create(DateOnly start, DateOnly end, string name)
		{
			throw new NotImplementedException();
		}

		public List<CompetitionModel> GetBy(CompetitionColumn column, string where, bool lazyLoad = false)
		{
			throw new NotImplementedException();
		}

		public void Update(CompetitionModel model)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			SqlConnection connection = new SqlConnection(_connectionString);
			var querry = "" +
				"Delete From Competition " +
				"Where ID = @id";
			SqlCommand command = new SqlCommand(querry, connection);
			command.Parameters.AddWithValue("id", id);
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}
	}
}
