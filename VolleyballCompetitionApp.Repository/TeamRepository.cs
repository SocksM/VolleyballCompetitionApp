﻿using System.Data.SqlClient;
using VolleyballCompetitionApp.Interfaces.DTOs;
using VolleyballCompetitionApp.Interfaces.RepositoryInterfaces;

namespace VolleyballCompetitionApp.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly string _connectionString;

        public TeamRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Create(int clubId, string name) // returns an int because the integer will be auto generated by the database so when you create the row you will be able to know what the id is
        {// the dto parameter shouldnt have a id yet (aka default int value) because the database will decide what the value will be
         // database connection and data uploading 
            SqlConnection connection = new SqlConnection(_connectionString);
            string query = "" +
                "Insert into Team (Name, ClubID) " +
                "Output Inserted.ID " +
                "Values (@name, @clubId)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("name", name);
            command.Parameters.AddWithValue("clubId", clubId);
            connection.Open();
            int id = (int)command.ExecuteScalar();
            connection.Close();
            // no error's? return auto generated id (int)
            return id;
        }

        #region Find Methods
        public TeamDTO FindById(int id) // gets data from the database depending on the id
        {
            // database connection and data fetching
            SqlConnection connection = new SqlConnection(_connectionString);
            string query = "" +
                "select Name, ClubID " +
                "From Team " +
                "Where ID = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("id", id);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            TeamDTO dto = new TeamDTO()
            {
                Name = reader["Name"].ToString(),
                ClubId = int.Parse(reader["ClubID"].ToString()),
                Id = id
            };
            connection.Close();

            // no error's? return filled dto.
            return dto;
        }

        public List<TeamDTO> FindByClubId(int clubId) // gets data from the database depending on the id
        {
            // database connection and data fetching
            SqlConnection connection = new SqlConnection(_connectionString);
            string query = "" +
                "select Name, ID " +
                "From Team " +
                "Where ClubID = @clubId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("clubId", clubId);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            List<TeamDTO> dtos = new List<TeamDTO>();
            while (reader.Read())
            {
                dtos.Add(new TeamDTO()
                {
                    Name = reader["Name"].ToString(),
                    ClubId = clubId,
                    Id = int.Parse(reader["ID"].ToString())
                });
            }
            connection.Close();

            // no error's? return filled dto.
            return dtos;
        }

        #endregion

        public void Update(int id, int clubId, string name) // uses dto.id to dicate to what row it alters then alters that row
        {
            // dto validation (does it have all variable's filled etc?)
            if (name.Length > 255) throw new ArgumentException("Name can't be longer than 255.");
            if (id < 1) throw new ArgumentException("Invalid id");
            if (clubId < 1) throw new ArgumentException("Invalid club id");

            // database connection and data uploading/dating
            SqlConnection connection = new SqlConnection(_connectionString);
            string query = "" +
                "Update Team " +
                "Set Name = @name, ClubID = @clubId " +
                "Where ID = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("name", name);
            command.Parameters.AddWithValue("id", id);
            command.Parameters.AddWithValue("clubId", clubId);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(int id)
        {
            // database connection and data deletion
            SqlConnection connection = new SqlConnection(_connectionString);
            string query = "" +
                "Delete From Team " +
                "Where ID = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("id", id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteByClubId(int clubId)
        {
            // database connection and data deletion
            SqlConnection connection = new SqlConnection(_connectionString);
            string query = "" +
                "Delete From Team " +
                "Where ClubID = @clubId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("clubId", clubId);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<TeamDTO> GetAllTeams()
        {
            // database connection and data fetching
            SqlConnection connection = new SqlConnection(_connectionString);
            string query = "" +
                "select ID, Name, ClubID " +
                "From Team";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<TeamDTO> dtos = new List<TeamDTO>();
            while (reader.Read())
            {
                dtos.Add(new TeamDTO()
                {
                    Name = reader["Name"].ToString(),
                    ClubId = int.Parse(reader["ClubID"].ToString()),
                    Id = int.Parse(reader["ID"].ToString())
                });
            }
            connection.Close();

            // no error's? return filled dto.
            return dtos;
        }
    }
}
