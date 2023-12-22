using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.Language;
using VolleyballCompetitionApp.Business;
using VolleyballCompetitionApp.Repository;

namespace VolleyballCompetitionApp.Presentation.Pages.Teams
{
	public class CreateModel : PageModel
	{
        public TeamCollection teamCollection { get; private set; }

        public CreateModel(IConfiguration configuration)
		{
            string connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("Did you forget the connectionstring?");
            teamCollection = new TeamCollection(new TeamRepository(connectionString), new PlayerRepository(connectionString));
        }

		public IActionResult OnPostCreate(int clubId, string teamName) 
		{
			try
			{
				teamCollection.CreateTeam(teamName, clubId);
			}
			catch (Exception exception)
			{
				TempData["ErrorMessage"] = exception.Message;
				return RedirectToPage($"/Teams/Create");
			}

			
			return RedirectToPage("/Teams/List");
		}

		public IActionResult OnPostCancel()
		{
			return RedirectToPage("/Teams/List");
		}
	}
}
