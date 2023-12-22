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
	public class PlayerTests
	{
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		public void DeletePlayerTest()
		{
			// arange
			TeamDummyRepository teamRepository = new TeamDummyRepository();
			PlayerDummyRepository playerRepository = new PlayerDummyRepository();

			PlayerCollection playerCollection = new PlayerCollection(playerRepository);

			// act
			playerCollection.DeletePlayerById(1);

			// assert
			List<int> expectedPlayerDeletes = [1];
			Assert.That(expectedPlayerDeletes, Is.EqualTo(playerRepository.Deletes));
		}
		
		[Test]
		public void CreatePlayerTest()
		{
			// arange
			PlayerDummyRepository playerRepository = new PlayerDummyRepository();
			PlayerCollection playerCollection = new PlayerCollection(playerRepository);
			const string name = "player da";
			const int teamId = 20;

			// act
			PlayerModel playerModel = playerCollection.CreatePlayer(name, teamId);

			// assert
			Assert.That(playerModel.Name, Is.EqualTo(name));
			Assert.That(playerModel.TeamId, Is.EqualTo(teamId));
			Assert.That(playerModel.Id, Is.EqualTo(50));
		}

		[Test]
		public void CreatePlayerTestError()
		{
			// arange
			PlayerDummyRepository playerRepository = new PlayerDummyRepository();
			PlayerCollection playerCollection = new PlayerCollection(playerRepository);
			string name = "";
			const int clubId = 20;
			const int length = 256;
			for (int i = 0; i < length; i++)
			{
				name += "a";
			}
			string expectedExceptionMessage = $"Name can't be longer than 255. Name Currently is currently {length} long.";
			TestDelegate testDelegate = new TestDelegate(() => playerCollection.CreatePlayer(name, clubId));

			// act & assert
			Assert.That(Assert.Throws<ArgumentException>(testDelegate).Message, Is.EqualTo(expectedExceptionMessage));
		}

		[Test]
		public void PlayerSetNameTest()
		{
			// arange
			PlayerDummyRepository playerRepository = new PlayerDummyRepository();
			PlayerCollection playerCollection = new PlayerCollection(playerRepository);
			PlayerModel playerModel = playerCollection.FindPlayerById(1);
			const string newName = "yor";

			// act 
			playerModel.SetName(newName);

			// assert
			Assert.That(playerModel.Name, Is.EqualTo(newName));
		}

		[Test]
		public void PlayerSetNameTestError()
		{
			// arange
			PlayerDummyRepository playerRepository = new PlayerDummyRepository();
			PlayerCollection playerCollection = new PlayerCollection(playerRepository);
			PlayerModel playerModel = playerCollection.FindPlayerById(1);
			string newName = "";
			const int length = 256;
			for (int i = 0; i < length; i++)
			{
				newName += "a";
			}
			string expectedExceptionMessage = $"Name can't be longer than 255. Name Currently is currently {length} long.";
			TestDelegate testDelegate = new TestDelegate(() => playerModel.SetName(newName));

			// act & assert
			Assert.That(Assert.Throws<ArgumentException>(testDelegate).Message, Is.EqualTo(expectedExceptionMessage));
		}

		[Test]
		public void FindPlayerByTeamIdTest()
		{
			// arange
			const int idToFindBy = 1;
			PlayerDTO expectedDTO = new PlayerDTO { Id = 1, TeamId = 1, Name = "Player 1!!" };
			PlayerDummyRepository playerRepository = new PlayerDummyRepository();
			PlayerCollection playerCollection = new PlayerCollection(playerRepository);

			// act
			PlayerModel model = playerCollection.FindPlayerByTeamId(idToFindBy)[0];

			// assert
			Assert.That(model.Name, Is.EqualTo(expectedDTO.Name));
			Assert.That(model.Id, Is.EqualTo(expectedDTO.Id));
		}

		[Test]
		public void FindPlayerByIdTest()
		{
			// arange
			const int idToFindBy = 1;
			PlayerDTO expectedDTO = new PlayerDTO { Id = 1, TeamId = 1, Name = "Player 1!!" };
			PlayerDummyRepository playerRepository = new PlayerDummyRepository();
			PlayerCollection playerCollection = new PlayerCollection(playerRepository);

			// act
			PlayerModel model = playerCollection.FindPlayerById(idToFindBy);

			// assert
			Assert.That(model.Name, Is.EqualTo(expectedDTO.Name));
			Assert.That(model.Id, Is.EqualTo(expectedDTO.Id));
		}
	}
}