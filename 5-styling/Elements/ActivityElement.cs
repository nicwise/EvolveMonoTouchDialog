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
			return ActivityElementCell.CellHeight(Activity.Text);
		}
		
		public class ActivityElementCell : UITableViewCell
		{
			UIImageView logoImage;
			UIView BodyContent;
			UILabel TitleLabel, ActivityTitle, ActivityInfo, BodyText;

			public ActivityElementCell(NSString key) : base(UITableViewCellStyle.Default, key)
			{
				SelectionStyle = UITableViewCellSelectionStyle.None;
				logoImage = new UIImageView();
				logoImage.Frame = new RectangleF(Border,Border,50,50);
				logoImage.ContentMode = UIViewContentMode.ScaleAspectFill;
				logoImage.Layer.CornerRadius = 4f;
				logoImage.ClipsToBounds = true;




				BodyContent = new UIImageView(Resources.ActivityBackground);

				TitleLabel = new UILabel()
				{
					BackgroundColor = UIColor.Clear,
					Font = Fonts.BoldPrimaryFont(14f),
					TextColor = UIColor.Black
				};



				ActivityTitle = new UILabel()
				{
					Font = Fonts.BoldPrimaryFont(13f),
					TextColor = UIColor.Black
				};

				ActivityInfo = new UILabel()
				{
					Font = Fonts.PrimaryFont(8f),
					TextColor = Colors.SecondaryTextColor
				};

				BodyText = new UILabel()
				{
					Font = Fonts.PrimaryFont(13f),
					TextColor = UIColor.Black,
					Lines = 20,
					TextAlignment = UITextAlignment.Left,
					LineBreakMode = UILineBreakMode.WordWrap
				};



				BodyContent.AddSubviews(TitleLabel, ActivityTitle, ActivityInfo, BodyText);

				ContentView.AddSubviews(logoImage, BodyContent);
				
			}



			public static float CellHeight(string source)
			{
				var size = new NSString(source).StringSize(Fonts.PrimaryFont (13f), new SizeF(240f, 999),UILineBreakMode.WordWrap);

				return ((Border * 2) + 55f + 35f) + (size.Height > 300f ? 300f : size.Height);

			}
			
			public void Update(ActivityItemElement source)
			{
				//iconImage.Image = source.iconImage;
				//iconImage.ContentMode = UIViewContentMode.Center;
				ContentView.BackgroundColor = Colors.TableBackgroundGrey;
				logoImage.Image = UIImage.FromBundle(source.Project.MainImage);
				logoImage.Frame = new RectangleF(Border, Border,50,50);
				TitleLabel.Text = source.Project.Title;
				ActivityTitle.Text = source.Activity.Title;
				ActivityInfo.Text = string.Format ("Update #{0}. {1:0} days ago", source.Activity.UpdateNumber, (DateTime.Now - source.Activity.Date).TotalDays);
				BodyText.Text = source.Activity.Text;
				SetNeedsLayout();

			}

			public const float Border = 10;
			public override void LayoutSubviews ()
			{
				base.LayoutSubviews ();
				//iconImage.Frame = ContentView.Bounds;
				logoImage.Frame = new RectangleF(Border, Border,50,50);

				BodyContent.Frame = new RectangleF(70,Border, 240, CellHeight (BodyText.Text) - (Border * 2));
				var frame = BodyContent.Frame;


				frame.Inflate(-10,-10);


				float y = 0;
				TitleLabel.Frame = new RectangleF(10,y,frame.Width,50);
				y += 55;

				ActivityTitle.Frame = new RectangleF(10,y,frame.Width, 20);
				y += 20;

				ActivityInfo.Frame = new RectangleF(10,y, frame.Width, 10);
				y += 12;

				var size = new NSString(BodyText.Text).StringSize(Fonts.PrimaryFont (13f), new SizeF(240f, 999),UILineBreakMode.WordWrap);

				BodyText.Frame = new RectangleF(10,y,frame.Width, (size.Height > 300f ? 300f : size.Height));


			}

			public void UpdateSideImage(float offset)
			{
				float topOfLogo = offset + Border;

				float maxTop = ContentView.Frame.Height - (logoImage.Frame.Height + Border);

				if (topOfLogo > maxTop)
				{
					topOfLogo = maxTop;
				}

				var frame = logoImage.Frame;
				frame.Y = topOfLogo;
				logoImage.Frame = frame;
			}
		}
	}
}

