using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.Language;
using VolleyballCompetitionApp.Business;
using VolleyballCompetitionApp.Repository;

namespace VolleyballCompetitionApp.Presentation.Pages.Clubs
{
	public class CreateModel : PageModel
	{
        public ClubCollection clubCollection { get; private set; }

        public CreateModel(IConfiguration configuration)
		{
            string connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("Did you forget the connectionstring?");
            clubCollection = new ClubCollection(new ClubRepository(connectionString), new TeamRepository(connectionString), new PlayerRepository(connectionString));
        }

		public IActionResult OnPost(string clubName) 
		{
			try
			{
				clubCollection.CreateClub(clubName);
			}
			catch (Exception exception)
			{
				TempData["ErrorMessage"] = exception.Message;
				return RedirectToPage($"/Clubs/Create");
			}

			
			return RedirectToPage("/Clubs/List");
		}

		public IActionResult OnPostCancel()
		{
			return RedirectToPage("/Clubs/List");
		}
	}
}
