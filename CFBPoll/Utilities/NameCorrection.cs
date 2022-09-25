using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFBPoll.Utilities
{
	class NameCorrection
	{
		/// <summary>
		/// Corrects names coming from the team list text file and stat files so they are all the same and the data can be properly matched up
		/// </summary>
		/// <param name="name">The name that needs correcting</param>
		public static string NameCorrector(string name)
		{
			if (name.Contains("("))
			{
				name = name.Replace("(", "");
				name = name.Replace(")", "");
			}
			if (name.Contains("Ole Miss"))
			{
				name = "Mississippi";
			}
			if (name.Contains("UCF"))
			{
				name = "Central Florida";
			}
			if (name.Contains("Southern California"))
			{
				name = "USC";
			}
			if (name.Contains("UAB"))
			{
				name = "Alabama-Birmingham";
			}
			if (name.Equals("Southern Mississippi"))
			{
				name = "Southern Miss";
			}
			if (name.Contains("Florida International"))
			{
				name = "Florida Int'l";
			}
			if (name.Contains("Pitt"))
			{
				name = "Pittsburgh";
			}
			if (name.Contains("Ohio") && !name.Equals("Ohio State"))
			{
				name = "Ohio U.";
			}
			if (name.Equals("Louisiana"))
			{
				name = "Louisiana-Lafayette";
			}
			if (name.Contains("Bowling Green State"))
			{
				name = "Bowling Green";
			}
			if (name.Equals("LSU"))
			{
				name = "Louisiana State";
			}
			if (name.Equals("Southern Methodist"))
			{
				name = "SMU";
			}
			if (name.Contains("Pitt"))
			{
				name = "Pittsburgh";
			}
			if (name.Contains("El Paso"))
			{
				name = "UTEP";
			}
			if (name.Contains("Las Vegas"))
			{
				name = "UNLV";
			}
			if (name.Contains("Middle Tennessee"))
			{
				name = "MTSU";
			}
			if (name.Contains("Antonio"))
			{
				name = "UTSA";
			}

			return name;
		}

		/// <summary>
		/// Corrects names coming from the score file (name starts with rank)
		/// </summary>
		/// <param name="name">The name that needs correcting</param>
		public static string NameCorrectorScores(string name)
		{
			//If the name starts with a (
			int startIndex = 0;
			if (name.StartsWith("("))
			{
				//Iterate over the string
				foreach (char c in name)
                {
					//If the char is whitespace then advance the start index and exit the loop
					if (char.IsWhiteSpace(c))
                    {
						startIndex++;
						break;
                    }
					startIndex++;
				}
			}

			return name.Substring(startIndex);

		}
	}
}
