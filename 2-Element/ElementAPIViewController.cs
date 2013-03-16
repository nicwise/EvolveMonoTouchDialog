using System;
using MonoTouch.Dialog;
using MonoTouch.UIKit;

namespace Element
{
	public class ElementAPIViewController : DialogViewController
	{
		public ElementAPIViewController () : base(null, false)
		{
		}

		public override void LoadView ()
		{
			base.LoadView ();

			//we need this to store the valid of the Preference item in
			RadioGroup preferenceGroup = new RadioGroup (0);

			//build the root
			var root = new RootElement ("Account")
			{
				//add a section for the top switch
				new Section
				{
					new BooleanElement("Airplane Mode", false)
				},
				new Section("Data Entry", "Your Credentials")
				{
					new EntryElement("Login", "Enter your email", ""),
					new EntryElement("Password", "Enter your password", "", true)
				},
				new Section("Travel Options")
				{
					new RootElement("Preference", preferenceGroup)
					{
						new Section()
						{
							new RadioElement("Aisle"),
							new RadioElement("Window"),
							new RadioElement("Centre")
						}
					}
				},
				new Section()
				{
					new StringElement("Press Me", () => {
						var alert = new UIAlertView ("Tapped", "Yes, you tapped it",
						                             null, "Ok");
						alert.Show ();
					})
				}

			};

			Root = root;

		}


	}
}

