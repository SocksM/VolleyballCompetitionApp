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

        private ClubCollection clubCollection;
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

        public IActionResult OnPost(int id, string deletetionConfirmed)
        {
            clubCollection.DeleteClubById(id);   
            return RedirectToPage("Index");
        }

		public IActionResult OnCancel()
		{
			return RedirectToPage("Index");
		}
	}
}
