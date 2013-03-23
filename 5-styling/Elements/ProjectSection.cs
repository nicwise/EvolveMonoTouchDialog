using System;
using MonoTouch.Dialog;
using styling.Data;
using MonoTouch.UIKit;
using System.Drawing;

namespace styling.Elements
{
	public class ProjectSection : Section
	{
		Project Project;
		public ProjectSection (Project proj) : base()
		{
			Project = proj;
			//HeaderView = BuildHeaderView();
			//FooterView = BuildFooterView();
		}

		UIView BuildHeaderView()
		{
			var view = new UIView(new RectangleF(0,0,320, 1));
			view.BackgroundColor = UIColor.Clear;

			var backgroundView = new UIView(new RectangleF(0,0,80, 80));
			backgroundView.BackgroundColor = Colors.TableBackgroundGrey;

			var logoImage = new UIImageView(UIImage.FromBundle(Project.MainImage));
			logoImage.Frame = new RectangleF(5,5,70,70);
			logoImage.ContentMode = UIViewContentMode.ScaleAspectFill;
			logoImage.Layer.CornerRadius = 4f;
			logoImage.ClipsToBounds = true;

			view.AddSubviews(backgroundView, logoImage);

			view.ClipsToBounds = false;


			return view;
		}

		
		UIView BuildFooterView()
		{
			var view = new UIView(new RectangleF(0,0,320, 1));
			view.BackgroundColor = UIColor.Clear;
			

			
			
			return view;
		}
	}
}

