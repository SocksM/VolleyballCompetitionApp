﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolleyballCompetitionApp.Interfaces.DTOs;

namespace VolleyballCompetitionApp.Repository
{
	public class ScoreRepository
	{
		public int Create() // returns an int because the integer will be auto generated by the database so when you create the row you will be able to know what the id is
		{// the dto parameter shouldnt have a id yet (aka default int value) because the database will decide what the value will be
			// database connection and data uploading 

			// no error's? return auto generated id (int)
			return 1;
		}
		// possible issue which could arise and need to be take care of 

		#region Read Methods

		public ScoreDTO ReadById(int id) // gets data from the database depending on the id
		{
			// data base connection and data fetching

			// database connection and data fetching

			// no error's? return filled dto.
			return new ScoreDTO { };
		}


		#endregion

		public void Update() // uses dto.id to dicate to what row it alters then alters that row
		{
			// dto validation (does it have all variable's filled etc?)

			// database connection and data uploading/dating
		}

		public void Delete(int id) 
		{
			// database connection and data deletion
		}
	}
}
