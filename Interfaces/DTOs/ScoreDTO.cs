﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolleyballCompetitionApp.Interfaces.DTOs
{
	public class ScoreDTO
	{
		public int Id { get; set; }
		public int TeamId { get; set; }
		public int MatchId { get; set; }
		public int Round {  get; set; }
		public int Score { get; set; }
	}
}
