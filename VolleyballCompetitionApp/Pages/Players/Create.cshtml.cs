using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VolleyballCompetitionApp.Business;
using VolleyballCompetitionApp.Repository;

namespace VolleyballCompetitionApp.Presentation.Pages.Players
{
	public class CreateModel : PageModel
	{
		private string _connectionString;

		public CreateModel(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("Did you forget the connectionstring?");
		}

		public IActionResult OnPost(int teamId, string playerName) 
		{
			return RedirectToPage("Index");
		}
		public IActionResult OnCancel()
		{
			return RedirectToPage("Index");
		}
	}
}
