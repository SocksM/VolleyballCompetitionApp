using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VolleyballCompetitionApp.Business;
using VolleyballCompetitionApp.Business.Models;
using static System.Reflection.Metadata.BlobBuilder;
using VolleyballCompetitionApp.Repository;

namespace VolleyballCompetitionApp.Presentation.Pages.Players
{
    public class DeleteModel : PageModel
    {
		private string _connectionString;
		public PlayerModel player { get; set; }

		public DeleteModel(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("Did you forget the connectionstring?");
		}

		public void OnGet(int id)
		{
			player = new PlayerCollection(new PlayerRepository(_connectionString)).FindPlayerById(id);
		}

		public IActionResult OnPostDelete(int id)
		{
			new PlayerCollection(new PlayerRepository(_connectionString)).DeletePlayerById(id);
			return RedirectToPage("/Players/List");
		}

		public IActionResult OnPostCancel()
		{
			return RedirectToPage("/Players/List");
		}
	}
}
