using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolleyballCompetitionApp.Business.Player;

namespace VolleyballCompetitionApp.Data
{
	public class PlayerRepository : IPlayerRepository
	{
		private readonly string _connectionString;

        public PlayerRepository(string connectionString)
        {
			_connectionString = connectionString;
        }

        public void Create(int teamID, string name)
		{
			throw new NotImplementedException();
		}

		public List<PlayerModel> GetBy(PlayerColumn column, string where, bool lazyLoad = false)
		{
			throw new NotImplementedException();
		}

		public void Update(PlayerModel model)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			SqlConnection connection = new SqlConnection(_connectionString);
			var querry = "" +
				"Delete From Player " +
				"Where ID = @id";
			SqlCommand command = new SqlCommand(querry, connection);
			command.Parameters.AddWithValue("id", id);
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}
	}
}
