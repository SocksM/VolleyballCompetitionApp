using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Configuration;
using VolleyballCompetitionApp.Business;
using VolleyballCompetitionApp.Business.Models;
using VolleyballCompetitionApp.Repository;

namespace VolleyballCompetitionApp.Presentation.Pages.Clubs
{
    public class ListModel : PageModel
    {
        
        public ClubCollection clubCollection { get; private set; }
        public TeamCollection teamCollection { get; private set; }
        public PlayerCollection playerCollection { get; private set; }
        public List<ClubModel> clubs { get; private set; }

        public ListModel(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("Did you forget the connectionstring?");
            clubCollection = new ClubCollection(new ClubRepository(connectionString), new TeamRepository(connectionString), new PlayerRepository(connectionString));
            teamCollection = new TeamCollection(new TeamRepository(connectionString), new PlayerRepository(connectionString));
            playerCollection = new PlayerCollection(new PlayerRepository(connectionString));
            clubs = clubCollection.GetAllClubs();
        }
	}
}
