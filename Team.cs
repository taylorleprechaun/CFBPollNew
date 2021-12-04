namespace CFBPollNew
{
	class Team
	{
		public string Name { get; set; }
		public string Conference { get; set; }
		public string Division { get; set; }
		public TeamSchedule PastSchedule { get; set; }
		public TeamSchedule FutureSchedule { get; set; }
		public Stats OffenseStats { get; set; }
		public Stats DefenseStats { get; set; }
		public double Rating { get; set; }

		public Team()
		{
		}

		public Team(string name)
		{
			//Create filler FCS opponent
			if (name.StartsWith("FCS"))
            {
				Name = name;
				Conference = "FCS";
				Division = "FCS";
				OffenseStats = new Stats("blank");
				DefenseStats = new Stats("blank");
				PastSchedule = new TeamSchedule();
				FutureSchedule = new TeamSchedule();
			}
		}

		public Team(string name, string conference, string division)
        {
			Name = name;
			Conference = conference;
			Division = division;
			PastSchedule = new TeamSchedule();
			FutureSchedule = new TeamSchedule();
		}
	}
}
