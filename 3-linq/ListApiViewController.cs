using System;
using MonoTouch.Dialog;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;

namespace linq
{
	public class ListApiViewController : DialogViewController
	{
		List<string> data = new List<string>();

		public ListApiViewController () : base(null, false)
		{
			//plain makes a bit more sense for a list of data
			Style = UITableViewStyle.Plain;

			//out banks need to be sorted, so the button below can work. We just get the index into the LIST, 
			// not into the List<string>. But we can make them the same!
			data = new List<string>
			{
				"Bank of America",
				"First National Bank",
				"Simple",
				"Bank Direct",
				"Barclays Bank",
				"Second Bank of Madison",
				"Monkey Bank"
			}.OrderBy (x => x).ToList();

			NavigationItem.RightBarButtonItem = new UIBarButtonItem (UIBarButtonSystemItem.Save, (o,e) => {

				string bankName = data[bankSelection.Selected];

				var alert = new UIAlertView ("Tapped", string.Format ("You picked {0}", bankName),
				                             null, "Ok");
				alert.Show ();
			});
		}

		RadioGroup bankSelection;

		public override void LoadView ()
		{
			base.LoadView ();

			Root = BuildRootWithLinq();

			//Root = BuildRootWithLoop();



		}

		public RootElement BuildRootWithLinq()
		{
			bankSelection = new RadioGroup (0);
			return new RootElement ("Pick your bank", bankSelection) {
				from name in data
				group name by name.Substring (0,1) into g
				orderby g.Key
				select new Section(g.Key)
				{
					from groupItem in g
						select (Element) new RadioElement(groupItem)
				}
			};
		}

		public RootElement BuildRootWithLoop()
		{
			bankSelection = new RadioGroup (0);

			Section section = null;
			string lastLetter = "";
			RootElement root = new RootElement("Pick your bank", bankSelection);

			foreach(var name in data)
			{
				string currentFirstLetter = name.Substring(0,1);
				if (currentFirstLetter != lastLetter)
				{
					if (section != null && section.Count > 0) root.Add (section);

					lastLetter = currentFirstLetter;
					section = new Section(currentFirstLetter);
				}

				section.Add (new RadioElement(name));

			}

			if (section != null && section.Count > 0) root.Add (section);

			return root;

		}
	}
}

