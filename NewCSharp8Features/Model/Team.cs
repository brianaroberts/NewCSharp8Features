using System.Collections.Generic;

namespace NewCSharp8Features
{
	public class Team
	{
		private string _teamName = "Not Provided";
		public string TeamName { get => _teamName; set => _teamName = value; }
		public int YearCreated { get; set; }
		public int NumberOfSuperbowls { get; set; }
		public List<TeamMate> TeamMates { get; set; } = new List<TeamMate>(); 
	}

	public class TeamMate
	{
		private string _name = "Not Provided";
		public string Name { get => _name; set => _name = value;  }
		public int JerseyNumber { get; set; }
	}
}
