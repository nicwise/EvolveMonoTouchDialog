using System;
using MonoTouch.Dialog;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace styling.Elements
{
	public class IconElement : Element, IElementSizing
	{
		static NSString skey = new NSString ("IconElement");

		public UIImage iconImage;
		public IconElement (UIImage icon, string caption) : base(caption)
		{
			iconImage = icon;
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
			var cell = tv.DequeueReusableCell (CellKey) as IconElementCell;
			if (cell == null){
				cell = new IconElementCell(CellKey);
			}
			cell.Update(this);
			return cell;
		}

		public float GetHeight (UITableView tableView, NSIndexPath indexPath)
		{
			return iconImage.Size.Height + 30f;
		}

		class IconElementCell : UITableViewCell
		{
			UIImageView iconImage;
			public IconElementCell(NSString key) : base(UITableViewCellStyle.Default, key)
			{
				iconImage = new UIImageView();
				ContentView.Add(iconImage);
			}

			public void Update(IconElement source)
			{
				iconImage.Image = source.iconImage;
				iconImage.ContentMode = UIViewContentMode.Center;
				ContentView.BackgroundColor = UIColor.Black;
			}

			public override void LayoutSubviews ()
			{
				base.LayoutSubviews ();
				iconImage.Frame = ContentView.Bounds;
			}
		}

	}
}

