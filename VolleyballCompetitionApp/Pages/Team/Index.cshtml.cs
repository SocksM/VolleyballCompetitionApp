using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VolleyballCompetitionApp.Presentation.Pages.Team
{
    public class IndexModel : PageModel
    {
        public int id { get; private set; }
        public string name { get; private set; }
        private readonly string _connectionString;

        public IndexModel(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("Did you forget the connection string");
        }
        public void OnGet(int clubId, string name)
        {
            id = clubId;
        }
    }
}
