using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VolleyballCompetitionApp.Business;
using VolleyballCompetitionApp.Pages;
using VolleyballCompetitionApp.Repository;

namespace VolleyballCompetitionApp.Presentation.Pages.Club
{
    public class IndexModel : PageModel
    {
        private readonly string _connectionString;

		public IndexModel(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("Did you forget the connection string");
		}

		public List<Business.Models.ClubModel> GetAll ()
        {
            ClubCollection clubCollection = new ClubCollection(new ClubRepository(_connectionString), new TeamRepository(_connectionString), new PlayerRepository(_connectionString));
            return clubCollection.GetAllClubs();
        }

        public void OnGet()
        {

        }
    }
}
