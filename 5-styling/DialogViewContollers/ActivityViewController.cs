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

			this.TableView.Source = new SpecialSource(this);
		}
		
		public override void LoadView ()
		{
			base.LoadView ();
			
			var root = new RootElement("Activity");
			

			foreach(var ap in DataSource.Current.Activity)
			{

				root.Add(new ProjectSection(ap.Project) {
					new ActivityItemElement(ap.Activity, ap.Project)
				});

				root.Add(new ProjectSection(ap.Project) {
					new ActivityItemElement(ap.Activity, ap.Project)
				});

				root.Add(new ProjectSection(ap.Project) {
					new ActivityItemElement(ap.Activity, ap.Project)
				});

				//section.Add(new ActivityElement(activity));
			}

			Root = root;
			
			TableView.BackgroundColor = Colors.TableBackgroundGrey;
			//TableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
			NavigationItem.TitleView = new UIImageView(Resources.KickstarterLogo);
			
		}

		public override Source CreateSizingSource (bool unevenRows)
		{
			return new SpecialSource(this);
		}

		public void UpdateCellAtPath(NSIndexPath indexPath, PointF topOfTableView)
		{
			var section = Root.Sections [indexPath.Section];
			var element = section.Elements [indexPath.Row];

			var cell = TableView.CellAt(indexPath);
			var topOfCell = TableView.RectForRowAtIndexPath(indexPath);
			if (cell is ActivityItemElement.ActivityElementCell)
			{
				(cell as ActivityItemElement.ActivityElementCell).UpdateSideImage(topOfTableView.Y - topOfCell.Y);
			}


			foreach(var path in TableView.IndexPathsForVisibleRows)
			{
				if (path.Row != indexPath.Row && path.Section != indexPath.Section)
				{
					cell = TableView.CellAt(path);

					if (cell is ActivityItemElement.ActivityElementCell)
					{
						(cell as ActivityItemElement.ActivityElementCell).UpdateSideImage(0);
					}
				}
			}
		}

		public void UpdateVisibleCells()
		{
			foreach(var path in TableView.IndexPathsForVisibleRows)
			{
					var cell = TableView.CellAt(path);
					//var topOfCell = TableView.RectForRowAtIndexPath(indexPath);

					if (cell is ActivityItemElement.ActivityElementCell)
					{
						(cell as ActivityItemElement.ActivityElementCell).UpdateSideImage(0);
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
				var indexPath = Container.TableView.IndexPathForRowAtPoint(point);



				if (indexPath != null)
					(Container as ActivityViewController).UpdateCellAtPath(indexPath, point);

			}

			public override void ScrollAnimationEnded (UIScrollView scrollView)
			{
				(Container as ActivityViewController).UpdateVisibleCells();
			}
		}


	}
}

