using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Configuration;
using System.Dynamic;
using VolleyballCompetitionApp.Business;
using VolleyballCompetitionApp.Business.Models;
using VolleyballCompetitionApp.Repository;

namespace VolleyballCompetitionApp.Presentation.Pages.Players
{
    public class IndexModel : PageModel
    {
        private string _connectionString;
        public List<PlayerModel> players { get; set; }

        public IndexModel(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("Did you forget the connectionstring?");
        }

        public void OnGet(int clubId = -1, int teamId = -1)
        {
            PlayerCollection playerCollection = new PlayerCollection(new PlayerRepository(_connectionString));
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

		public IActionResult OnCancel()
		{
			return RedirectToPage("Index");
		}
	}
}
