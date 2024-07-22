using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Demo
{
	public class LoginViewControllerCell : UICollectionViewCell
	{
		public static readonly NSString Key = new NSString ("LoginViewControllerCell");

		[Export ("initWithFrame:")]
		public LoginViewControllerCell (RectangleF frame) : base (frame)
		{
			// TODO: add subviews to the ContentView, set various colors, etc.
			BackgroundColor = UIColor.Cyan;
		}
	}
}

