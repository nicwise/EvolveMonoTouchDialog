using System;
using System.Collections.Generic;

namespace styling.Data
{
	public class Project
	{
		public Project()
		{
			Activity = new List<Activity>();
		}


		public string Id { get; set; }

		public string Title { get; set; }

		public string OwnerName { get; set; }

		public string ShortDescription { get; set; }

		public string FullDescription { get; set; }

		public double Goal { get; set; }

		public double PledgeAmount { get; set; }

		public int Backers { get; set; }

		public int DaysToGo { get; set; }

		public string Location { get; set; }

		public string Category { get; set; }

		public int Comments { get; set; }

		public int Updates { get; set; }

		public string MainImage { get; set; }

		public List<Activity> Activity { get; set; }

		public float PercentProgress 
		{
			get
			{
				var res = (float)PledgeAmount / (float)Goal;
				if (res < 1) return res;
				return 1;
			}
		}

	}

	public class Activity 
	{
		public string Title { get; set; }
		public int UpdateNumber { get; set; }
		public DateTime Date { get; set; }
		public string Text { get; set; }

	}
}

