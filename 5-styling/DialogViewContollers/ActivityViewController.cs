using System;
using MonoTouch.Dialog;
using styling.Data;
using MonoTouch.UIKit;
using styling.Elements;
using MonoTouch.Foundation;
using System.Drawing;

namespace styling
{
	public class ActivityViewController : DialogViewController
	{
		public ActivityViewController () : base(null, false)
		{
			Style = MonoTouch.UIKit.UITableViewStyle.Plain;

			this.TableView.Source = new SpecialSource (this);
		}
		
		public override void LoadView ()
		{
			base.LoadView ();
			
			var root = new RootElement ("Activity");
			
			var section = new Section ();

			foreach (var ap in DataSource.Current.Activity)
			{
				section.Add (new ActivityItemElement (ap.Activity, ap.Project));
			}

			root.Add (section);

			Root = root;
			
			TableView.BackgroundColor = Colors.TableBackgroundGrey;
			TableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
			NavigationItem.TitleView = new UIImageView (Resources.KickstarterLogo);
			
		}

		public override Source CreateSizingSource (bool unevenRows)
		{
			return new SpecialSource (this);
		}

		public void UpdateCellAtPath (NSIndexPath indexPath, PointF topOfTableView)
		{

			var cell = TableView.CellAt (indexPath);
			var topOfCell = TableView.RectForRowAtIndexPath (indexPath);

			if (cell is ActivityItemElement.ActivityElementCell)
			{
				var topOffset = topOfTableView.Y;
				if (topOffset < 0) topOffset = 0;
				(cell as ActivityItemElement.ActivityElementCell).UpdateSideImage (topOffset - topOfCell.Y);
			}

			cell = TableView.CellAt (NSIndexPath.FromItemSection (indexPath.Item + 1, indexPath.Section));
			if (cell != null)
			{
				if (cell is ActivityItemElement.ActivityElementCell)
				{
					(cell as ActivityItemElement.ActivityElementCell).UpdateSideImage (0);
				}
			}
		}


		public class SpecialSource : SizingSource
		{
			public SpecialSource (ActivityViewController container) : base(container)
			{
				this.Container = container;
				Root = container.Root;
			}

			public override void Scrolled (UIScrollView scrollView)
			{

				var point = Container.TableView.ContentOffset;
				var indexPath = Container.TableView.IndexPathForRowAtPoint (point);



				if (indexPath != null)
				{
					(Container as ActivityViewController).UpdateCellAtPath (indexPath, point);
				} else {
					//we are in the overscroll / bounce area, so we don't have a "cell at the point"
					//so pick the first one!
					(Container as ActivityViewController).UpdateCellAtPath (NSIndexPath.FromItemSection(0,0), point);
				}

			}

		}


	}
}

