using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Configuration;
using System.Dynamic;
using VolleyballCompetitionApp.Business;
using VolleyballCompetitionApp.Business.Models;
using VolleyballCompetitionApp.Repository;

namespace VolleyballCompetitionApp.Presentation.Pages.Teams
{
    public class ListModel : PageModel
    {
        public TeamCollection teamCollection { get; private set; }
        public PlayerCollection playerCollection { get; private set; }
        public List<TeamModel> teams { get; set; }

        public ListModel(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("Did you forget the connectionstring?");
            teamCollection = new TeamCollection(new TeamRepository(connectionString), new PlayerRepository(connectionString));
            playerCollection = new PlayerCollection(new PlayerRepository(connectionString));
        }


        public void OnGet(int clubId = -1)
        {
            if (clubId > 0)
            {
                teams = teamCollection.FindTeamByClubId(clubId);
                return;
            }
            teams = teamCollection.GetAllTeams();
        }
	}
}
