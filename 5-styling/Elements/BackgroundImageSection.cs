using System;
using MonoTouch.Dialog;
using MonoTouch.UIKit;
using System.Drawing;

namespace styling
{
	public class BackgroundImageSection : Section
	{
		#region header
		public BackgroundImageSection(string header) : base(header){}
		public BackgroundImageSection(string header, string footer) : base(header, footer) {}
		public BackgroundImageSection() : base(null, MakeEmptySectionFooter()) {}
		public BackgroundImageSection(UIView header) : base(header)
		{
			
		}
		
		public BackgroundImageSection(UIView header, UIView footer) : base(header, footer)
		{
		}
		#endregion
		
		public override UITableViewCell CustomizeCell (UITableViewCell cell, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			var theCell = base.CustomizeCell (cell, indexPath);
			
			//if (!Util.IsIOS5OrBetter) return cell;
			
			if (Count == 1) //use one with top and bottom rounded
			{
				theCell.BackgroundView = new UIImageView(Resources.CellBackgroundFull);
				theCell.SelectedBackgroundView = new UIImageView(Resources.CellBackgroundFullActive); 
				
			} else if (indexPath.Row == 0) //top only
			{
				theCell.BackgroundView = new UIImageView(Resources.CellBackgroundTop);
				theCell.SelectedBackgroundView = new UIImageView(Resources.CellBackgroundTopActive); 
				
			} else if (indexPath.Row+1 == this.Count) // bottom only
			{
				theCell.BackgroundView = new UIImageView(Resources.CellBackgroundBottom);
				theCell.SelectedBackgroundView = new UIImageView(Resources.CellBackgroundBottomActive); 
			} else //anything in the middle
			{
				theCell.BackgroundView = new UIImageView(Resources.CellBackgroundMiddle);
				theCell.SelectedBackgroundView = new UIImageView(Resources.CellBackgroundMiddleActive); 
			}
			return theCell;
			
		}

		#region method...
		public static UIView MakeEmptySectionFooter()
		{
			UIFont font = UIFont.SystemFontOfSize(15f);
			SizeF maxSize = new SizeF(280, 999);
			
			
			var view = new UIView(new RectangleF(0,0,280, 2)) {
				BackgroundColor = UIColor.Clear
			};
			
			
			return view;
		}
		#endregion
	}
}

