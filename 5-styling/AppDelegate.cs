using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using FlyoutNavigation;
using MonoTouch.Dialog;
using styling.Elements;
using styling.DialogViewControllers;

namespace styling
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;

		FlyoutNavigationController navigation;

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

			SetAppearance();

			FlyoutNavigationController.MenuWidth = 80;
			navigation = new FlyoutNavigationController {
				// Create the navigation menu
				NavigationRoot = new RootElement ("Navigation") {
					new Section ("") {
						new IconElement (Resources.KickstarterIcon, "Kickstarter"),
						new IconElement (Resources.ActivityIcon, "Activity"),
						new IconElement (Resources.ProfileIcon, "Profile"),
					}
				},
				// Supply view controllers corresponding to menu items:
				ViewControllers = new [] {
					new UINavigationController(new KickstarterViewController()),
					new UINavigationController(new ActivityViewController()),
					new UINavigationController(new ProfileViewController()),
				},
			};

			navigation.NavigationRoot.TableView.SeparatorStyle = UITableViewCellSeparatorStyle.DoubleLineEtched;
			navigation.NavigationRoot.TableView.BackgroundColor = UIColor.Black;
			// Show the navigation view
			//navigation.ToggleMenu ();
			navigation.SelectedIndex = 2;



			
			window.RootViewController = navigation;
			window.MakeKeyAndVisible ();
			
			return true;
		}

		public void SetAppearance()
		{
			UINavigationBar.Appearance.SetBackgroundImage(Resources.NavBarBackground, UIBarMetrics.Default);
		
			window.BackgroundColor = UIColor.Black;
			UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.BlackOpaque;
			
			UIProgressView.Appearance.ProgressImage = Resources.ProgressImageGreen;
			UIProgressView.Appearance.TrackImage = Resources.ProgressImageGrey;

		
		}
	}
}

