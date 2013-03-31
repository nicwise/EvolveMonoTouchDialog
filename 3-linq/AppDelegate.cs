using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace linq
{

	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		ListApiViewController viewController;


		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			viewController = new ListApiViewController ();

			var navController = new UINavigationController (viewController);

			window.RootViewController = navController;
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

