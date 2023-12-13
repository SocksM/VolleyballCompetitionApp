using VolleyballCompetitionApp.Business;
using VolleyballCompetitionApp.Business.Models;
using VolleyballCompetitionApp.UnitTests.DummyRepos;
using VolleyballCompetitionApp.Interfaces.DTOs;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

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

        // find a proper way to validate test
        [Test]
        public void DeleteClubTest() // should also test delete team and player check console output if its all there
        {
            string connectionString = "FakeDBConnString";
            ClubDummyRepository clubRepository = new ClubDummyRepository(connectionString);
            TeamDummyRepository teamRepository = new TeamDummyRepository(connectionString);
            PlayerDummyRepository playerRepository = new PlayerDummyRepository(connectionString);

            ClubCollection clubCollection = new ClubCollection(clubRepository, teamRepository, playerRepository);
            clubCollection.DeleteClubById(1);
            List<int> expectedClubDeletes = [1];
            Assert.That(clubRepository.Deletes, Is.EqualTo(expectedClubDeletes));
            List<int> expectedTeamDeletes = [1];
            Assert.That(teamRepository.Deletes, Is.EqualTo(expectedTeamDeletes));
            List<int> expectedPlayerDeletes = [1];
            Assert.That(playerRepository.Deletes, Is.EqualTo(expectedPlayerDeletes));
        }

        [Test]
        public void DeleteTeamTest() // should also test delete player check console output if its all there
        {
            string connectionString = "FakeDBConnString";
            ClubDummyRepository clubRepository = new ClubDummyRepository(connectionString);
            TeamDummyRepository teamRepository = new TeamDummyRepository(connectionString);
            PlayerDummyRepository playerRepository = new PlayerDummyRepository(connectionString);

            ClubModel clubModel = new ClubModel(clubRepository, teamRepository, playerRepository, 1, "club 1!");
            clubModel.DeleteTeamById(1);
            List<int> expectedTeamDeletes = [1];
            Assert.That(teamRepository.Deletes, Is.EqualTo(expectedTeamDeletes));
            List<int> expectedPlayerDeletes = [1];
            Assert.That(playerRepository.Deletes, Is.EqualTo(expectedPlayerDeletes));
        }

        [Test]
        public void DeletePlayerTest()
        {
            string connectionString = "FakeDBConnString";
            TeamDummyRepository teamRepository = new TeamDummyRepository(connectionString);
            PlayerDummyRepository playerRepository = new PlayerDummyRepository(connectionString);

            TeamModel teamModel = new TeamModel(teamRepository, playerRepository, 1, 1, "tem 1");
            teamModel.DeletePlayerById(1);
            List<int> expectedPlayerDeletes = [1];
            Assert.That(expectedPlayerDeletes, Is.EqualTo(playerRepository.Deletes));
        }

        [Test]
        public void CreateClubTest()
        {
            string connectionString = "FakeDBConnString";
            ClubDummyRepository clubRepository = new ClubDummyRepository(connectionString);
            TeamDummyRepository teamRepository = new TeamDummyRepository(connectionString);
            PlayerDummyRepository playerRepository = new PlayerDummyRepository(connectionString);
            ClubCollection clubCollection = new ClubCollection(clubRepository, teamRepository, playerRepository);
            string name = "club da";
            ClubModel clubModel = clubCollection.CreateClub(name);
            Assert.That(clubModel.Name, Is.EqualTo(name));
            Assert.That(clubModel.Id, Is.GreaterThan(_idLowerBound));
            Assert.That(clubModel.Id, Is.LessThan(_idUpperBound));
        }


        [Test]
        public void CreateClubTestError()
        {
            string connectionString = "FakeDBConnString";
            ClubDummyRepository clubRepository = new ClubDummyRepository(connectionString);
            TeamDummyRepository teamRepository = new TeamDummyRepository(connectionString);
            PlayerDummyRepository playerRepository = new PlayerDummyRepository(connectionString);
            ClubCollection clubCollection = new ClubCollection(clubRepository, teamRepository, playerRepository);
            string name = "";
            int length = 256;
            for (int i = 0; i < length; i++)
            {
                name += "a";
            }
            string expectedExceptionMessage = $"Name can't be longer than 255. Name Currently is currently {length} long.";
            TestDelegate testDelegate = new TestDelegate(() => clubCollection.CreateClub(name));
            Assert.That(Assert.Throws<ArgumentException>(testDelegate).Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void CreateTeamTest()
        {
            string connectionString = "FakeDBConnString";
            ClubModel clubModel = new ClubModel(new ClubDummyRepository(connectionString), new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 20, "club da");
            string name = "team da";
            int clubId = 20;
            TeamModel teamModel = clubModel.CreateTeam(name, clubId);
            Assert.That(teamModel.Name, Is.EqualTo(name));
            Assert.That(teamModel.ClubId, Is.EqualTo(clubId));
            Assert.That(teamModel.Id, Is.GreaterThan(_idLowerBound));
            Assert.That(teamModel.Id, Is.LessThan(_idUpperBound));
        }

        [Test]
        public void CreateTeamTestError()
        {
            string connectionString = "FakeDBConnString";
            ClubModel clubModel = new ClubModel(new ClubDummyRepository(connectionString), new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 20, "club da");
            string name = "";
            int clubId = 20;
            int length = 256;
            for (int i = 0; i < length; i++)
            {
                name += "a";
            }
            string expectedExceptionMessage = $"Name can't be longer than 255. Name Currently is currently {length} long.";
            TestDelegate testDelegate = new TestDelegate(() => clubModel.CreateTeam(name, clubId));
            Assert.That(Assert.Throws<ArgumentException>(testDelegate).Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void CreatePlayerTest()
        {
            string connectionString = "FakeDBConnString";
            TeamModel teamModel = new TeamModel(new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 20, 20, "team da");
            string name = "team da";
            int teamId = 20;
            PlayerModel playerModel = teamModel.CreatePlayer(name, teamId);
            Assert.That(playerModel.Name, Is.EqualTo(name));
            Assert.That(playerModel.TeamId, Is.EqualTo(teamId));
            Assert.That(playerModel.Id, Is.GreaterThan(_idLowerBound));
            Assert.That(playerModel.Id, Is.LessThan(_idUpperBound));
        }

        [Test]
        public void CreatePlayerTestError()
        {
            string connectionString = "FakeDBConnString";
            TeamModel teamModel = new TeamModel(new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 20, 20, "team da");
            string name = "";
            int clubId = 20;
            int length = 256;
            for (int i = 0; i < length; i++)
            {
                name += "a";
            }
            string expectedExceptionMessage = $"Name can't be longer than 255. Name Currently is currently {length} long.";
            TestDelegate testDelegate = new TestDelegate(() => teamModel.CreatePlayer(name, clubId));
            Assert.That(Assert.Throws<ArgumentException>(testDelegate).Message, Is.EqualTo(expectedExceptionMessage));
        }

        // place where i left off
        [Test]
        public void ClubSetNameTest()
        {
            string connectionString = "FakeDBConnString";
            ClubModel clubModel = new ClubModel(new ClubDummyRepository(connectionString), new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 20, "club da");
            string newName = "adaba";
            clubModel.SetName(newName);
            Assert.That(clubModel.Name, Is.EqualTo(newName));
        }

        [Test]
        public void ClubSetNameTestError()
        {
            string connectionString = "FakeDBConnString";
            ClubModel clubModel = new ClubModel(new ClubDummyRepository(connectionString), new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 20, "club da");
            string newName = "";
            int length = 256;
            for (int i = 0; i < length; i++) newName += "a";

            string expectedExceptionMessage = $"Name can't be longer than 255. Name Currently is currently {length} long.";
            TestDelegate testDelegate = new TestDelegate(() => clubModel.SetName(newName));
            Assert.That(Assert.Throws<ArgumentException>(testDelegate).Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void TeamSetNameTest()
        {
            string connectionString = "FakeDBConnString";
            TeamModel teamModel = new TeamModel(new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 20, 20, "team da");
            string newName = "batad";
            teamModel.SetName(newName);
            Assert.That(teamModel.Name, Is.EqualTo(newName));
        }

        [Test]
        public void TeamSetNameError()
        {
            string connectionString = "FakeDBConnString";
            TeamModel teamModel = new TeamModel(new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 20, 20, "team da");
            string newName = "";
            int length = 256;
            for (int i = 0; i < length; i++)
            {
                newName += "a";
            }
            string expectedExceptionMessage = $"Name can't be longer than 255. Name Currently is currently {length} long.";
            TestDelegate testDelegate = new TestDelegate(() => teamModel.SetName(newName));
            Assert.That(Assert.Throws<ArgumentException>(testDelegate).Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void PlayerSetNameTest()
        {
            string connectionString = "FakeDBConnString";
            PlayerModel playerModel = new PlayerModel(new PlayerDummyRepository(connectionString), 20, 20, "player da");
            string newName = "yor";
            playerModel.SetName(newName);
            Assert.That(playerModel.Name, Is.EqualTo(newName));
        }

        [Test]
        public void PlayerSetNameTestError()
        {
            string connectionString = "FakeDBConnString";
            PlayerModel playerModel = new PlayerModel(new PlayerDummyRepository(connectionString), 20, 20, "player da");
            string newName = "";
            int length = 256;
            for (int i = 0; i < length; i++)
            {
                newName += "a";
            }
            string expectedExceptionMessage = $"Name can't be longer than 255. Name Currently is currently {length} long.";
            TestDelegate testDelegate = new TestDelegate(() => playerModel.SetName(newName));
            Assert.That(Assert.Throws<ArgumentException>(testDelegate).Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void FindClubByIDTest()
        {
            const int idToFindBy = 1;
            ClubDTO expectedDTO = new ClubDTO() { Id = 1, Name = "club 1!" };
            string connectionString = "FakeDBConnString";
            ClubCollection clubCollection = new ClubCollection(new ClubDummyRepository(connectionString), new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString));
            ClubModel model = clubCollection.FindClubById(idToFindBy);
            Assert.That(expectedDTO.Id, Is.EqualTo(idToFindBy));
            Assert.That(expectedDTO.Name, Is.EqualTo(model.Name));
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
                Assert.That(models[i].Id, Is.EqualTo(expectedDTOs[i].Id));
                Assert.That(models[i].Name, Is.EqualTo(expectedDTOs[i].Name));
            }
        }

        [Test]
        public void FindTeamByClubIdTest()
        {
            const int idToFindBy = 1;
            TeamDTO expectedDTO = new TeamDTO { Id = 1, ClubId = 1, Name = "tem 1" };
            string connectionString = "FakeDBConnString";
            ClubModel clubModel = new ClubModel(new ClubDummyRepository(connectionString), new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 20, "club da");
            TeamModel model = clubModel.FindTeamByClubId(idToFindBy)[0];
            Assert.That(model.Name, Is.EqualTo(expectedDTO.Name));
            Assert.That(model.Id, Is.EqualTo(expectedDTO.Id));
        }

        [Test]
        public void FindTeamByClubIdUsingDefaultValueTest()
        {
            TeamDTO expectedDTO = new TeamDTO { Id = 1, ClubId = 1, Name = "tem 1" };
            string connectionString = "FakeDBConnString";
            ClubModel clubModel = new ClubModel(new ClubDummyRepository(connectionString), new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 1, "club 1!");
            TeamModel model = clubModel.FindTeamByClubId()[0];
            Assert.That(model.Name, Is.EqualTo(expectedDTO.Name));
            Assert.That(model.Id, Is.EqualTo(expectedDTO.Id));
        }

        [Test]
        public void FindTeamByIdTest()
        {
            const int idToFindBy = 1;
            TeamDTO expectedDTO = new TeamDTO { Id = 1, ClubId = 1, Name = "tem 1" };
            string connectionString = "FakeDBConnString";
            ClubModel clubModel = new ClubModel(new ClubDummyRepository(connectionString), new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 20, "club da");
            TeamModel model = clubModel.FindTeamById(idToFindBy);
            Assert.That(model.Name, Is.EqualTo(expectedDTO.Name));
            Assert.That(model.Id, Is.EqualTo(expectedDTO.Id));
        }

        [Test]
        public void FindPlayerByTeamIdTest()
        {
            const int idToFindBy = 1;
            PlayerDTO expectedDTO = new PlayerDTO { Id = 1, TeamId = 1, Name = "Player 1!!" };
            string connectionString = "FakeDBConnString";
            TeamModel teamModel = new TeamModel(new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 1, 1, "club da");
            PlayerModel model = teamModel.FindPlayerByTeamId(idToFindBy)[0];
            Assert.That(model.Name, Is.EqualTo(expectedDTO.Name));
            Assert.That(model.Id, Is.EqualTo(expectedDTO.Id));
        }

        [Test]
        public void FindPlayerByTeamIdUsingDefaultValueTest()
        {
            PlayerDTO expectedDTO = new PlayerDTO { Id = 1, TeamId = 1, Name = "Player 1!!" };
            string connectionString = "FakeDBConnString";
            TeamModel teamModel = new TeamModel(new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 1, 1, "club da");
            PlayerModel model = teamModel.FindPlayerByTeamId()[0];
            Assert.That(model.Name, Is.EqualTo(expectedDTO.Name));
            Assert.That(model.Id, Is.EqualTo(expectedDTO.Id));
        }

        [Test]
        public void FindPlayerByIdTest()
        {
            const int idToFindBy = 1;
            PlayerDTO expectedDTO = new PlayerDTO { Id = 1, TeamId = 1, Name = "Player 1!!" };
            string connectionString = "FakeDBConnString";
            TeamModel teamModel = new TeamModel(new TeamDummyRepository(connectionString), new PlayerDummyRepository(connectionString), 1, 1, "club da");
            PlayerModel model = teamModel.FindPlayerById(idToFindBy);
            Assert.That(model.Name, Is.EqualTo(expectedDTO.Name));
            Assert.That(model.Id, Is.EqualTo(expectedDTO.Id));
        }
    }
}