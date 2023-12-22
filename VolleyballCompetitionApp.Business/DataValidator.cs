using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolleyballCompetitionApp.Business
{
	static class DataValidator
	{
		public static bool IsNameValid(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				return false;
			}
			return name.Length > 0 && name.Length <= 255;
		}

		public static void ThrowInvalidNameException(string name)
		{
			if (name == null)
			{
				name = string.Empty;
			}
			throw new ArgumentException($"Name must be between 0 and 256 characters long. Name Currently is currently {name.Length} characters long.");
		}
	}
}
