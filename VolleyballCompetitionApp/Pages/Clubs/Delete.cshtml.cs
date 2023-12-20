using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VolleyballCompetitionApp.Business;
using VolleyballCompetitionApp.Business.Models;
using static System.Reflection.Metadata.BlobBuilder;
using VolleyballCompetitionApp.Repository;
using Microsoft.AspNetCore.Razor.Language;

namespace VolleyballCompetitionApp.Presentation.Pages.Clubs
{
	public class DeleteModel : PageModel
	{

        public ClubCollection clubCollection { get; private set; }
        public ClubModel club { get; set; }

		public DeleteModel(IConfiguration configuration)
		{
            string connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("Did you forget the connectionstring?");
            clubCollection = new ClubCollection(new ClubRepository(connectionString), new TeamRepository(connectionString), new PlayerRepository(connectionString));
        }

		public void OnGet(int id)
		{
			club = clubCollection.FindClubById(id);
		}

		public IActionResult OnPost(int id)
		{
			clubCollection.DeleteClubById(id);
			return RedirectToPage("/Clubs/List");
		}

		public IActionResult OnPostCancel()
		{
			return RedirectToPage("/Clubs/List");
		}
	}
}
