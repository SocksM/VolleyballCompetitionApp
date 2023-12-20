using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VolleyballCompetitionApp.Business.Models;
using VolleyballCompetitionApp.Business;
using VolleyballCompetitionApp.Repository;
using Microsoft.AspNetCore.Razor.Language;

namespace VolleyballCompetitionApp.Presentation.Pages.Players
{
	public class EditModel : PageModel
	{
        public PlayerCollection playerCollection { get; private set; }
        public PlayerModel player { get; set; }

        public EditModel(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("Did you forget the connectionstring?");
            playerCollection = new PlayerCollection(new PlayerRepository(connectionString));
        }

        public void OnGet(int id)
		{
			player = playerCollection.FindPlayerById(id);
		}

		public IActionResult OnPostEdit(int id, string newPlayerName, int newTeamId)
		{
			player = playerCollection.FindPlayerById(id);
			player.SetName(newPlayerName);
			player.SetTeamId(newTeamId);
			return RedirectToPage("/Players/List");
		}

		public IActionResult OnPostCancel()
		{
			return RedirectToPage("/Players/List");
		}
	}
}
