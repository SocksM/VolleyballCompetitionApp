using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VolleyballCompetitionApp.Business.Models;
using VolleyballCompetitionApp.Business;
using VolleyballCompetitionApp.Repository;
using Microsoft.AspNetCore.Razor.Language;

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

		public IActionResult OnPostEdit(int id, string newClubName)
		{
			try
			{
				clubCollection.FindClubById(id).SetName(newClubName);
			}
			catch (Exception exception)
			{
				TempData["ErrorMessage"] = exception.Message;
				return RedirectToPage($"/Clubs/Edit", new { id = id.ToString()});
			}
			
			return RedirectToPage("/Clubs/List");
		}

		public IActionResult OnPostCancel()
		{
			return RedirectToPage("/Clubs/List");
		}
	}
}
