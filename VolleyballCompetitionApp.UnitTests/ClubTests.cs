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
	public class ClubTests
	{
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		public void DeleteClubTest()
		{
			// arange
			ClubDummyRepository clubRepository = new ClubDummyRepository();
			TeamDummyRepository teamRepository = new TeamDummyRepository();
			PlayerDummyRepository playerRepository = new PlayerDummyRepository();

			ClubCollection clubCollection = new ClubCollection(clubRepository, teamRepository, playerRepository);
			
			// act
			clubCollection.DeleteClubById(1);

			// assert
			List<int> expectedClubDeletes = [1];
			Assert.That(clubRepository.Deletes, Is.EqualTo(expectedClubDeletes));
			List<int> expectedTeamDeletes = [1];
			Assert.That(teamRepository.Deletes, Is.EqualTo(expectedTeamDeletes));
			List<int> expectedPlayerDeletes = [1];
			Assert.That(playerRepository.Deletes, Is.EqualTo(expectedPlayerDeletes));
		}
		
		[Test]
		public void CreateClubTest()
		{
			// arange
			ClubDummyRepository clubRepository = new ClubDummyRepository();
			TeamDummyRepository teamRepository = new TeamDummyRepository();
			PlayerDummyRepository playerRepository = new PlayerDummyRepository();
			ClubCollection clubCollection = new ClubCollection(clubRepository, teamRepository, playerRepository);
			const string name = "club da";

			// act
			ClubModel clubModel = clubCollection.CreateClub(name);

			// assert
			Assert.That(clubModel.Name, Is.EqualTo(name));
			Assert.That(clubModel.Id, Is.EqualTo(50));
		}


		[Test]
		public void CreateClubTestError()
		{
			// arange
			ClubDummyRepository clubRepository = new ClubDummyRepository();
			TeamDummyRepository teamRepository = new TeamDummyRepository();
			PlayerDummyRepository playerRepository = new PlayerDummyRepository();
			ClubCollection clubCollection = new ClubCollection(clubRepository, teamRepository, playerRepository);
			string name = "";
			const int length = 256;
			for (int i = 0; i < length; i++)
			{
				name += "a";
			}
			string expectedExceptionMessage = $"Name can't be longer than 255. Name Currently is currently {length} long.";
			TestDelegate testDelegate = new TestDelegate(() => clubCollection.CreateClub(name));

			// act & assert
			Assert.That(Assert.Throws<ArgumentException>(testDelegate).Message, Is.EqualTo(expectedExceptionMessage));
		}

		[Test]
		public void ClubSetNameTest()
		{
			// arange
			ClubDummyRepository clubRepository = new ClubDummyRepository();
			TeamDummyRepository teamRepository = new TeamDummyRepository();
			PlayerDummyRepository playerRepository = new PlayerDummyRepository();
			ClubCollection clubCollection = new ClubCollection(clubRepository, teamRepository, playerRepository);
			ClubModel clubModel = clubCollection.FindClubById(1);
			const string newName = "adaba";
			
			// act
			clubModel.SetName(newName);

			// assert
			Assert.That(clubModel.Name, Is.EqualTo(newName));
		}

		[Test]
		public void ClubSetNameTestError()
		{
			// arange
			ClubDummyRepository clubRepository = new ClubDummyRepository();
			TeamDummyRepository teamRepository = new TeamDummyRepository();
			PlayerDummyRepository playerRepository = new PlayerDummyRepository();
			ClubCollection clubCollection = new ClubCollection(clubRepository, teamRepository, playerRepository);
			ClubModel clubModel = clubCollection.FindClubById(1);
			string newName = "";
			const int length = 256;
			for (int i = 0; i < length; i++)
			{
				newName += "a";
			}
			string expectedExceptionMessage = $"Name can't be longer than 255. Name Currently is currently {length} long.";
			TestDelegate testDelegate = new TestDelegate(() => clubModel.SetName(newName));

			// act & assert
			Assert.That(Assert.Throws<ArgumentException>(testDelegate).Message, Is.EqualTo(expectedExceptionMessage));
		}

		[Test]
		public void FindClubByIDTest()
		{
			// arange
			const int idToFindBy = 1;
			ClubDTO expectedDTO = new ClubDTO() { Id = 1, Name = "club 1!" };
			ClubDummyRepository clubRepository = new ClubDummyRepository();
			TeamDummyRepository teamRepository = new TeamDummyRepository();
			PlayerDummyRepository playerRepository = new PlayerDummyRepository();
			ClubCollection clubCollection = new ClubCollection(clubRepository, teamRepository, playerRepository);

			// act
			ClubModel model = clubCollection.FindClubById(idToFindBy);

			// assert
			Assert.That(expectedDTO.Id, Is.EqualTo(idToFindBy));
			Assert.That(expectedDTO.Name, Is.EqualTo(model.Name));
		}

		[Test]
		public void GetAllClubsTest()
		{
			// arange
			List<ClubDTO> expectedDTOs = [
				new ClubDTO() { Id = 1, Name = "club 1!" },
				new ClubDTO() { Id = 2, Name = "2 club?" }
			];
			ClubDummyRepository clubRepository = new ClubDummyRepository();
			TeamDummyRepository teamRepository = new TeamDummyRepository();
			PlayerDummyRepository playerRepository = new PlayerDummyRepository();
			ClubCollection clubCollection = new ClubCollection(clubRepository, teamRepository, playerRepository);

			// act
			List<ClubModel> models = clubCollection.GetAllClubs();

			// assert
			for (int i = 0; i < expectedDTOs.Count; i++)
			{
				Assert.That(models[i].Id, Is.EqualTo(expectedDTOs[i].Id));
				Assert.That(models[i].Name, Is.EqualTo(expectedDTOs[i].Name));
			}
		}
	}
}