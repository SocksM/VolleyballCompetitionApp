using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolleyballCompetitionApp.Business.Models;
using VolleyballCompetitionApp.Repository;

namespace VolleyballCompetitionApp.Business
{
	public class ClubCollection
	{
		private readonly string _connectionString;
		public List<ClubModel> Clubs { get; private set; }

		public ClubCollection(string connectionString) => _connectionString = connectionString;

		public void AddClub(int id, string name, List<TeamModel>? teams = null)
		{
			Clubs.Add(new ClubModel(_connectionString, id, name, teams));
		}

		public void CreateClub(string name)
		{
			// check if parameters are valid
			if (name.Length > 255)
			{
				throw new ArgumentException("Name can't be longer than 255.");
			}

			// database data uploading
			ClubRepository clubRepository = new ClubRepository(_connectionString);
			int id = clubRepository.Create(new Repository.DTOs.ClubDTO
			{
				Name = name
			});

			// if no errors change var in class
			Clubs.Add(new ClubModel(_connectionString, id, name));
		}

		public void DeleteClubById(int id)
		{
			foreach (ClubModel club in Clubs)
			{
				if (club.Id == id)
				{
					// delete the database row with the same id
					ClubRepository clubRepository = new ClubRepository(_connectionString);
					clubRepository.Delete(club.Id);
					// if no error change var in class
					Clubs.Remove(club);
					break;
				}
			}
		}
	}
}