using System;
using MonoTouch.Dialog;
using MonoTouch.UIKit;

namespace Reflection
{
	public class AccountInfoModel
	{
		[Section]
		public bool AirplaneMode;

		[Section("Data Entry", "Your Credentials")]
		[Entry("Enter your email")]
		public string Login;

		[Caption("Password")]
		[Password("Enter your password")]
		public string Password;

		[Section("Travel Options")]
		public SeatPreference Preference;

		[Section]
		[OnTap("Tapped")]
		public string PressMe;


		public void Tapped()
		{
			var alert = new UIAlertView ("Tapped", "Yes, you tapped it",
			                            null, "Ok");
			alert.Show ();
		}
	}

	public enum SeatPreference
	{
		Aisle,
		Window,
		Centre
	}
}

