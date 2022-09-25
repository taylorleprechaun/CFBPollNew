using System.Collections.Generic;

namespace CFBPoll.Models
{
    class Season
    {
        public List<Team> Teams { get; set; }
        public int Year { get; set; }

        public Season()
        {
        }

        public Season(List<Team> teams, int year)
        {
            Teams = teams;
            Year = year;
        }
    }
}
