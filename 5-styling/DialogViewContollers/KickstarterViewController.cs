using System;
using MonoTouch.Dialog;
using styling.Data;
using styling.Elements;
using MonoTouch.UIKit;

namespace styling.DialogViewControllers
{
	public class KickstarterViewController : DialogViewController
	{
		public KickstarterViewController () : base(null, false)
		{
			Style = MonoTouch.UIKit.UITableViewStyle.Plain;
		}

		public override void LoadView ()
		{
			base.LoadView ();

			var root = new RootElement("KickStarter");

			var section = new Section();

			foreach(var project in DataSource.Current.Projects)
			{
				section.Add(new ProjectElement(project));
			}

			root.Add(section);

			Root = root;

			TableView.BackgroundColor = Colors.ProjectBackgroundGrey;
			TableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
			NavigationItem.TitleView = new UIImageView(Resources.KickstarterLogo);

		}
	}
}

