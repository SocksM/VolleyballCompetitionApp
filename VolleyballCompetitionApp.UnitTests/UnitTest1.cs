using System;
using System.Xml.Linq;
using System.Xml.Serialization;
using VolleyballCompetitionApp.Business;
using VolleyballCompetitionApp.Business.DTOs;
using VolleyballCompetitionApp.Business.Models;
using VolleyballCompetitionApp.UnitTests.DummyRepos;

namespace VolleyballCompetitionApp.UnitTests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		// find a proper way to validate test
		[Test]
		public void DeleteClubTest() // should also test delete team and player check console output if its all there
		{
			string connectionString = "FakeDBConnString";
			ClubCollection clubCollection = new ClubCollection(new ClubDummyRepository(connectionString), new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString));
			clubCollection.DeleteClubById(1);

			// Check if console ouput is:
			/* Created a club dummy repo with the connection string: "FakeDBConnString"
			 * Created a team dummy repo with the connection string: "FakeDBConnString"
			 * Created a player dummy repo with the connection string: "FakeDBConnString"
			 * Deleted ClubId: 1
			 * Deleted PlayerId: 1
			 * Deleted TeamId: 1 
			 */
		}

		[Test]
		public void DeleteTeamTest() // should also test delete player check console output if its all there
		{
			string connectionString = "FakeDBConnString";
			ClubModel clubModel = new ClubModel(new ClubDummyRepository(connectionString), new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 1, "club 1!");
			clubModel.DeleteTeamById(1);

			// Check if console ouput is:
			/* Created a club dummy repo with the connection string: "FakeDBConnString"
			 * Created a team dummy repo with the connection string: "FakeDBConnString"
			 * Created a player dummy repo with the connection string: "FakeDBConnString"
			 * Deleted PlayerId: 1
			 * Deleted TeamId: 1 
			 */
		}

		[Test]
		public void DeletePlayerTest()
		{
			string connectionString = "FakeDBConnString";
			TeamModel teamModel = new TeamModel(new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 1, 1, "tem 1");
			teamModel.DeletePlayerById(1);

			// Check if console ouput is:
			/* Created a team dummy repo with the connection string: "FakeDBConnString"
			 * Created a player dummy repo with the connection string: "FakeDBConnString"
			 * Deleted PlayerId: 1
			 */
		}

		[Test]
		public void CreateClubTest()
		{
			string connectionString = "FakeDBConnString";
			ClubCollection clubCollection = new ClubCollection(new ClubDummyRepository(connectionString), new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString));
			string name = "club da";
			ClubModel clubModel = clubCollection.CreateClub(name);
			bool assert = true;
			if (!(clubModel.Name == name)) assert = false;
			if (!(clubModel.Id > 50 & clubModel.Id < 1000)) assert = false;
			Assert.True(assert);
		}

		[Test]
		public void CreateClubTestError()
		{
			string connectionString = "FakeDBConnString";
			ClubCollection clubCollection = new ClubCollection(new ClubDummyRepository(connectionString), new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString));
			string name = "";
			int length = 256;
			for (int i = 0; i < length; i++) name += "a";
			ArgumentException exception = new ArgumentException();
			try
			{
				clubCollection.CreateClub(name);
			}
			catch (ArgumentException caughtException)
			{
				exception = caughtException;
			}
			finally
			{
				ArgumentException expectedException = new ArgumentException($"Name can't be longer than 255. Name Currently is currently {length} long.");
				Assert.True(exception.Message == expectedException.Message);
			}
		}

		[Test]
		public void CreateTeamTest()
		{
			string connectionString = "FakeDBConnString";
			ClubModel clubModel = new ClubModel(new ClubDummyRepository(connectionString), new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 20, "club da");
			string name = "team da";
			int clubId = 20;
			TeamModel teamModel = clubModel.CreateTeam(name, clubId);
			bool assert = true;
			if (!(teamModel.Name == name)) assert = false;
			if (!(teamModel.ClubId == clubId)) assert = false;
			if (!(teamModel.Id > 50 & teamModel.Id < 1000)) assert = false;
			Assert.True(assert);
		}

		[Test]
		public void CreateTeamTestError()
		{
			string connectionString = "FakeDBConnString";
			ClubModel clubModel = new ClubModel(new ClubDummyRepository(connectionString), new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 20, "club da");
			string name = "";
			int clubId = 20;
			int length = 256;
			for (int i = 0; i < length; i++) name += "a";
			ArgumentException exception = new ArgumentException();
			try
			{
				clubModel.CreateTeam(name, clubId);
			}
			catch (ArgumentException caughtException)
			{
				exception = caughtException;
			}
			finally
			{
				ArgumentException expectedException = new ArgumentException($"Name can't be longer than 255. Name Currently is currently {length} long.");
				Assert.True(exception.Message == expectedException.Message);
			}
		}

		[Test]
		public void CreatePlayerTest()
		{
			string connectionString = "FakeDBConnString";
			TeamModel teamModel = new TeamModel(new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 20, 20, "team da");
			string name = "team da";
			int teamId = 20;
			PlayerModel playerModel = teamModel.CreatePlayer(name, teamId);
			bool assert = true;
			if (!(playerModel.Name == name)) assert = false;
			if (!(playerModel.TeamId == teamId)) assert = false;
			if (!(playerModel.Id > 50 & playerModel.Id < 1000)) assert = false;
			Assert.True(assert);
		}

		[Test]
		public void CreatePlayerTestError()
		{
			string connectionString = "FakeDBConnString";
			TeamModel teamModel = new TeamModel(new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 20, 20, "team da");
			string name = "";
			int clubId = 20;
			int length = 256;
			for (int i = 0; i < length; i++) name += "a";
			ArgumentException exception = new ArgumentException();
			try
			{
				teamModel.CreatePlayer(name, clubId);
			}
			catch (ArgumentException caughtException)
			{
				exception = caughtException;
			}
			finally
			{
				ArgumentException expectedException = new ArgumentException($"Name can't be longer than 255. Name Currently is currently {length} long.");
				Assert.True(exception.Message == expectedException.Message);
			}
		}

		[Test]
		public void ClubSetNameTest()
		{
			string connectionString = "FakeDBConnString";
			ClubModel clubModel = new ClubModel(new ClubDummyRepository(connectionString), new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 20, "club da");
			string newName = "adaba";
			clubModel.SetName(newName);
			Assert.True(newName == clubModel.Name);
		}

		[Test]
		public void ClubSetNameTestError()
		{
			string connectionString = "FakeDBConnString";
			ClubModel clubModel = new ClubModel(new ClubDummyRepository(connectionString), new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 20, "club da");
			string newName = "";
			int length = 256;
			for (int i = 0; i < length; i++) newName += "a";
			ArgumentException exception = new ArgumentException();
			try
			{
				clubModel.SetName(newName);
			}
			catch (ArgumentException caughtException)
			{
				exception = caughtException;
			}
			finally
			{
				ArgumentException expectedException = new ArgumentException($"Name can't be longer than 255. Name Currently is currently {length} long.");
				Assert.True(exception.Message == expectedException.Message);
			}
		}

		[Test]
		public void TeamSetNameTest()
		{
			string connectionString = "FakeDBConnString";
			TeamModel teamModel = new TeamModel(new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 20, 20, "team da");
			string newName = "batad";
			teamModel.SetName(newName);
			Assert.True(newName == teamModel.Name);
		}

		[Test]
		public void TeamSetNameError()
		{
			string connectionString = "FakeDBConnString";
			TeamModel teamModel = new TeamModel(new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 20, 20, "team da");
			string newName = "";
			int length = 256;
			for (int i = 0; i < length; i++) newName += "a";
			ArgumentException exception = new ArgumentException();
			try
			{
				teamModel.SetName(newName);
			}
			catch (ArgumentException caughtException)
			{
				exception = caughtException;
			}
			finally
			{
				ArgumentException expectedException = new ArgumentException($"Name can't be longer than 255. Name Currently is currently {length} long.");
				Assert.True(exception.Message == expectedException.Message);
			}
		}

		[Test]
		public void PlayerSetNameTest()
		{
			string connectionString = "FakeDBConnString";
			PlayerModel playerModel = new PlayerModel(new PlayerDummyRepository(connectionString), 20, 20, "player da");
			string newName = "yor";
			playerModel.SetName(newName);
			Assert.True(newName == playerModel.Name);
		}

		[Test]
		public void PlayerSetNameTestError()
		{
			string connectionString = "FakeDBConnString";
			PlayerModel playerModel = new PlayerModel(new PlayerDummyRepository(connectionString), 20, 20, "player da");
			string newName = "";
			int length = 256;
			for (int i = 0; i < length; i++) newName += "a";
			ArgumentException exception = new ArgumentException();
			try
			{
				playerModel.SetName(newName);
			}
			catch (ArgumentException caughtException)
			{
				exception = caughtException;
			}
			finally
			{
				ArgumentException expectedException = new ArgumentException($"Name can't be longer than 255. Name Currently is currently {length} long.");
				Assert.True(exception.Message == expectedException.Message);
			}
		}

		[Test]
		public void FindClubByIDTest()
		{
			ClubDTO expectedDTO = new ClubDTO() { Id = 1, Name = "club 1!" };
			string connectionString = "FakeDBConnString";
			ClubCollection clubCollection = new ClubCollection(new ClubDummyRepository(connectionString), new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString));
			ClubModel model = clubCollection.FindClubById(1);
			Assert.True(model.Name == expectedDTO.Name && model.Id == expectedDTO.Id);
		}

		[Test]
		public void GetAllClubsTest()
		{
			string connectionString = "FakeDBConnString";
			List<ClubDTO> expectedDTOs = [
				new ClubDTO() { Id = 1, Name = "club 1!" },
				new ClubDTO() { Id = 2, Name = "2 club?" }
			];
			ClubCollection clubCollection = new ClubCollection(new ClubDummyRepository(connectionString), new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString));
			List<ClubModel> models = clubCollection.GetAllClubs();
			bool allTrueThusFar = true;
			for (int i = 0; i < expectedDTOs.Count; i++)
			{
				if (!(expectedDTOs[i].Id == models[i].Id && expectedDTOs[i].Name == models[i].Name))
				{
					allTrueThusFar = false; 
					break;
				}
			}
			Assert.True(allTrueThusFar);
		}

		[Test]
		public void FindTeamByClubIdTest()
		{
			TeamDTO expectedDTO = new TeamDTO { Id = 1, ClubId = 1, Name = "tem 1" };
			string connectionString = "FakeDBConnString";
			ClubModel clubModel = new ClubModel(new ClubDummyRepository(connectionString), new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 20, "club da");
			TeamModel model = clubModel.FindTeamByClubId(1)[0];
			Assert.True(model.Name == expectedDTO.Name && model.Id == expectedDTO.Id);
		}

		[Test]
		public void FindTeamByClubIdUsingDefaultValueTest()
		{
			TeamDTO expectedDTO = new TeamDTO { Id = 1, ClubId = 1, Name = "tem 1" };
			string connectionString = "FakeDBConnString";
			ClubModel clubModel = new ClubModel(new ClubDummyRepository(connectionString), new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 1, "club 1!");
			TeamModel model = clubModel.FindTeamByClubId()[0];
			Assert.True(model.Name == expectedDTO.Name && model.Id == expectedDTO.Id);
		}

		[Test]
		public void FindTeamByIdTest()
		{
			TeamDTO expectedDTO = new TeamDTO { Id = 1, ClubId = 1, Name = "tem 1" };
			string connectionString = "FakeDBConnString";
			ClubModel clubModel = new ClubModel(new ClubDummyRepository(connectionString), new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 20, "club da");
			TeamModel model = clubModel.FindTeamById(1);
			Assert.True(model.Name == expectedDTO.Name && model.Id == expectedDTO.Id);
		}

		[Test]
		public void FindPlayerByTeamIdTest()
		{
			PlayerDTO expectedDTO = new PlayerDTO { Id = 1, TeamId = 1, Name = "Player 1!!" };
			string connectionString = "FakeDBConnString";
			TeamModel teamModel = new TeamModel(new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 1, 1, "club da");
			PlayerModel model = teamModel.FindPlayerByTeamId(1)[0];
			Assert.True(model.Name == expectedDTO.Name && model.Id == expectedDTO.Id);
		}

		[Test]
		public void FindPlayerByTeamIdUsingDefaultValueTest()
		{
			PlayerDTO expectedDTO = new PlayerDTO { Id = 1, TeamId = 1, Name = "Player 1!!" };
			string connectionString = "FakeDBConnString";
			TeamModel teamModel = new TeamModel(new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 1, 1, "club da");
			PlayerModel model = teamModel.FindPlayerByTeamId()[0];
			Assert.True(model.Name == expectedDTO.Name && model.Id == expectedDTO.Id);
		}

		[Test]
		public void FindPlayerByIdTest()
		{
			PlayerDTO expectedDTO = new PlayerDTO { Id = 1, TeamId = 1, Name = "Player 1!!" };
			string connectionString = "FakeDBConnString";
			TeamModel teamModel = new TeamModel(new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 1, 1, "club da");
			PlayerModel model = teamModel.FindPlayerById(1);
			Assert.True(model.Name == expectedDTO.Name && model.Id == expectedDTO.Id);
		}
	}
}