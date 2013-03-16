using System;
using MonoTouch.Dialog;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;

namespace linq
{
	public class LinqApiViewController : DialogViewController
	{
		List<string> data = new List<string>();

		public LinqApiViewController () : base(null, false)
		{

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


			bankSelection = new RadioGroup (0);
			Root = new RootElement ("Pick your bank", bankSelection) {
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
	}
}

