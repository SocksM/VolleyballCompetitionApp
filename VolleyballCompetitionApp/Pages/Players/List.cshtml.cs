using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Configuration;
using System.Dynamic;
using VolleyballCompetitionApp.Business;
using VolleyballCompetitionApp.Business.Models;
using VolleyballCompetitionApp.Repository;

namespace VolleyballCompetitionApp.Presentation.Pages.Players
{
    public class ListModel : PageModel
    {
        public PlayerCollection playerCollection { get; private set; }
        public List<PlayerModel> players { get; set; }

        public ListModel(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("Did you forget the connectionstring?");
            playerCollection = new PlayerCollection(new PlayerRepository(connectionString));
        }

        public void OnGet(int clubId = -1, int teamId = -1)
        {
            if (clubId > 0)
            {
                players = playerCollection.FindPlayerByClubId(clubId);
                return;
            }
            if (teamId > 0)
            {
                players = playerCollection.FindPlayerByTeamId(teamId);
                return;
            }
            players = playerCollection.GetAllPlayers();
        }
	}
}
