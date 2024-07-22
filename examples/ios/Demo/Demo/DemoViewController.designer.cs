//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
// begin-vc-interface
using MonoTouch.Foundation;

namespace Demo
{
	[Register ("DemoViewController")]
	partial class DemoViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITextField btnClickMe { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView tableviewMe { get; set; }


		[Action ("actnButtonClick:")]
		partial void actnButtonClick (MonoTouch.Foundation.NSObject sender);

		[Action ("actnButtonClick2:")]
		partial void actnButtonClick2 (MonoTouch.Foundation.NSObject sender);

		[Action ("dismissKeyBoard:")]
		partial void dismissKeyBoard (MonoTouch.Foundation.NSObject sender);

		[Action ("presentView:")]
		partial void presentView (MonoTouch.Foundation.NSObject sender);


	}
}
// end-vc-interface

