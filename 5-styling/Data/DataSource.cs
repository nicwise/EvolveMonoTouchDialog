using System;
using System.Collections.Generic;
using System.Linq;

namespace styling.Data
{
	public class DataSource
	{
		static DataSource _instance = new DataSource();
		public static DataSource Current { get { return _instance; } }

		List<Project> projects = new List<Project>();


		public IEnumerable<Project> Projects
		{
			get
			{
				foreach(var project in projects)
				{
					yield return project;
				}
			}
		}

		public IEnumerable<ActivityAndProject> Activity
		{
			get
			{
				return (from project in projects
				        from activity in project.Activity
				        orderby activity.Date
				        select new ActivityAndProject { Activity = activity, Project = project} );
			}
		}


		private DataSource()
		{
			//make some data!

			projects.Add (new Project {
				Id = Guid.NewGuid().ToString("D"),
				Title = "The DUB Pies Food Truck",
				OwnerName = "Gareth Hughes",
				ShortDescription = "Bringing authentic, heavenly, savory DUB Pies and delicious coffee to you aboard New York’s very first Pie Truck!",
				FullDescription = @"For nine years, New York pie-oneer Down Under Bakery Pies - or DUB Pies as fans know and love them - have made delicious, savory New Zealand-style pies for New York’s pubs and cafes.  

Along with life-changing Flat White-style coffee, the pies have been served for the past five years from our café in Windsor Terrace, Brooklyn.

In New Zealand, you can get a pie anywhere, anytime. This isn’t the case in New York, so we’ve decided it’s time to take our pastry pockets of goodness mobile with The DUB Pies Food Truck. People need pies!

Few foods are better suited to food trucks than our meat (or vege) pies. The portable pie is the perfect street and event food, and once upon a time, the humble kiwi “pie cart” was ubiquitous. We believe pies are just as suited to the streets and events of New York City, and deserve to be equally ubiquitous. 

We have the truck. We have the permit. But that’s taken up a lot of our capital, so we are turning to our community of pie-loving friends via Kickstarter to invest in the future of pie.",
				Goal = 29500,
				PledgeAmount = 3610,
				Backers = 364,
				DaysToGo = 2,
				Location = "Brooklyn, NY",
				Category = "Food",
				Comments = 4,
				Updates = 5,
				MainImage = "images/covers/dubpies.jpg",
				Activity = new List<Activity> {
					new Activity {
						Title = @"Our b-roll (video out-takes) special: Pledgers only!",
						UpdateNumber = 1,
						Date = DateTime.Now.AddDays (-2),
						Text = @"As promised, here's a little video ""thank you"" to everyone who has pledged (or will pledge.) 

We're not making this available to the public - just you! ;-)

As you can see, we started making it when we'd hit a very calm patch in the fund raising - but since then we've smashed our goal - now we're looking to make the ""DUB Pies Food Truck Jr."" a reality! Please keep spreading the word!"
					}
				}
			});


			projects.Add (new Project {
				Id = Guid.NewGuid().ToString("D"),
				Title = "SCIENCE: Ruining Everything Since 1543 (an SMBC Collection)",
				OwnerName = "Zachary Weiner",
				ShortDescription = @"""SCIENCE: Ruining Everything Since 1543"" is a collection of new & old SMBC comics all about science and scientists.",
				FullDescription = @"SMBC (short for ""Saturday Morning Breakfast Cereal"") is a daily-updated comic strip about all sorts of topics. Its author, Zach Weinersmith, is a giant dork who also has many other geeky projects such as producing SMBC Theater, writing for Snowflakes, his science blog the Weinerworks, and his science-themed podcast The Weekly Weinersmith (which he co-hosts with his wife, the parasitologist Kelly Weinersmith).

So it will come as no huge surprise that this, the third SMBC printed collection, is a compendium of his finest science-related strips. Like these!",
				Goal = 20000,
				PledgeAmount = 3416,
				Backers = 8016,
				DaysToGo = 8,
				Location = "Brooklyn, NY",
				Category = "Comics",
				Comments = 50,
				Updates = 5,
				MainImage = "images/covers/sbmc.jpg",
				Activity = new List<Activity> {
					new Activity {
						Title = @"For people who want to add to their order",
						UpdateNumber = 40,
						Date = DateTime.Now.AddDays (-1),
						Text = @"Hey geeks!

I just saw a proto for the book, and I think you'll all be quite please.

For people who want to add something to their order, we are streamlining the process! Go here: http://breadpig.com/collections/science-ruining-everything-since-1543"
					}
				}
			});

			projects.Add (new Project {
				Id = Guid.NewGuid().ToString("D"),
				Title = "The 10-year hoodie",
				OwnerName = "Jake Bronstein",
				ShortDescription = "EVERY STITCH TELLS A STORY: A Premium Sweatshirt Designed for a Lifetime, Guaranteed for a Decade and Backed with FREE Mending!",
				FullDescription = @"The 10-Year Hoodie Is...

1 - A Super Premium, unisex sweatshirt made with only the finest of materials. It'll grow into you the way your favorite sweatshirt should — getting softer with wear, keeping you warm and snuggly, and stacking up stories along the way.

2 - Built for life, guaranteed to last at least a decade and backed with FREE mending! Every stitch tells a story — put it through its paces and it'll actually get better, more interesting, and more unique over a lifetime of wear. 

3 - A battle cry: Not everything should be disposable. Companies have systematically lowered your expectations to the point where it's hard to know what to expect anymore. But it ends here.

4 - 100% Made in America. The tags, the labels, even the fabric (all the way down the yarn and the cotton it's made from) are domestically produced.

5 - Sold direct. Premium sweatshirts cost anywhere from $130 - $190+ in department stores. Cheap ones are only a few bucks less. And that's without the guarantee, domestic production or free mending, of course. We're cutting out the middleman to keep the price to just half of what it should be. ",
				Goal = 50000,
				PledgeAmount = 65235,
				Backers = 5860,
				DaysToGo = 29,
				Location = "Lower East Side, NY",
				Category = "Fashion",
				Comments = 149,
				Updates = 1,
				MainImage = "images/covers/10yearhoodie.jpg",
				Activity = new List<Activity> {
					new Activity {
						Title = @"GOAL MET – NOW LET'S TALK MISSION",
						Text = @"Be advised, there’s a lot of words and even a video in this update. Don’t have time for all of that? Let us give it to you in just two words: THANK YOU! 

We wanted to take this time to first share some facts, answer a few questions and finally, share a thought or two about next steps (that’s the video).",
						UpdateNumber = 1,
						Date = DateTime.Now.AddDays (-2)
					}
				}
			});

//			projects.Add (new Project {
//				Id = Guid.NewGuid().ToString("D"),
//				Title = "",
//				OwnerName = "",
//				ShortDescription = "",
//				FullDescription = @"",
//				Goal = 50000,
//				PledgeAmount = 652335,
//				Backers = 5860,
//				DaysToGo = 29,
//				Location = "",
//				Category = "",
//				Comments = 149,
//				Updates = 1,
//				MainImage = "",
//				Activity = new List<Activity> {
//					new Activity {
//						Title = @"",
//						UpdateNumber = 1,
//						Date = DateTime.Now.AddDays (-2)
//					}
//				}
//			});


		}

	}
}

