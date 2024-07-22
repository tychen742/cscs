using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Demo
{
	public partial class LoginController : UIViewController
	{
		public LoginController () : base ("LoginController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		partial void dismiss (MonoTouch.Foundation.NSObject sender) {
			//begin-dismiss-xamarin
			this.DismissViewController(true, null);
			//end-dismiss-xamarin
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

