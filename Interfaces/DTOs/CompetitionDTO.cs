using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolleyballCompetitionApp.Interfaces.DTOs
{
	public class CompetitionDTO
	{
		public int Id {  get; set; }
		public DateOnly Start { get; set; }
		public DateOnly End { get; set; }
		public string Name { get; set; }
	}
}
