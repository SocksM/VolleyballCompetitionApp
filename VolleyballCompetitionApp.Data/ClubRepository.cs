using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolleyballCompetitionApp.Business.Club;
using Microsoft.Data.SqlClient;


namespace VolleyballCompetitionApp.Data
{
	public class ClubRepository : IClubRepository
	{
		private readonly string _connectionString;

		public ClubRepository(string connnectionString)
		{
			_connectionString = connnectionString;
		}

		public void Create(string name)
		{
			SqlConnection connection = new SqlConnection(_connectionString);
			var querry = "" +
				"Insert Into Club (Name) " +
				"Values (@name)";
			SqlCommand command = new SqlCommand(querry, connection);
			command.Parameters.AddWithValue("name", name);
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}

		public List<ClubModel> GetBy(ClubColumn column, string where, bool lazyLoad = false)
		{
			throw new NotImplementedException();
		}

		public void Update(ClubModel model)
		{
			SqlConnection connection = new SqlConnection(_connectionString);
			var querry = "" +
				"Update company " +
				"Set Name = @name " +
				"Where ID = @id";
			SqlCommand command = new SqlCommand(querry, connection);
			command.Parameters.AddWithValue("name", model.ddd);
			command.Parameters.AddWithValue("id", model.ID);
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}

		public void Delete(int id)
		{
			SqlConnection connection = new SqlConnection(_connectionString);
			var querry = "" +
				"Delete From Club " +
				"Where ID = @id";
			SqlCommand command = new SqlCommand(querry, connection);
			command.Parameters.AddWithValue("id", id);
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}
	}
}
