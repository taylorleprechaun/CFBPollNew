using Microsoft.Extensions.Configuration;

namespace CFBPoll.Utilities
{
    public class NameCorrector
    {
        private readonly StringComparison _scoic = StringComparison.OrdinalIgnoreCase;

        public NameCorrector() { }

        /// <summary>
		/// Corrects names coming from the team list text file and stat files so they are all the same and the data can be properly matched up
		/// </summary>
		/// <param name="nameToFix">The name that needs correcting</param>
        public string FixName(string nameToFix)
        {
            if (nameToFix.Contains("("))
            {
                nameToFix = nameToFix.Replace("(", "");
                nameToFix = nameToFix.Replace(")", "");
            }
            if (nameToFix.Contains("Antonio"))
                nameToFix = "UTSA";
            if (nameToFix.Contains("Bowling Green State"))
                nameToFix = "Bowling Green";
            if (nameToFix.Contains("El Paso"))
                nameToFix = "UTEP";
            if (nameToFix.Contains("Florida International"))
                nameToFix = "Florida Int'l";
            if (nameToFix.Contains("Las Vegas"))
                nameToFix = "UNLV";
            if (nameToFix.Equals("Louisiana", _scoic))
                nameToFix = "Louisiana-Lafayette";
            if (nameToFix.Equals("LSU", _scoic))
                nameToFix = "Louisiana State";
            if (nameToFix.Contains("Middle Tennessee"))
                nameToFix = "MTSU";
            if (nameToFix.Contains("Ole Miss"))
                nameToFix = "Mississippi";
            if (nameToFix.Contains("Ohio") && !nameToFix.Equals("Ohio State"))
                nameToFix = "Ohio U.";
            if (nameToFix.Contains("Pitt"))
                nameToFix = "Pittsburgh";
            if (nameToFix.Equals("Sam Houston", _scoic))
                nameToFix = "Sam Houston State";
            if (nameToFix.Contains("Southern California"))
                nameToFix = "USC";
            if (nameToFix.Equals("Southern Methodist", _scoic))
                nameToFix = "SMU";
            if (nameToFix.Equals("Southern Mississippi", _scoic))
                nameToFix = "Southern Miss";
            if (nameToFix.Equals("TCU", _scoic))
                nameToFix = "Texas Christian";
            if (nameToFix.Contains("UAB"))
                nameToFix = "Alabama-Birmingham";
            if (nameToFix.Contains("UCF"))
                nameToFix = "Central Florida";

            return nameToFix;
        }

        /// <summary>
		/// Corrects names from our system to match what is expected by the CFBData API
		/// </summary>
		/// <param name="nameToFix">The name that needs correcting</param>
        public string FixNameForCFBDataAPI(string nameToFix)
        {
            if (nameToFix.Equals("Alabama-Birmingham", _scoic))
                nameToFix = "UAB";
            if (nameToFix.Equals("Brigham Young", _scoic))
                nameToFix = "BYU";
            if (nameToFix.Equals("Louisiana-Lafayette", _scoic))
                nameToFix = "Louisiana";
            if (nameToFix.Equals("Central Florida", _scoic))
                nameToFix = "UCF";
            if (nameToFix.Equals("Florida Int'l", _scoic))
                nameToFix = "Florida International";
            if (nameToFix.Equals("Hawaii", _scoic))
                nameToFix = "Hawai'i";
            if (nameToFix.Equals("Louisiana-Monroe", _scoic))
                nameToFix = "Louisiana Monroe"; 
            if (nameToFix.Equals("Louisiana State", _scoic))
                nameToFix = "LSU";
            if (nameToFix.Equals("Massachusetts", _scoic))
                nameToFix = "UMass"; 
            if (nameToFix.Equals("Miami FL", _scoic))
                nameToFix = "Miami";
            if (nameToFix.Equals("Miami OH", _scoic))
                nameToFix = "Miami (OH)";
            if (nameToFix.Equals("MTSU", _scoic))
                nameToFix = "Middle Tennessee"; 
            if (nameToFix.Equals("Mississippi", _scoic))
                nameToFix = "Ole Miss"; 
            if (nameToFix.Equals("North Carolina State", _scoic))
                nameToFix = "NC State"; 
            if (nameToFix.Equals("Ohio U.", _scoic))
                nameToFix = "Ohio"; 
            if (nameToFix.Equals("San Jose State", _scoic))
                nameToFix = "San José State";
            if (nameToFix.Equals("Southern Miss", _scoic))
                nameToFix = "Southern Mississippi";
            if (nameToFix.Equals("Texas Christian", _scoic))
                nameToFix = "TCU";
            if (nameToFix.Equals("UTSA", _scoic))
                nameToFix = "UT San Antonio";

            return nameToFix;
        }

        /// <summary>
		/// Corrects names coming from the score file (name starts with rank)
		/// </summary>
		/// <param name="nameToFix">The name that needs correcting</param>
		public string RemoveRank(string nameToFix)
        {
            //If the name starts with a (
            int startIndex = 0;
            if (nameToFix.StartsWith("("))
            {
                //Iterate over the string
                foreach (char c in nameToFix)
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

            return nameToFix[startIndex..];
        }
    }
}
