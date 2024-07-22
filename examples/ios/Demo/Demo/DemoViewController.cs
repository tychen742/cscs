using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
namespace Demo
{


	public partial class DemoViewController : UIViewController 
	{
		protected TableSource tableSource;

		public DemoViewController () : base ("DemoViewController", null)
		{


		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			
		}
		// begin-vc-xamarin
public override void ViewDidLoad ()
{
	base.ViewDidLoad ();

	List<TableItemGroup> tableItems = new List<TableItemGroup> ();

	TableItemGroup tGroup;

			// Section 1
	tGroup = new TableItemGroup() { Name = "Section 0 Header", Footer = "Section 0 Footer" };
	tGroup.Items.Add ("Row 0");
	tGroup.Items.Add ("Row 1");
	tGroup.Items.Add ("Row 2");
	tGroup.Items.Add ("Row 3");
	tableItems.Add (tGroup);

			// Section 2
	tGroup = new TableItemGroup() { Name = "Section 1 Header", Footer = "Section 1 Footer" };
	tGroup.Items.Add ("Row 0");
	tGroup.Items.Add ("Row 1");
	tGroup.Items.Add ("Row 2");
	tableItems.Add (tGroup);

			// Section 3
	tGroup = new TableItemGroup() { Name = "Section 2 Header", Footer = "Section 2 Footer" };
	tGroup.Items.Add ("Row 0");
	tGroup.Items.Add ("Row 1");
	tGroup.Items.Add ("Row 2");
	tableItems.Add (tGroup);

	tableSource = new TableSource(tableItems);
	this.tableviewMe.Source = tableSource;
}
		// end-vc-xamarin

		// begin-actnButtonClick-xamarin
partial void actnButtonClick (MonoTouch.Foundation.NSObject sender)
{
			// begin-action-xamarin
	UIAlertView alert = new UIAlertView () { 
		Title = "alert title", Message = "Hello World!"
	};
	alert.AddButton("OK");
	alert.Show ();
			// end-action-xamarin
}
		// end-actnButtonClick-xamarin

		// begin-dismissKeyBoard-xamarin
		partial void dismissKeyBoard (MonoTouch.Foundation.NSObject sender) {

			btnClickMe.ResignFirstResponder();
		}
		// end-dismissKeyBoard-xamarin

		// begin-presentView-xamarin
partial void presentView (MonoTouch.Foundation.NSObject sender) {

	LoginController login = new LoginController();
	this.PresentViewController (login, true, null);

}
		// end-presentView-xamarin

partial void actnButtonClick2 (MonoTouch.Foundation.NSObject sender)
{
			// begin-actnButtonClick2-xamarin
			//Splits the data in the text field
	string[] lines = btnClickMe.Text.Split (' ');
			//Get the count
	int counts = lines.Length;
			//Checks how many parts there are
	if(counts == 1) {

	UIAlertView alert = new UIAlertView () { 
		Title = "alert title", Message = lines[0]
	};
	alert.AddButton("OK");
	alert.Show ();

	} else {
		string data = lines[1] + ", " + lines[0];
		UIAlertView alert = new UIAlertView () { 
			Title = "alert title", Message = data
		};
		alert.AddButton("OK");
		alert.Show ();

	}
			// end-actnButtonClick2-xamarin
							
}


		public class TableItemGroup
		{
			public string Name { get; set; }

			public string Footer { get; set; }

			public List<string> Items
			{
				get { return items; }
				set { items = value; }
			}
			protected List<string> items = new List<string> ();
		}

		public class TableSource : UITableViewSource
		{
			protected List<TableItemGroup> tableItems;
			protected string cellIdentifier = "TableCell";

			public TableSource (List<TableItemGroup> items)
			{
				tableItems = items;
			}

			//begin-NumberOfSections
public override int NumberOfSections (UITableView tableView)
{
	return tableItems.Count;
}
			//end-NumberOfSections

			//begin-RowsInSection
public override int RowsInSection (UITableView tableview, int section)
{
	return tableItems[section].Items.Count;
}
			//end-RowsInSection
			//begin-TitleForHeader
public override string TitleForHeader (UITableView tableView, int section)
{
	return tableItems[section].Name;
}
			//end-TitleForHeader
			//begin-TitleForFooter
public override string TitleForFooter (UITableView tableView, int section)
{
	return tableItems[section].Footer;
}
			//end-TitleForFooter


			//begin-RowSelected
public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
{
	new UIAlertView ("Row Selected", tableItems[indexPath.Section].Items[indexPath.Row], null, "OK", null).Show ();
}
			//end-RowSelected
			//begin-RowDeselected
public override void RowDeselected (UITableView tableView, NSIndexPath indexPath)
{
	Console.WriteLine ("Row " + indexPath.Row.ToString () + " deselected");	
}
			//end-RowDeselected
			//begin-GetCell
public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
{
	Console.WriteLine ("Calling Get Cell, isEditing:" + tableView.Editing);

	UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);

	if (cell == null)
		cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);

		cell.TextLabel.Text = tableItems[indexPath.Section].Items[indexPath.Row];

		return cell;
}
			//end-GetCell
		}


	}
}

