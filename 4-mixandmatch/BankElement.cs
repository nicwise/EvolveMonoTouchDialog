using System;
using MonoTouch.Dialog;
using MonoTouch.Foundation;

namespace mixandmatch
{

	// An element which present a Bank.
	// We could just create StyledStingElements, but then we can't
	// call ReloadData when we edit something! This is quite easy, too.

	//we are mostly just filling in the same fields....
	public class BankElement : StyledStringElement
	{
		Bank currentBank;
		public BankElement (Bank bank) : base("")
		{
			currentBank = bank;

			style = MonoTouch.UIKit.UITableViewCellStyle.Subtitle;
			Accessory = MonoTouch.UIKit.UITableViewCellAccessory.DisclosureIndicator;
		}

		//We need to do this, otherwise, we'd get recycled cells which might have been used for other
		// things - ie, not banks. More important if you are adding things into the cell.ContentView,
		// but a good habit to get into.
		static NSString skey = new NSString("BankElement");
		protected override NSString CellKey
		{
			get
			{
				return skey;
			}
		}


		// StyledStringElement is doing the hard lifting for us, but this gets called when we call ReloadData
		// or when it's first loaded.
		public override MonoTouch.UIKit.UITableViewCell GetCell (MonoTouch.UIKit.UITableView tv)
		{
			var cell = base.GetCell (tv);
			cell.TextLabel.Text = currentBank.Name;

			string tarpFundsTaken = "No TARP funds taken";
			if (currentBank.TarpFunded)
			{
				tarpFundsTaken = string.Format ("${0:0.0}b in TARP funds taken", currentBank.TarpFunds);
			}

			cell.DetailTextLabel.Text = tarpFundsTaken;

			return cell;
		}


	}
}

