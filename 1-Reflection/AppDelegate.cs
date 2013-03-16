using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace Reflection
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;


		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);


			//create our model
			var account = new AccountInfoModel ();

			//we could also do this
			//account.Login = "nicw@fastchicken.co.nz";
			//account.Password = "Evolve2013";

			//create a context. passing (in order)
			// account: this is where OnTap callbacks go to. This could be any other class, it doesn't have to be the same one
			// account: this is the model we are going to be populating
			// "...": the title of the list
			var context = new BindingContext (account, account, "Account");

			//make a dialog view controller (UITableView descendant)
			var dvc = new DialogViewController (context.Root, false);
		 	
			//setup a button, so we can have a save function
			dvc.NavigationItem.RightBarButtonItem = new UIBarButtonItem (UIBarButtonSystemItem.Save, (o,e) => {
				context.Fetch();

				var alert = new UIAlertView ("Thanks!", string.Format ("Thanks {0}. Your secret handshake is {1}.\nHave a nice flight in the {2}",
				                                                       account.Login, account.Password, account.Preference.ToString ()),
				                             null, "Ok");
				
				alert.Show ();

			});

			//wrap it all up in a UINavigationController
			window.RootViewController = new UINavigationController (dvc);
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

