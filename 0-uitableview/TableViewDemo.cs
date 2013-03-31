using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Collections.Generic;

namespace uitableview
{
	public class TableViewDemo : UITableViewController
	{
		public TableViewDemo () : base(UITableViewStyle.Grouped)
		{
			var data = new List<DataHolder>();

	
			data.Add(new DataHolder() {

			  Key = "Red Dwarf", 
			  Values = new List<string> {
				"Rimmer",
				"Lister",
				"Cat",
				"Kryton",
				"Holly"
			}
			});

			data.Add(new DataHolder() {
				
				Key = "Star Wars", 
				Values = new List<string> {
					"Luke",
					"Leia",
					"Han Solo",
					"Chewie",
					"R2D2",
					"C3P0"
				}
			});

			data.Add(new DataHolder() {
				
				Key = "Star Trek", 
				Values = new List<string> {
					"Kirk",
					"Spock",
					"Bones",
					"Red Shirt Guy"
				}
			});

			//setup the delegate and datasource, so the table view has something to talk to
			// when it wants to do anything.
			TableView.Delegate = new DemoDelegate(this);
			TableView.DataSource = new DemoDataSource(this) { Data = data };
		}

		class DemoDelegate : UITableViewDelegate
		{
			TableViewDemo Container;
			public DemoDelegate(TableViewDemo container)
			{
				Container = container;
			}

			// handle an item being clicked, by.... deselecting it.
			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				Console.WriteLine ("you tapped on Row {0} of section {1}", indexPath.Row, indexPath.Section);
				Container.TableView.DeselectRow(indexPath, true);
			}
		}

		class DemoDataSource : UITableViewDataSource
		{
			TableViewDemo Container;
			public DemoDataSource(TableViewDemo container)
			{
				Container = container;
			}

			public List<DataHolder> Data;

			static NSString cellId = new NSString("TableViewDemoCell");

			//gets a single cell
			public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell(cellId);

				if (cell == null)
				{
					cell = new UITableViewCell(UITableViewCellStyle.Default, cellId);
				}

				var @value = Data[indexPath.Section].Values[indexPath.Row];

				cell.TextLabel.Text = @value;
				return cell;
			}

			//how many sections do we have?
			public override int NumberOfSections (UITableView tableView)
			{
				return Data.Count;
			}

			// how many rows in a given section?
			public override int RowsInSection (UITableView tableView, int section)
			{
				return Data[section].Values.Count;
			}

			//What should be displayed for the title of this section?
			public override string TitleForHeader (UITableView tableView, int section)
			{
				return Data[section].Key;
			}

			// ... and for the footer
			public override string TitleForFooter (UITableView tableView, int section)
			{
				return "Footer: " + Data[section].Key;
			}

		}

		public class DataHolder
		{
			public string Key;
			public List<string> Values = new List<string>();
		}
	}
}

