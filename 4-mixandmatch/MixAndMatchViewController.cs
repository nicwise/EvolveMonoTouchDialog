using System;
using MonoTouch.Dialog;
using System.Linq;
using MonoTouch.UIKit;

namespace mixandmatch
{
	public class MixAndMatchViewController : DialogViewController
	{
		public MixAndMatchViewController () : base(null, false)
		{
		}
		//delcare these outside of LoadView, so we can get to them in other places.
		BooleanElement usOnlyToggle;
		Section bankListSection;

		public override void LoadView ()
		{
			base.LoadView ();

			var root = new RootElement ("TARP Banks");

			var section = new Section ()
			{
				(usOnlyToggle = new BooleanElement("Show only US banks", false))
			};
			root.Add (section);

			//make a section from the banks. Keep a reference to it
			root.Add ((bankListSection = BuildBankSection (usOnlyToggle.Value)));

			//if the toggle changes, reload the items
			usOnlyToggle.ValueChanged += (sender, e) => {
				var newListSection = BuildBankSection(usOnlyToggle.Value);

				root.Remove(bankListSection, UITableViewRowAnimation.Fade);
				root.Insert(1, UITableViewRowAnimation.Fade, newListSection);
				bankListSection = newListSection;

			};


			Root = root;
		}

		//build the bank section
		Section BuildBankSection(bool showOnlyUsBanks)
		{
			return new Section ("Banks", "Banks and their TARP takings")
			{
				from bank in BankDatasource.Banks()
					where ((!showOnlyUsBanks) || (showOnlyUsBanks && bank.IsUsBank))
					orderby bank.Name
						select BuildBankElement(bank)
						
			};
		}

		//build a single bank element
		Element BuildBankElement(Bank bank)
		{
			var element = new BankElement (bank);
			element.Tapped += () => EditBank (bank);
			return element;
		}


		//using the reflection api to edit a single bank
		void EditBank(Bank bank)
		{
			var context = new BindingContext (this, bank, "Edit " + bank.Name);
			
			//make a dialog view controller (UITableView descendant)
			var dvc = new DialogViewController (context.Root, true);
			
			//setup a button, so we can have a save function
			dvc.NavigationItem.RightBarButtonItem = new UIBarButtonItem (UIBarButtonSystemItem.Save, (o,e) => {
				context.Fetch();
				NavigationController.PopViewControllerAnimated(true);
				ReloadData();

			});

			NavigationController.PushViewController (dvc, true);
		}
	}
}

