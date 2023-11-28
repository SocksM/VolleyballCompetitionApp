using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolleyballCompetitionApp.Business.DTOs
{
	public class MatchDTO
	{
		public int Id { get; set; }
		public int Team1Id { get; set; }
		public int Team2Id { get; set; }
		public int CompetitionId {  get; set; }
		public string Location { get; set; }
	}
}
