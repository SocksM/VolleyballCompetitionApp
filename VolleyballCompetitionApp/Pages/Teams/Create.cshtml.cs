using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VolleyballCompetitionApp.Business;
using VolleyballCompetitionApp.Repository;

namespace VolleyballCompetitionApp.Presentation.Pages.Teams
{
	public class CreateModel : PageModel
	{
		private ClubCollection clubCollection;

		public CreateModel(IConfiguration configuration)
		{
			string connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("Did you forget the connectionstring?");
			clubCollection = new ClubCollection(new ClubRepository(connectionString), new TeamRepository(connectionString), new PlayerRepository(connectionString));
		}

		public IActionResult OnPost(string clubName) 
		{ 
			clubCollection.CreateClub(clubName);
			return RedirectToPage("Index");
		}

		public IActionResult OnCancel()
		{
			return RedirectToPage("Index");
		}
	}
}
