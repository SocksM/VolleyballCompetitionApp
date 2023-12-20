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
    public class Tests
    {
        private const int _idLowerBound = 50;
        private const int _idUpperBound = 1000;

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
            Assert.That(clubModel.Id, Is.GreaterThan(_idLowerBound));
            Assert.That(clubModel.Id, Is.LessThan(_idUpperBound));
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
            Assert.That(teamModel.Id, Is.GreaterThan(_idLowerBound));
            Assert.That(teamModel.Id, Is.LessThan(_idUpperBound));
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
            Assert.That(playerModel.Id, Is.GreaterThan(_idLowerBound));
            Assert.That(playerModel.Id, Is.LessThan(_idUpperBound));
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
            bool allTrueThusFar = true;
            for (int i = 0; i < expectedDTOs.Count; i++)
            {
                Assert.That(models[i].Id, Is.EqualTo(expectedDTOs[i].Id));
                Assert.That(models[i].Name, Is.EqualTo(expectedDTOs[i].Name));
            }
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