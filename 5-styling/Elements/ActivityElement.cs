using System;
using MonoTouch.Dialog;
using styling.Data;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Drawing;

namespace styling.Elements
{
	public class ActivityItemElement : Element, IElementSizing
	{
		Project Project;
		Activity Activity;
		public ActivityItemElement (Activity activity, Project project) : base(activity.Title)
		{
			Project = project;
			Activity = activity;
		}
		static NSString skey = new NSString ("ActivityItemElement");
		

		protected override NSString CellKey
		{
			get
			{
				return skey;
			}
		}
		
		public override UITableViewCell GetCell (UITableView tv)
		{
			var cell = tv.DequeueReusableCell (CellKey) as ActivityElementCell;
			if (cell == null){
				cell = new ActivityElementCell(CellKey);
			}
			cell.Update(this);
			return cell;
		}
		
		public float GetHeight (UITableView tableView, NSIndexPath indexPath)
		{
			return 200f;//iconImage.Size.Height + 30f;
		}
		
		public class ActivityElementCell : UITableViewCell
		{
			UIImageView logoImage;
			public ActivityElementCell(NSString key) : base(UITableViewCellStyle.Default, key)
			{
				SelectionStyle = UITableViewCellSelectionStyle.None;
				logoImage = new UIImageView();
				logoImage.Frame = new RectangleF(5,5,50,50);
				logoImage.ContentMode = UIViewContentMode.ScaleAspectFill;
				logoImage.Layer.CornerRadius = 4f;
				logoImage.ClipsToBounds = true;


//				ContentView.Layer.BorderColor = UIColor.Red.CGColor;
//				ContentView.Layer.BorderWidth = 5;
//				ContentView.Layer.CornerRadius = 4;
//				ContentView.ClipsToBounds = true;

				ContentView.AddSubviews(logoImage);
				
			}
			
			public void Update(ActivityItemElement source)
			{
				//iconImage.Image = source.iconImage;
				//iconImage.ContentMode = UIViewContentMode.Center;
				ContentView.BackgroundColor = Colors.TableBackgroundGrey;
				logoImage.Image = UIImage.FromBundle(source.Project.MainImage);
				logoImage.Frame = new RectangleF(5,5,50,50);

			}
			
			public override void LayoutSubviews ()
			{
				base.LayoutSubviews ();
				//iconImage.Frame = ContentView.Bounds;
				logoImage.Frame = new RectangleF(5,5,50,50);

			}

			public void UpdateSideImage(float offset)
			{
				float bottomOfLogo = offset + logoImage.Frame.Height + 10;

				float topOfLogo = offset + 5;

				if (bottomOfLogo > ContentView.Frame.Height)
				{
					topOfLogo = ContentView.Frame.Height - (logoImage.Frame.Height + 5);
				}

				var frame = logoImage.Frame;
				frame.Y = topOfLogo;
				logoImage.Frame = frame;
			}
		}
	}
}

