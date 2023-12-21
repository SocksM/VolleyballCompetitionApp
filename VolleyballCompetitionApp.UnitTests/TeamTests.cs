using VolleyballCompetitionApp.Business;
using VolleyballCompetitionApp.Business.Models;
using VolleyballCompetitionApp.UnitTests.DummyRepos;
using VolleyballCompetitionApp.Interfaces.DTOs;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using VolleyballCompetitionApp.Repository;
using VolleyballCompetitionApp.Interfaces.RepositoryInterfaces;

namespace VolleyballCompetitionApp.UnitTests
{
	public class TeamTests
	{
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		public void DeleteTeamTest()
		{
			// arange
			ClubDummyRepository clubRepository = new ClubDummyRepository();
			TeamDummyRepository teamRepository = new TeamDummyRepository();
			PlayerDummyRepository playerRepository = new PlayerDummyRepository();

			TeamCollection teamCollection = new TeamCollection(teamRepository, playerRepository);

			// act
			teamCollection.DeleteTeamById(1);

			// assert
			List<int> expectedTeamDeletes = [1];
			Assert.That(teamRepository.Deletes, Is.EqualTo(expectedTeamDeletes));
			List<int> expectedPlayerDeletes = [1];
			Assert.That(playerRepository.Deletes, Is.EqualTo(expectedPlayerDeletes));
		}

		[Test]
		public void CreateTeamTest()
		{
			// arange
			TeamDummyRepository teamRepository = new TeamDummyRepository();
			PlayerDummyRepository playerRepository = new PlayerDummyRepository();
			TeamCollection teamCollection = new TeamCollection(teamRepository, playerRepository);
			const string name = "team da";
			int clubId = 20;

			// act
			TeamModel teamModel = teamCollection.CreateTeam(name, clubId);

			// assert
			Assert.That(teamModel.Name, Is.EqualTo(name));
			Assert.That(teamModel.ClubId, Is.EqualTo(clubId));
			Assert.That(teamModel.Id, Is.EqualTo(50));
		}

		[Test]
		public void CreateTeamTestError()
		{
			// arange
			TeamDummyRepository teamRepository = new TeamDummyRepository();
			PlayerDummyRepository playerRepository = new PlayerDummyRepository();
			TeamCollection teamCollection = new TeamCollection(teamRepository, playerRepository);
			string name = "";
			const int clubId = 20;
			const int length = 256;
			for (int i = 0; i < length; i++)
			{
				name += "a";
			}
			string expectedExceptionMessage = $"Name can't be longer than 255. Name Currently is currently {length} long.";
			TestDelegate testDelegate = new TestDelegate(() => teamCollection.CreateTeam(name, clubId));

			// act & assert
			Assert.That(Assert.Throws<ArgumentException>(testDelegate).Message, Is.EqualTo(expectedExceptionMessage));
		}

		[Test]
		public void TeamSetNameTest()
		{
			// arange
			TeamDummyRepository teamRepository = new TeamDummyRepository();
			PlayerDummyRepository playerRepository = new PlayerDummyRepository();
			TeamCollection teamCollection = new TeamCollection(teamRepository, playerRepository);
			TeamModel teamModel = teamCollection.FindTeamById(1);
			const string newName = "batad";

			// act
			teamModel.SetName(newName);

			// assert
			Assert.That(teamModel.Name, Is.EqualTo(newName));
		}

		[Test]
		public void TeamSetNameError()
		{
			// arange
			TeamDummyRepository teamRepository = new TeamDummyRepository();
			PlayerDummyRepository playerRepository = new PlayerDummyRepository();
			TeamCollection teamCollection = new TeamCollection(teamRepository, playerRepository);
			TeamModel teamModel = teamCollection.FindTeamById(1);
			string newName = "";
			const int length = 256;
			for (int i = 0; i < length; i++)
			{
				newName += "a";
			}
			string expectedExceptionMessage = $"Name can't be longer than 255. Name Currently is currently {length} long.";
			TestDelegate testDelegate = new TestDelegate(() => teamModel.SetName(newName));

			// act & assert
			Assert.That(Assert.Throws<ArgumentException>(testDelegate).Message, Is.EqualTo(expectedExceptionMessage));
		}

		[Test]
		public void FindTeamByClubIdTest()
		{
			// arange
			const int idToFindBy = 1;
			TeamDTO expectedDTO = new TeamDTO { Id = 1, ClubId = 1, Name = "tem 1" };
			TeamDummyRepository teamRepository = new TeamDummyRepository();
			PlayerDummyRepository playerRepository = new PlayerDummyRepository();
			TeamCollection teamCollection = new TeamCollection(teamRepository, playerRepository);
			
			// act 
			TeamModel model = teamCollection.FindTeamByClubId(idToFindBy)[0];

			// assert
			Assert.That(model.Name, Is.EqualTo(expectedDTO.Name));
			Assert.That(model.Id, Is.EqualTo(expectedDTO.Id));
		}

		[Test]
		public void FindTeamByIdTest()
		{
			// arange
			const int idToFindBy = 1;
			TeamDTO expectedDTO = new TeamDTO { Id = 1, ClubId = 1, Name = "tem 1" };
			TeamDummyRepository teamRepository = new TeamDummyRepository();
			PlayerDummyRepository playerRepository = new PlayerDummyRepository();
			TeamCollection teamCollection = new TeamCollection(teamRepository, playerRepository);
			
			// act
			TeamModel model = teamCollection.FindTeamById(idToFindBy);

			// assert
			Assert.That(model.Name, Is.EqualTo(expectedDTO.Name));
			Assert.That(model.Id, Is.EqualTo(expectedDTO.Id));
		}
	}
}