using System;
using MonoTouch.Dialog;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using styling.Data;
using System.Drawing;

namespace styling.Elements
{
	public class ProjectElement : Element, IElementSizing
	{
		static NSString skey = new NSString ("ProjectElement");

		Project Project;

		public ProjectElement (Project project) : base(project.Title)
		{
			Project = project;
		}
		
		protected override NSString CellKey
		{
			get
			{
				return skey;
			}
		}
		
		public override UITableViewCell GetCell (UITableView tv)
		{
			var cell = tv.DequeueReusableCell (CellKey) as ProjectElementCell;
			if (cell == null){
				cell = new ProjectElementCell(CellKey);
			}
			cell.Update(this);
			return cell;
		}
		
		public float GetHeight (UITableView tableView, NSIndexPath indexPath)
		{
			return ProjectElementCell.Height;
		}
		
		class ProjectElementCell : UITableViewCell
		{
			public const float Height = 340;


			UIImageView HeaderImage;
			UILabel TitleLabel, PledgeLabel, BackersLabel, DaysToGoLabel;
			UIProgressView ProgressView;
			UIView ElementBackground, ShadowBackground;


			public ProjectElementCell(NSString key) : base(UITableViewCellStyle.Default, key)
			{
				SelectionStyle = UITableViewCellSelectionStyle.None;
				ElementBackground = new UIView()
				{
					BackgroundColor = UIColor.White

				};

				ShadowBackground = new UIView();

				//we have to use a layer in a layer to get both
				// the shadow AND have all children clipped to the corner radius.


				ShadowBackground.Layer.ShadowColor = UIColor.Black.CGColor;
				ShadowBackground.Layer.ShadowOffset = new SizeF(0,0);
				ShadowBackground.Layer.ShadowRadius = 4f;
				ShadowBackground.Layer.ShadowOpacity = 0.75f;
				ShadowBackground.Layer.CornerRadius = 4f;


				ElementBackground.Layer.CornerRadius = 4f;
				ElementBackground.Layer.MasksToBounds = true;
				ElementBackground.Layer.BorderColor = Colors.ProjectGrey.CGColor;
				ElementBackground.Layer.BorderWidth = 1f;


				HeaderImage = new UIImageView();

				TitleLabel = new UILabel() 
				{
					Font = Fonts.BoldPrimaryFont(14f),
					TextColor = Colors.PrimaryTextColor,
					TextAlignment = UITextAlignment.Center,
					Lines = 2
				};

				ProgressView = new UIProgressView(UIProgressViewStyle.Bar);

				PledgeLabel = new UILabel() 
				{
					Lines = 2,
					Font = Fonts.PrimaryFont(10f),
					TextColor = Colors.SecondaryTextColor
				};

				BackersLabel = new UILabel() 
				{
					Lines = 2,
					Font = Fonts.PrimaryFont(10f),
					TextColor = Colors.SecondaryTextColor
				};

				DaysToGoLabel = new UILabel() 
				{
					Lines = 2,
					Font = Fonts.PrimaryFont(10f),
					TextColor = Colors.SecondaryTextColor
				};

				ElementBackground.AddSubviews(HeaderImage, TitleLabel, ProgressView, PledgeLabel, BackersLabel, DaysToGoLabel);

				ShadowBackground.AddSubview(ElementBackground);
				ContentView.AddSubviews(ShadowBackground);

			}
			
			public void Update(ProjectElement source)
			{
				HeaderImage.Image = UIImage.FromBundle(source.Project.MainImage);
				HeaderImage.ContentMode = UIViewContentMode.ScaleAspectFill;
				TitleLabel.Text = source.Project.Title;


				PledgeLabel.AttributedText = BoldFirstLine(string.Format("${0}", source.Project.PledgeAmount),
				                                           string.Format("PLEDGED OF ${1}", source.Project.PledgeAmount, source.Project.Goal));
				BackersLabel.AttributedText = BoldFirstLine(string.Format("{0}", source.Project.Backers),
				                                            "BACKERS");
				DaysToGoLabel.AttributedText = BoldFirstLine(string.Format("{0}", source.Project.DaysToGo),
				                                             "DAYS TO GO");


				ProgressView.SetProgress(source.Project.PercentProgress, false);
				ContentView.BackgroundColor = UIColor.Clear;
			}

			private NSAttributedString BoldFirstLine(string firstLine, string secondLine)
			{
				var str = new NSMutableAttributedString(firstLine + "\n" + secondLine);

				var att = new UIStringAttributes ();
				att.Font = Fonts.BoldPrimaryFont(12f);
				att.ForegroundColor = Colors.PrimaryTextColor;
				
				str.AddAttributes (att.Dictionary, new NSRange (0, firstLine.Length));

				return str;
			}
			
			public override void LayoutSubviews ()
			{
				base.LayoutSubviews ();

				ShadowBackground.Frame = new RectangleF(15,15,290,Height - 30);
				ElementBackground.Frame = new RectangleF(0,0,290,Height - 30);

				var frame = ElementBackground.Frame;



				HeaderImage.Frame = new RectangleF(new PointF(0,0), new SizeF(frame.Width, 200));

				TitleLabel.Frame = new RectangleF(0,202,frame.Width, 40);
				ProgressView.Frame = new RectangleF(10, 243, frame.Width - 20, 21);

				float padding = 15;
				float labelHeight = 30;
				float x = padding;
				float quarterWidth = (frame.Width - (padding * 2)) /4;
				PledgeLabel.Frame = new RectangleF(x,260, quarterWidth*2,labelHeight);

				x += quarterWidth * 2;
				BackersLabel.Frame = new RectangleF(x, 260, quarterWidth, labelHeight);

				x += quarterWidth;
				DaysToGoLabel.Frame = new RectangleF(x, 260, quarterWidth, labelHeight);

			}
		}
		
	}
}

