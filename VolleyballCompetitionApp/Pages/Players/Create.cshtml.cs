using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.Language;
using VolleyballCompetitionApp.Business;
using VolleyballCompetitionApp.Repository;

namespace VolleyballCompetitionApp.Presentation.Pages.Players
{
	public class CreateModel : PageModel
	{
        public PlayerCollection playerCollection { get; private set; }

        public CreateModel(IConfiguration configuration)
		{
            string connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("Did you forget the connectionstring?");
            playerCollection = new PlayerCollection(new PlayerRepository(connectionString));
        }

		public IActionResult OnPostCreate(int teamId, string playerName) 
		{
			playerCollection.CreatePlayer(playerName, teamId);
			return RedirectToPage("/Players/List");
		}

		public IActionResult OnPostCancel()
		{
			return RedirectToPage("/Players/List");
		}
	}
}
