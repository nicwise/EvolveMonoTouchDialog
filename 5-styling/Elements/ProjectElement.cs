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
			public const float Height = 320;


			UIImageView HeaderImage;
			UILabel TitleLabel, PledgeLabel, BackersLabel, DaysToGoLabel;
			UIProgressView ProgressView;
			UIImageView ElementBackground;

			UIImageView PlayButtonImage;


			public ProjectElementCell(NSString key) : base(UITableViewCellStyle.Default, key)
			{
				SelectionStyle = UITableViewCellSelectionStyle.None;
				ElementBackground = new UIImageView(Resources.ProjectBackground);



				HeaderImage = new UIImageView();
				HeaderImage.Layer.CornerRadius = 4f;
				HeaderImage.ClipsToBounds = true;

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

				PlayButtonImage = new UIImageView(Resources.PlayButton);
				PlayButtonImage.ContentMode = UIViewContentMode.Center;
				PlayButtonImage.Alpha = 1f;

				ElementBackground.AddSubviews(HeaderImage, TitleLabel, ProgressView, PledgeLabel, BackersLabel, DaysToGoLabel, PlayButtonImage);
				ContentView.AddSubviews(ElementBackground);

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

				ElementBackground.Frame = ContentView.Frame;

				float Border = 16f;
				var frame = new RectangleF(16,16, ContentView.Frame.Width - 32, ContentView.Frame.Height - 32);



				HeaderImage.Frame = new RectangleF(new PointF(Border,Border), new SizeF(frame.Width, 200));
				PlayButtonImage.Frame = HeaderImage.Frame;

				TitleLabel.Frame = new RectangleF(Border,202,frame.Width, 40);
				ProgressView.Frame = new RectangleF(Border + 10, 243, frame.Width - 20, 21);

				float padding = 15;
				float labelHeight = 30;
				float x = Border + padding;
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

