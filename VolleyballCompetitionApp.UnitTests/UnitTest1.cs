using VolleyballCompetitionApp.Business;
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
		public void CreateClubTest ()
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
			for (int i = 0; i < length; i++)
			{
				name += "a";
			}
			try
			{
				ClubModel clubModel = clubCollection.CreateClub(name);
			}
			catch (ArgumentException exception)
			{
				ArgumentException expectedException = new ArgumentException($"Name can't be longer than 255.  Name Currently is currently {length} long.");
				Assert.True(exception.Message == expectedException.Message);
				
			}
		}
	}
}