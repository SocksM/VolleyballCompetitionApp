using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VolleyballCompetitionApp.Business.Models;
using VolleyballCompetitionApp.Business;
using VolleyballCompetitionApp.Repository;
using Microsoft.AspNetCore.Razor.Language;

namespace VolleyballCompetitionApp.Presentation.Pages.Teams
{
	public class EditModel : PageModel
	{
        public TeamCollection teamCollection { get; private set; }
        public TeamModel team { get; set; }

        public EditModel(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("Did you forget the connectionstring?");
            teamCollection = new TeamCollection(new TeamRepository(connectionString), new PlayerRepository(connectionString));
        }

        public void OnGet(int id)
		{
			team = teamCollection.FindTeamById(id);
		}

		public IActionResult OnPostEdit(int id, string newName, int newTeamId)
		{
			try
			{
				team = teamCollection.FindTeamById(id);
				team.SetName(newName);
				team.SetClubId(newTeamId);
			}
			catch (Exception exception)
			{
				TempData["ErrorMessage"] = exception.Message;
				return RedirectToPage($"/Teams/Edit", new { id = id.ToString() });
			}

			return RedirectToPage("/Teams/List");
		}

		public IActionResult OnPostCancel()
		{
			return RedirectToPage("/Teams/List");
		}
	}
}
