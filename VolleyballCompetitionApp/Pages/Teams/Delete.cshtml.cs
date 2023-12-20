using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VolleyballCompetitionApp.Business;
using VolleyballCompetitionApp.Business.Models;
using static System.Reflection.Metadata.BlobBuilder;
using VolleyballCompetitionApp.Repository;
using Microsoft.AspNetCore.Razor.Language;

namespace VolleyballCompetitionApp.Presentation.Pages.Teams
{
    public class DeleteModel : PageModel
    {
        public TeamCollection teamCollection { get; private set; }
        public TeamModel team { get; set; }

        public DeleteModel(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("Did you forget the connectionstring?");
            teamCollection = new TeamCollection(new TeamRepository(connectionString), new PlayerRepository(connectionString));
        }

        public void OnGet(int id)
        {
            team = teamCollection.FindTeamById(id);
        }

        public IActionResult OnPostDelete(int id)
        {
            teamCollection.DeleteTeamById(id);
            return RedirectToPage("/Teams/List");
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("/Teams/List");
        }
    }
}
