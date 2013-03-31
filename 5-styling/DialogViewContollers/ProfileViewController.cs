using System;
using MonoTouch.Dialog;
using MonoTouch.UIKit;
using styling.Elements;

namespace styling.DialogViewControllers
{
	public class ProfileViewController : DialogViewController
	{
		public ProfileViewController () : base(null, false)
		{

		}

		public override void LoadView ()
		{
			base.LoadView ();

			var root = new RootElement ("Profile");

			root.Add (new Section() {
				new UIViewElement(null, new ProfileImageView(), true)
			});

			root.Add (new BackgroundImageSection () {
				new StyledStringElement("Projects", delegate {}) { BackgroundColor = UIColor.Clear }
			});

			root.Add (new BackgroundImageSection () {
				new StyledStringElement("Comments", delegate {}) { BackgroundColor = UIColor.Clear },
	            new StyledStringElement("Support", delegate {}) { BackgroundColor = UIColor.Clear },
	            new StyledStringElement("Lists", delegate {}) { BackgroundColor = UIColor.Clear }
			});

			root.Add (new Section () {
				new StyledStringElement("Projects", delegate {})
			});

			root.Add (new Section () {
				new StyledStringElement("Comments", delegate {}),
				new StyledStringElement("Support", delegate {}),
				new StyledStringElement("Lists", delegate {})
			});

			Root = root;

			NavigationItem.TitleView = new UIImageView (Resources.KickstarterLogo);
		}
	}
}

