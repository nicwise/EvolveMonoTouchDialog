using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace styling.Elements
{
	public class ProfileImageView : UIView
	{
		UIImageView backgroundImage;

		public ProfileImageView () : base(new RectangleF(0,0,300,100))
		{
			backgroundImage = new UIImageView(UIImage.FromBundle("images/covers/profilepic.png"));
			backgroundImage.Frame = Bounds;
			backgroundImage.ContentMode = UIViewContentMode.ScaleAspectFill;
			backgroundImage.ClipsToBounds = true;

			backgroundImage.Layer.CornerRadius = 8f;


			Add(backgroundImage);
		}


	}
}

