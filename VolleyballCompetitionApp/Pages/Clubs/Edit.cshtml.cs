using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VolleyballCompetitionApp.Business.Models;
using VolleyballCompetitionApp.Business;
using VolleyballCompetitionApp.Repository;

namespace VolleyballCompetitionApp.Presentation.Pages.Clubs
{
	public class EditModel : PageModel
	{
		private ClubCollection clubCollection;
		public ClubModel club { get; set; }

		public EditModel(IConfiguration configuration)
		{
			string connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("Did you forget the connectionstring?");
			clubCollection = new ClubCollection(new ClubRepository(connectionString), new TeamRepository(connectionString), new PlayerRepository(connectionString));
		}

		public void OnGet(int id)
		{
			club = clubCollection.FindClubById(id);
		}

		public IActionResult OnPost(int id, string newName, bool editConfirmed)
		{
			if (editConfirmed)
			{
				club = clubCollection.FindClubById(id);
				club.SetName(newName);
			}
			return RedirectToPage("Index");
		}
	}
}