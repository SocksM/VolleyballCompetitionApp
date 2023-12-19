using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VolleyballCompetitionApp.Business.Models;
using VolleyballCompetitionApp.Business;
using VolleyballCompetitionApp.Repository;

namespace VolleyballCompetitionApp.Presentation.Pages.Players
{
	public class EditModel : PageModel
	{
        private string _connectionString;
        public PlayerModel players { get; set; }

        public EditModel(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("Did you forget the connectionstring?");
        }

        public void OnGet(int id)
		{
			players = new PlayerCollection(new PlayerRepository(_connectionString)).FindPlayerById(id);
		}

		[BindProperty]
		public string newPlayerName { get; set; }
		public int newPlayerTeamId { get; set; }
		public IActionResult OnPost(int id)
		{

			return RedirectToPage("Index");
		}

		public IActionResult OnCancel()
		{
			return RedirectToPage("Index");
		}
	}
}
